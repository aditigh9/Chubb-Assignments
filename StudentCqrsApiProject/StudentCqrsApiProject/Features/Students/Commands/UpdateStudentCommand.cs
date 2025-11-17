using MediatR;
using StudentCqrsApiProject.Models;
using StudentCqrsApiProject.Features.Students;

namespace StudentCqrsApiProject.Features.Students.Commands
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public int Id { get; set; }
        public StudentDto Student { get; set; }

        public UpdateStudentCommand(int id, StudentDto student)
        {
            Id = id;
            Student = student;
        }
    }
}

