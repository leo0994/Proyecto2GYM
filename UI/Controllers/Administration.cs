using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UI.Models;
using Newtonsoft.Json.Linq;

namespace UI.Controllers;

public class Administration : Controller
{
    private readonly ILogger<Administration> _logger;
    static readonly HttpClient client = new HttpClient();

    public Administration(ILogger<Administration> logger)
    {
        _logger = logger;
    }

    [Authorize(Policy = "Administrator")] 
    public IActionResult ManagementAppointments()
    {
        try
        {
            Task<string> response = fetch("http://localhost:5049/api/User/RetrieveAllCoaches");  
            ViewBag.coaches = JArray.Parse(response.Result);
            Console.WriteLine(response.Result);
            return View();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            return RedirectToAction("Index", "Home");
        }
    }

    private async Task<string> fetch(string url){
        using HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
