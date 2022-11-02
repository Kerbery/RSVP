using Microsoft.AspNetCore.Mvc;
using RSVP.Models;
using RSVP.Services;
using System.Diagnostics;

namespace RSVP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAttendenceService _service;

        public HomeController(ILogger<HomeController> logger, IAttendenceService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _service.AddUser(userViewModel);
                return RedirectToAction(nameof(Stats), userViewModel);
            }
            return View();
        }

        public IActionResult Stats(UserViewModel userViewModel)
        {            
            if (ModelState.IsValid)
            {
                ViewBag.User = userViewModel;
            }
            var stats = _service.GetAttendenceStats();
            return View(stats);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}