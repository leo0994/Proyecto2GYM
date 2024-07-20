using DTOs;
using Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DTO.TypeExcercise;

namespace API.Controllers;
[ApiController]
//[Route("[controller]")]
[Route("api/[controller]")]
public class TypeExerciseController: ControllerBase
{
    private readonly TypeExerciseManager _TypeExerciseManager;

    public TypeExerciseController()
    {
        _TypeExerciseManager = new TypeExerciseManager();
    }

    //[HttpPost]
    [HttpPost("Create")]
    public IActionResult Create(TypeExerciseDTO typeExerciseDTO)
    {
        var result = _TypeExerciseManager.Create(typeExerciseDTO);
        return Ok(result);
    }


    [HttpGet("RetrieveAll")]
    public IActionResult RetrieveAll()
    {
        return Ok(_TypeExerciseManager.RetrieveAll());
    }

    [HttpGet("{id}")]
    public IActionResult RetrieveById(int id)
    {
        return Ok(_TypeExerciseManager.RetrieveById(id));
    }

    [HttpPut("Update")]
    public IActionResult Update(TypeExerciseDTO typeExerciseDTO)
    {
        _TypeExerciseManager.Update(typeExerciseDTO);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(TypeExerciseDTO typeExerciseDTO)
    {
        _TypeExerciseManager.Delete(typeExerciseDTO);
        return Ok();
    }    











}   
