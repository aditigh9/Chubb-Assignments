using StudentCqrsApiProject.Models;

namespace StudentCqrsApiProject.Data
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Student> GetAllStudents();
    }
}

