using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UI.Models;
using Newtonsoft.Json.Linq;

namespace UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    static readonly HttpClient client = new HttpClient();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [Authorize(Policy = "Subscribers")] 
    public IActionResult Profile()
    {
        return View();
    }

     public IActionResult Components()
    {
        return View();
    }
    
    [Authorize(Policy = "Administrator")] 
     public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult Matriculas()
    {
        return View();
    }
    public IActionResult RoutineCreation()
    {
        return View();
    }

    public IActionResult LinkExerciseRoutine()
    {
        return View();
    }

    public IActionResult UnlinkExerciseRoutine()
    {
        return View();
    }

    public IActionResult ExerciseRegister()
    {
        try
        {
            Task<string> response = fetch("http://localhost:5049/api/ExerciseBase/RetrieveAll");  
            Console.WriteLine("Testing");
            Console.WriteLine(response.Result);
            ViewBag.excerciseBase = JArray.Parse(response.Result);

            Task<string> response2 = fetch("http://localhost:5049/api/Machine/RetrieveAll");  
            Console.WriteLine(response2.Result);
            ViewBag.machineList = JArray.Parse(response2.Result);
            
            return View();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    

 
    }

    

    public IActionResult RoutineDelete()
    {
        return View();
    }

    public IActionResult RoutineUpdate()
    {
        return View();
    }

    public IActionResult ExerciseDelete()
    {
        return View();
    }

    public IActionResult ExerciseUpdate()
    {
         try
        {
            Task<string> response = fetch("http://localhost:5049/api/ExerciseBase/RetrieveAll");  
            Console.WriteLine("Testing");
            Console.WriteLine(response.Result);
            ViewBag.excerciseBase = JArray.Parse(response.Result);

            Task<string> response2 = fetch("http://localhost:5049/api/Machine/RetrieveAll");  
            Console.WriteLine(response2.Result);
            ViewBag.machineList = JArray.Parse(response2.Result);
            
            return View();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
   /*
    public IActionResult ExerciseBaseList()
    {
        try
        {
            Task<string> response = fetch("http://localhost:5049/api/ExerciseBase/RetrieveAll");  
            ViewBag.excerciseBase = JArray.Parse(response.Result);
            Console.WriteLine(response.Result);
            return View();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            return RedirectToAction("Index", "Home");
        }
    }
*/
    private async Task<string>  fetch(string url){
        using HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }



}
