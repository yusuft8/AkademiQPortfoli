using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using AkademiQPortfolio.Entities;


namespace AkademiQPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SendDate = DateTime.Now;   // ✅ otomatik tarih
            message.IsRead = false;

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Index", "Default");
        }
    }
}
