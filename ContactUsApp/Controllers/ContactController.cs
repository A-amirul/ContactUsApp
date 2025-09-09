using Microsoft.AspNetCore.Mvc;
using ContactUsApp.Models;
using ContactUsApp.Data;

namespace ContactUsApp.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(new ContactForm());
        }

        [HttpPost("submit")]
        public IActionResult Submit(ContactForm model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            _context.Contacts.Add(model);
            _context.SaveChanges();

            TempData["Success"] = "Your message has been saved successfully!";
            return RedirectToAction("Index");
        }
    }
}
