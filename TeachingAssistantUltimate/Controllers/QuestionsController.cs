using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachingAssistant.Context;
using TeachingAssistant.Model;
using TeachingAssistant.Model.ViewModels;

namespace CampusConnectApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public QuestionsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpPost]
        public async Task<IEnumerable> GetQuestions(GetQuestionsVm vm) => await new ApplicationDbContext(dco).Questions.Where(x => x.SubjectsID == vm.SubjectsID).ToListAsync();

        [HttpGet]
        public async Task<IEnumerable> Topics(int id) => await new ApplicationDbContext(dco).Questions.Where(x => x.SubjectsID == id).Select(x => new { x.Topic, Number = 0 }).Distinct().ToListAsync();

        [HttpPost]
        public async Task<IEnumerable> Generate([FromBody]GeneratorVm vm)
        {
            var questions = new List<TestVm>();
            using (var db = new ApplicationDbContext(dco))
            {
                foreach (var top in vm.Topics.Where(x => x.Number > 0).ToList())
                {
                    string qry = @"SELECT q.Question , q.QuestionsID
                                    FROM Questions q
                                    INNER JOIN Subjects s on s.SubjectsID = q.SubjectsID
                                    WHERE s.SubjectsID = @subject AND q.topic = @topic
                                    ORDER BY RANDOM() LIMIT @num ";
                    var quest = await db.Questions.FromSql(qry, new SqliteParameter("@subject", vm.SubjectsID), new SqliteParameter("@topic", top.Topic), new SqliteParameter("@num", top.Number))
                        .Select(x => new TestVm { Question = x.Question, Options = x.Options.Select(t => t.Option) })
                        .ToListAsync();
                    questions.AddRange(quest);
                }
            }
            return questions;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Questions question)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            question.QuestionsID = Guid.NewGuid();
            question.DateAdded = DateTime.Now;
            foreach (var item in question.Options)
            {
                item.IsAnswer = false;
                item.OptionsID = Guid.NewGuid();
                item.QuestionsID = question.QuestionsID;
            }
            question.Options.First().IsAnswer = true;
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.Questions.AnyAsync(x => x.Question == question.Question))
                    return BadRequest(new { Message = "Same question has been asked in the system. Kindly compose another question" });
                db.Questions.Add(question);
                await db.SaveChangesAsync();
            }
            return Created("", new { question.Question, question.Topic, question.QuestionsID, question.SubjectsID });
        }
    }
}