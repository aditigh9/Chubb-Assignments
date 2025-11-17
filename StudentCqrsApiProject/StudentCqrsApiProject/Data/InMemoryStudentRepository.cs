using StudentCqrsApiProject.Models;

using StudentCqrsApiProject.Models;

namespace StudentCqrsApiProject.Data
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new();
        private int _idCounter = 1;

        public void AddStudent(Student student)
        {
            student.Id = _idCounter++;
            _students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Age = student.Age;
            }
        }

        public void DeleteStudent(int id)
        {
            var st = _students.FirstOrDefault(s => s.Id == id);
            if (st != null)
                _students.Remove(st);
        }

        public List<Student> GetAllStudents() => _students;
    }
}

