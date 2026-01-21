using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultEducationComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultEducationComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var list = _context.Educations
                .OrderByDescending(x => x.EducationId)
                .ToList();

            return View(list);
        }
    }
}
