using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentCqrsApiProject.Features.Students.Commands;
using StudentCqrsApiProject.Features.Students.Queries;

namespace StudentCqrsApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));
            return Ok(result);
        }
    }
}

