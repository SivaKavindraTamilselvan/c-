using Microsoft.EntityFrameworkCore;
using CollegeApi.Data;
using CollegeApi.Models;

namespace CollegeApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Database database;

        public StudentRepository(Database context)
        {
            database = context;
        }

        public async Task<List<Student>> GetAllAsync()
            => await database.Students.ToListAsync();

        public async Task<Student?> GetByIdAsync(int id)
            => await database.Students.FindAsync(id);

        public async Task<Student> AddAsync(Student student)
        {
            database.Students.Add(student);
            await database.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            database.Students.Update(student);
            await database.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await database.Students.FindAsync(id);
            if (student == null) return false;
            database.Students.Remove(student);
            await database.SaveChangesAsync();
            return true;
        }
    }
}