using Microsoft.AspNetCore.Mvc;
using CollegeApi.Models;
using CollegeApi.Services;

namespace CollegeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService           _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService service, ILogger<StudentController> logger)
        {
            _service = service;
            _logger  = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GET all students");
            var students = await _service.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("GET student {Id}", id);
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound(new { message = $"Student {id} not found" });
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            _logger.LogInformation("POST create student {Name}", student.Name);
            var created = await _service.CreateAsync(student);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (id != student.Id) return BadRequest(new { message = "ID mismatch" });
            _logger.LogInformation("PUT update student {Id}", id);
            var updated = await _service.UpdateAsync(student);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("DELETE student {Id}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}