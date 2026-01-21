using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultSkillComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultSkillComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var skills = _context.Skills
                .OrderByDescending(x => x.SkillValue) // istersen kaldır
                .ToList();

            return View(skills);
        }
    }
}
