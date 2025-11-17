using MediatR;
using StudentCqrsApiProject.Data;

namespace StudentCqrsApiProject.Features.Students.Commands
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepository _repo;

        public DeleteStudentCommandHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            _repo.DeleteStudent(request.Id);
            return Task.FromResult(true);
        }
    }
}

