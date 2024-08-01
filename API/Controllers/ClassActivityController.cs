using DTOs;
using Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassActivityController : ControllerBase
    {
        private readonly ClassActivityManager _manager;

        public ClassActivityController()
        {
            _manager = new ClassActivityManager();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ClassActivityRequest classActivity)
        {
            try
            {
                var classActivityDTO = new ClassActivityDTO();

                if (classActivity.Image != null)
                {
                    // var error = ResponseHelper.Error<ClassActivityRequest>("Image missed", classActivity);
                    // throw new ManagerException<ApiResponse<ClassActivityRequest>>(error);
                    
                   // Define the base path to the wwwroot folder in the UI project
                    var uiRootPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "UI", "wwwroot");

                    // Define the folder path to save the image
                    var folderPath = Path.Combine(uiRootPath, "images-app-gym");

                    // Ensure the folder exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Create a unique file name to avoid overwriting existing files
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(classActivity.Image.FileName);

                    // Combine the folder path with the unique file name
                    var filePath = Path.Combine(folderPath, uniqueFileName);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await classActivity.Image.CopyToAsync(fileStream);
                    }
                    var relativePath = Path.Combine("images-app-gym", uniqueFileName);
                    classActivityDTO.Image_url = relativePath;
                    Console.WriteLine($"File saved to: {relativePath}");
                }
                else
                {
                    classActivityDTO.Image_url = classActivity.Image_url;
                }
                
                classActivityDTO.Name = classActivity.Name;
                classActivityDTO.Description = classActivity.Description;
                classActivityDTO.Capacity = classActivity.Capacity;
                classActivityDTO.Instructor = classActivity.Coach;
                classActivityDTO.DayOfWeek = classActivity.Day;
                classActivityDTO.Hour = classActivity.Hour;
                _manager.Create(classActivityDTO);
                return Ok(ResponseHelper.Success<ClassActivityDTO>(classActivityDTO, "Activity created"));
            }
            catch (ManagerException<ApiResponse<ClassActivityRequest>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult RetrieveAll()
        {
            try
            {
                var response = _manager.RetrieveAll();
                return Ok(ResponseHelper.Success<List<ClassActivityDTO>>(response, "Getting all activities"));
            }
             catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Data);
            }
        }

        [HttpGet("{id}")]
        public IActionResult RetrieveById(int id)
        {
            return Ok(_manager.RetrieveById(id));
        }

        [HttpPut]
         public async Task<IActionResult> Update(ClassActivityRequest classActivity)
        {
            try
            {
                var classActivityDTO = new ClassActivityDTO();

                if (classActivity.Image != null)
                {
                    // var error = ResponseHelper.Error<ClassActivityRequest>("Image missed", classActivity);
                    // throw new ManagerException<ApiResponse<ClassActivityRequest>>(error);
                    
                   // Define the base path to the wwwroot folder in the UI project
                    var uiRootPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "UI", "wwwroot");

                    // Define the folder path to save the image
                    var folderPath = Path.Combine(uiRootPath, "images-app-gym");

                    // Ensure the folder exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    
                    // Create a unique file name to avoid overwriting existing files
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(classActivity.Image.FileName);

                    // Combine the folder path with the unique file name
                    var filePath = Path.Combine(folderPath, uniqueFileName);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await classActivity.Image.CopyToAsync(fileStream);
                    }
                    var relativePath = Path.Combine("images-app-gym", uniqueFileName);
                    classActivityDTO.Image_url = relativePath;
                    Console.WriteLine($"File saved to: {relativePath}");
                }
                else
                {
                    classActivityDTO.Image_url = classActivity.Image_url;
                }
                
                classActivityDTO.Id = (int) classActivity.Id;
                classActivityDTO.Name = classActivity.Name;
                classActivityDTO.Description = classActivity.Description;
                classActivityDTO.Capacity = classActivity.Capacity;
                classActivityDTO.Instructor = classActivity.Coach;
                classActivityDTO.DayOfWeek = classActivity.Day;
                classActivityDTO.Hour = classActivity.Hour;
                _manager.Update(classActivityDTO);

                return Ok(ResponseHelper.Success<ClassActivityDTO>(classActivityDTO, "Activity created"));
            }
            catch (ManagerException<ApiResponse<ClassActivityRequest>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                 _manager.Delete(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
