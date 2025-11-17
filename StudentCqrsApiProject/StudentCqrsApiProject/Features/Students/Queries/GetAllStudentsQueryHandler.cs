using MediatR;
using StudentCqrsApiProject.Models;
using StudentCqrsApiProject.Data;

namespace StudentCqrsApiProject.Features.Students.Queries
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IStudentRepository _repo;

        public GetAllStudentsQueryHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repo.GetAllStudents());
        }
    }
}

