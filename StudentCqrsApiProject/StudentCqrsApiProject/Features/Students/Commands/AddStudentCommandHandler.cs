using MediatR;
using StudentCqrsApiProject.Models;
using StudentCqrsApiProject.Data;

namespace StudentCqrsApiProject.Features.Students.Commands
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IStudentRepository _repo;

        public AddStudentCommandHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Student.Name,
                Age = request.Student.Age
            };

            _repo.AddStudent(student);
            return Task.FromResult(student);
        }
    }
}

