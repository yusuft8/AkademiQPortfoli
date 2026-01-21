using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly AppDbContext _context;
        public ExperienceController(AppDbContext context) => _context = context;

        public IActionResult Index()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value == null) return NotFound();

            _context.Experiences.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value == null) return NotFound();

            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
