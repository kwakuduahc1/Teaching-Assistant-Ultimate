using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElectronNET.API;
using ElectronNET.API.Entities;
using System.Threading.Tasks;

namespace TeachingAssistant.Controllers
{
    public class PdfController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (HybridSupport.IsElectronActive)
            {
                var window = await Electron.WindowManager.CreateWindowAsync(loadUrl: "http://localhost:80");
            }

            return Ok(new { Message = "Document was saved to selected location" });
        }
    }
}