using Microsoft.AspNetCore.Mvc;
using ElectronNET.API;
using System.Threading.Tasks;
using Aspose.Html;
using System;
using System.IO;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering;
using Aspose.Html.Dom;
using System.Collections.Generic;
using TeachingAssistant.Model.ViewModels;

namespace TeachingAssistant.Controllers
{
    public class PrintController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var req = Request.Host.Value;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Teaching Assistant Ultimate");
            var document = new HTMLDocument($"http://{req}/generate/{id}");
            //RenderSimplePdf();
            RenderAdvancedPdf(document);
            //RenderMirrorPages();
            if (HybridSupport.IsElectronActive)
            {
                var window = await Electron.WindowManager.CreateWindowAsync(loadUrl: $"http://{req}/generate/{id}");
            }
            return Ok(new { Message = "Document was saved to selected location" });
        }

        private static void RenderAdvancedPdf(Document document)
        {
            var width = Unit.FromMillimeters(297);
            var height = Unit.FromMillimeters(420);
            var pageSizeA3 = new Size(width, height);

            var margins = new Margin(
                Unit.FromMillimeters(15), // left
                Unit.FromMillimeters(10), // top
                Unit.FromMillimeters(15), // right
                Unit.FromMillimeters(20));// bottom

            var options = new PdfRenderingOptions
            {
                PageSetup = { AnyPage = new Page(pageSizeA3, margins) }
            };
            const string outputfile = @"C:\Amin\output02.pdf";

            Console.WriteLine("Render PDF file started...");
            var device = new PdfDevice(options, outputfile);
            var renderer = new HtmlRenderer();
            renderer.Render(device, document);
            Console.WriteLine("Render PDF file finished.");
        }
    }
}