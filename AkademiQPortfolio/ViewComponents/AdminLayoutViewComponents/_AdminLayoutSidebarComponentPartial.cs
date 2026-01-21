using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AkademiQPortfolio.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _AdminLayoutSidebarComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // IsRead bool? olabilir: okunmamış = true olmayan (false veya null)
            ViewBag.UnreadCount = _context.Messages.Count(x => x.IsRead != true);
            return View();
        }
    }
}
