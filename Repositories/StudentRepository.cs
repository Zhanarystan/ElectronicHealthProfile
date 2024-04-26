using ElectronicHealthProfile.Entities;

using ElectronicHealthProfile.Interfaces;
using ElectronicHealthProfile.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicHealthProfile.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly DataContext _context;

    public StudentRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Student> CreateStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> GetStudent(Guid id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task<IEnumerable<Student>> ListStudent()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<int> RemoveStudent(Student student)
    {
        _context.Students.Remove(student);
        return await _context.SaveChangesAsync();
    }

    public async Task<Student> UpdateStudent(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }
}
