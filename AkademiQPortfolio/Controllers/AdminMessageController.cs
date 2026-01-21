using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkademiQPortfolio.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly AppDbContext _context;
        public AdminMessageController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Index(string tab = "all")
        {
            var query = _context.Messages.AsQueryable();

            if (tab == "unread")
                query = query.Where(x => x.IsRead != true);

            var list = query
                .OrderByDescending(x => x.SendDate)
                .ToList();

            ViewBag.Tab = tab;
            ViewBag.UnreadCount = _context.Messages.Count(x => x.IsRead != true);
            ViewBag.TotalCount = _context.Messages.Count();

            return View(list);
        }

        // Modal için detay getir
        [HttpGet]
        public IActionResult GetMessage(int id)
        {
            var msg = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (msg == null) return NotFound();

            return Json(new
            {
                messageId = msg.MessageId,
                senderName = msg.SenderName ?? "-",
                senderMail = msg.SenderMail ?? "-",
                subject = msg.MessageSubject ?? "-",
                text = msg.MessageText ?? "",
                date = msg.SendDate?.ToString("dd.MM.yyyy HH:mm") ?? "-",
                isRead = msg.IsRead == true
            });
        }

        // Tek mesaj okundu/okunmadı
        [HttpPost]
        public IActionResult SetRead(int id, bool isRead)
        {
            var msg = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (msg == null) return NotFound();

            msg.IsRead = isRead;
            _context.SaveChanges();
            return Ok(new { success = true });
        }

        // Hepsini okundu yap
        [HttpPost]
        public IActionResult MarkAllRead()
        {
            var unread = _context.Messages.Where(x => x.IsRead != true).ToList();
            foreach (var m in unread) m.IsRead = true;
            _context.SaveChanges();
            return Ok(new { success = true });
        }

        // Sil
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var msg = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (msg == null) return NotFound();

            _context.Messages.Remove(msg);
            _context.SaveChanges();
            return Ok(new { success = true });
        }
    }
}
