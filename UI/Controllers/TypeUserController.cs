using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UI.Models;

namespace UI.Controllers;

public class TypeUserController : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }

    public IActionResult GetById()
    {
        return View();
    }

    public IActionResult GetAll()
    {
        return View();
    }
}
