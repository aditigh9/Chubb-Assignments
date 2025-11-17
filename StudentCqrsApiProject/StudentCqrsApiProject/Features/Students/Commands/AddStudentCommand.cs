using MediatR;
using StudentCqrsApiProject.Models;
using StudentCqrsApiProject.Features.Students;

namespace StudentCqrsApiProject.Features.Students.Commands
{
    public class AddStudentCommand : IRequest<Student>
    {
        public StudentDto Student { get; set; }
        public AddStudentCommand(StudentDto student) => Student = student;
    }
}

