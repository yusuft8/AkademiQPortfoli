using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AkademiQPortfolio.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly AppDbContext _context;
        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult StatisticsCards()
        {
            var projectCount = _context.Works.Count();        // proje tablon Work ise
            var experienceCount = _context.Experiences.Count();
            var educationCount = _context.Educations.Count();

            ViewBag.ProjectCount = projectCount;
            ViewBag.ExperienceCount = experienceCount;
            ViewBag.EducationCount = educationCount;

            var messageCount = _context.Messages.Count();

            // IsRead bool? ise: okunmuş = true, okunmamış = true olmayan (false veya null)
            var messageCountByIsReadTrue = _context.Messages.Count(x => x.IsRead == true);
            var messageCountByIsReadFalse = _context.Messages.Count(x => x.IsRead != true);

            var skillCount = _context.Skills.Count();

            // Skill boşsa Average hata verir, bunu korumalı yap
            var skillAvgValue = skillCount > 0 ? _context.Skills.Average(x => x.SkillValue) : 0;

            var skillValueBiggerThan70 = _context.Skills.Count(x => x.SkillValue >= 70);

            // View'da sen @ViewBag.messageCount yazıyorsun gibi -> isimleri uyumlu yapalım
            ViewBag.messageCount = messageCount;
            ViewBag.messageCountByIsReadTrue = messageCountByIsReadTrue;
            ViewBag.messageCountByIsReadFalse = messageCountByIsReadFalse;

            ViewBag.skillCount = skillCount;
            ViewBag.skillAvgValue = skillAvgValue;
            ViewBag.skillValueBiggerThan70 = skillValueBiggerThan70;

            ViewBag.messageSubjectByWorkOffer =
                _context.Messages.Count(x => x.MessageSubject == "Proje Teklifi & İş Birliği");

            ViewBag.messageSubjectByApiDevelopment =
                _context.Messages.Count(x => x.MessageSubject == "Web / API Geliştirme Talebi");

            ViewBag.messageSubjectByEducationOffer =
                _context.Messages.Count(x => x.MessageSubject == "Eğitim & Kurumsal Eğitim Talebi");

            return View();
        }

    }
}