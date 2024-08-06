using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UI.Models;


namespace UI.Controllers;

public class DiscountsController : Controller
{
    //[Authorize(Policy = "Administrator")]
    public IActionResult Create()
    {
        return View();
    }
   // [Authorize(Policy = "Administrator")]
    public IActionResult Update()
    {
        return View();
    }
    //[Authorize(Policy = "Administrator")]
    public IActionResult Delete()
    {
        return View();
    }
    //[Authorize(Policy = "Administrator")]
    public IActionResult GetById()
    {
        return View();
    }
   // [Authorize(Policy = "Administrator")]
    public IActionResult GetAll()
    {
        return View();
    }
}
