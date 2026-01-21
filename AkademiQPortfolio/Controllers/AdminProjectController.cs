using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        // LISTELE
        public IActionResult ProjectList()
        {
            var values = _context.Works.ToList();
            return View(values);
        }

        // EKLE (GET)
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        // EKLE (POST)
        [HttpPost]
        public IActionResult CreateProject(Work work)
        {
            _context.Works.Add(work);
            _context.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        // SİL
        public IActionResult DeleteProject(int id)
        {
            var value = _context.Works.Find(id);
            if (value == null) return NotFound();

            _context.Works.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        // GÜNCELLE (GET)
        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var value = _context.Works.Find(id);
            if (value == null) return NotFound();

            return View(value);
        }

        // GÜNCELLE (POST)
        [HttpPost]
        public IActionResult UpdateProject(Work work)
        {
            _context.Works.Update(work);
            _context.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}
