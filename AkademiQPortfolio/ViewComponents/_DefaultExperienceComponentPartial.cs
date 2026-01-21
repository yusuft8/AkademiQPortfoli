using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultExperienceComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultExperienceComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var list = _context.Experiences
                .OrderByDescending(x => x.Experiencid)
                .ToList();

            return View(list);
        }
    }
}
