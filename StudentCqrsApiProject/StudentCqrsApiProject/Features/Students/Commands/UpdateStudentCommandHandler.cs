using MediatR;
using StudentCqrsApiProject.Models;
using StudentCqrsApiProject.Data;

namespace StudentCqrsApiProject.Features.Students.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IStudentRepository _repo;

        public UpdateStudentCommandHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Id = request.Id,
                Name = request.Student.Name,
                Age = request.Student.Age
            };

            _repo.UpdateStudent(student);
            return Task.FromResult(student);
        }
    }
}

