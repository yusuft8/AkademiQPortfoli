using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DownloadCv()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "YusufTopal-CV.pdf");

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            return PhysicalFile(filePath, "application/pdf", "YusufTopal-CV.pdf");
        }
    }


}
