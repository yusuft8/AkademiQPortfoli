using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;
        public _DefaultFeatureComponentPartial(AppDbContext context) => _context = context;

        public IViewComponentResult Invoke()
        {
            var about = _context.Abouts.AsNoTracking().FirstOrDefault();
            return View(about); // About modeli gidecek
           
        }
    }
}
