using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachingAssistantUltimate.Context;
using TeachingAssistantUltimate.Model;

namespace TeachingAssistantUltimate.Controllers
{
    public class ResultsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ResultsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var subj = await new ApplicationDbContext(dco).Results.Select(x => new
            {
                x.AssessmentTypes.AssessmentType,
                x.AssessmentTypesID,
                x.ResultsID,
                x.Score,
                x.Students.IndexNumber,
                x.Students.Name,
                x.StudentsID,
                x.SubjectsID,
                x.TotalScore,
                x.Subjects.SubjectCode,
                x.Subjects.Subject
            }).SingleOrDefaultAsync(x => x.SubjectsID == id);
            if (subj == null)
                return NotFound();
            return Ok(subj);
        }

        [HttpGet]
        public async Task<IEnumerable> List(int id)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                return await db.Results.Where(x => x.Students.ClassesID == id).Select(x => new
                {
                    x.AssessmentTypes.AssessmentType,
                    x.AssessmentTypesID,
                    x.ResultsID,
                    x.Score,
                    x.Students.IndexNumber,
                    x.Students.Name,
                    x.StudentsID,
                    x.SubjectsID,
                    x.TotalScore,
                    x.Subjects.SubjectCode,
                    x.Subjects.Subject
                })
                    .ToListAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]List<Results> results)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext(dco))
                {
                    db.AddRange(results);
                    await db.SaveChangesAsync();
                    return Created($"/Results/List", results);
                }
            }
            return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]Results results)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext(dco))
                {
                    if (!await db.Results.AnyAsync(x => x.ResultsID == results.ResultsID))
                        return BadRequest(new { Message = "No results was found matching the details provided" });
                    db.Entry(results).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return Ok(results);
            }
            return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Subjects subject)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext(dco))
                {
                    if (!await db.Subjects.AnyAsync(x => x.SubjectsID == subject.SubjectsID))
                        return BadRequest(new { Message = "No results was found matching the details provided" });
                    db.Entry(subject).State = EntityState.Deleted;
                    await db.SaveChangesAsync();
                }
                return Ok(new { message = "Results deleted" });
            }
            return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
        }
    }
}