using Microsoft.AspNetCore.Mvc;
using ContactUsApp.Data;
using System.Linq;

namespace ContactUsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            // DB theke sob contact messages fetch
            var allContacts = _context.Contacts
                                      .OrderByDescending(c => c.Id)
                                      .ToList();

            // View e pass kora
            ViewBag.AllContacts = allContacts;

            return View();
        }
    }
}
