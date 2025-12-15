using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Data;
using StudentManagementApi.Models;

namespace StudentManagementApi.Controllers
{
    [ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(_context.Students.ToList());
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var s = _context.Students.Find(id);
        if (s == null) return NotFound();
        _context.Students.Remove(s);
        _context.SaveChanges();
        return Ok();
    }
}

}
