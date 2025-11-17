using MediatR;

namespace StudentCqrsApiProject.Features.Students.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id) => Id = id;
    }
}

