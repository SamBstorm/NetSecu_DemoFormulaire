using Microsoft.AspNetCore.Mvc;
using NetSecu_DemoFormulaire.WebApp.Handlers;
using NetSecu_DemoFormulaire.WebApp.Models;
using System.Diagnostics;

namespace NetSecu_DemoFormulaire.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, SessionManager sessionManager)
        {
            _logger = logger;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            ViewBag.User = _sessionManager.CurrentUser;
             return View();
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