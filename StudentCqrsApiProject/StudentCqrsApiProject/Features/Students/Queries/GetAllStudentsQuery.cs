using MediatR;
using StudentCqrsApiProject.Models;

namespace StudentCqrsApiProject.Features.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
}

