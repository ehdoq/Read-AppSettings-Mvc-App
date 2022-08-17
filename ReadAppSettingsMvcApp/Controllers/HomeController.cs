using Microsoft.AspNetCore.Mvc;
using ReadAppSettingsMvcApp.Models;
using System.Diagnostics;

namespace ReadAppSettingsMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CompanySettings()
        {
            CompanySettings cs = new();
            _configuration.GetSection("CompanySettings").Bind(cs);

            return View(cs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}