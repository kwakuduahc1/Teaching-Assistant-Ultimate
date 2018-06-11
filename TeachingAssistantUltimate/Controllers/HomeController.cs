using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachingAssistant.Context;

namespace TeachingAssistantUltimate.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> context;

        public HomeController(DbContextOptions<ApplicationDbContext> dbContextOptions) => context = dbContextOptions;

        public async Task<IActionResult> Index()
        {
            using (var db = new ApplicationDbContext(context))
            {
                //Make sure the database has been created;
                await db.Database.EnsureCreatedAsync();
            }
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
