using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UI.Models;

namespace UI.Controllers;

public class Administration : Controller
{
    private readonly ILogger<Administration> _logger;

    public Administration(ILogger<Administration> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Policy = "Administrator")] 
    public IActionResult SignUp()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
