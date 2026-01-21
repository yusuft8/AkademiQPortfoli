using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AdminAboutController : Controller
{
    private readonly AppDbContext _context;
    public AdminAboutController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult Index()
    {
        var about = _context.Abouts.FirstOrDefault();
        return View(about ?? new About());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(About model)
    {
        var about = _context.Abouts.FirstOrDefault();

        if (about == null)
        {
           _context.Abouts.Add(model);
        }
        else
        {
            about.NameSurname = model.NameSurname;
            about.Title = model.Title;
            about.Description = model.Description;
            about.Phone = model.Phone;
            about.Email = model.Email;
            about.Adress = model.Adress;
            about.ImageURL = model.ImageURL;
        }

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
