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
                    
                    // Define the folder path to save the image
                    var folderPath = Path.Combine("../UI/wwwroot", "images-app-gym");

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
                return Ok(ResponseHelper.Success<ClassActivityDTO>(classActivityDTO, "got user"));
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
            return Ok(_manager.RetrieveAll());
        }

        [HttpGet("{id}")]
        public IActionResult RetrieveById(int id)
        {
            return Ok(_manager.RetrieveById(id));
        }

        [HttpPut]
        public IActionResult Update(ClassActivityDTO classActivity)
        {
            _manager.Update(classActivity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return Ok();
        }
    }
}
