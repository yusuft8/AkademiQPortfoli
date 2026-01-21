using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultPortfolioComponentPartial:ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultPortfolioComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _context.Works
                .OrderByDescending(x => x.WorkId)
                .ToList();

            return View(projects);
        }
    }
}
