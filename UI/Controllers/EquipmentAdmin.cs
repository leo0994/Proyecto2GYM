using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UI.Models;

namespace UI.Controllers
{
    public class EquipmentAdmin : Controller
    {
        private readonly ILogger<EquipmentAdmin> _logger;
        static readonly HttpClient client = new HttpClient();

        public EquipmentAdmin(ILogger<EquipmentAdmin> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Equipment()
        {
            return View();
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Update()
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