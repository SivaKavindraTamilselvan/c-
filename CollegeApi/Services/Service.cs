using CollegeApi.Models;
using CollegeApi.Repositories;

namespace CollegeApi.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?>      GetByIdAsync(int id);
        Task<Student>       CreateAsync(Student student);
        Task<Student>       UpdateAsync(Student student);
        Task                DeleteAsync(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository      _repo;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repo, ILogger<StudentService> logger)
        {
            _repo   = repo;
            _logger = logger;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all students");
            var students = await _repo.GetAllAsync();
            _logger.LogInformation("Retrieved {Count} students", students.Count);
            return students;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Fetching student {Id}", id);
            var student = await _repo.GetByIdAsync(id);
            if (student == null)
                _logger.LogWarning("Student {Id} not found", id);
            return student;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            _logger.LogInformation("Creating student {Name}", student.Name);
            var created = await _repo.AddAsync(student);
            _logger.LogInformation("Student created with ID {Id}", created.Id);
            return created;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            _logger.LogInformation("Updating student {Id}", student.Id);
            var updated = await _repo.UpdateAsync(student);
            _logger.LogInformation("Student {Id} updated", student.Id);
            return updated;
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting student {Id}", id);
            var deleted = await _repo.DeleteAsync(id);
            if (deleted)
                _logger.LogInformation("Student {Id} deleted", id);
            else
                _logger.LogWarning("Student {Id} not found for delete", id);
        }
    }
}