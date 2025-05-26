using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Models;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Data;

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NexaWorksContext _context;

        public HomeController(ILogger<HomeController> logger, NexaWorksContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
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

    public class QueryExecutionRequest
    {
        public string QueryId { get; set; } = null!;
        public List<string> Parameters { get; set; } = new();
    }
}
