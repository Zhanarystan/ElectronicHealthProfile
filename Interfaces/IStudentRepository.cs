using ElectronicHealthProfile.Entities;

namespace ElectronicHealthProfile.Interfaces;

public interface IStudentRepository
{
    Task<Student> GetStudent(Guid id);
    Task<IEnumerable<Student>> ListStudent();
    Task<Student> CreateStudent(Student student);
    Task<Student> UpdateStudent(Student student);
    Task<int> RemoveStudent(Student student);
}
