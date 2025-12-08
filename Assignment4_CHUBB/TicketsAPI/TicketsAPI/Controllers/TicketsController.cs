using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TicketsAPI.Models;

namespace TicketsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        // GET: api/tickets
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> Get()
        {
            var tickets = new List<Ticket>
            {
                new Ticket {
                    Id = 1,
                    ShortDescription = "Login fails",
                    Description = "User cannot login with correct credentials.",
                    CreatedDate = new DateTime(2025, 11, 20),
                    Severity = "High",
                    TargetDate = new DateTime(2025, 11, 25),
                    Status = "Open"
                },
                new Ticket {
                    Id = 2,
                    ShortDescription = "UI alignment issue",
                    Description = "Buttons overlap on small screens.",
                    CreatedDate = new DateTime(2025, 10, 05),
                    Severity = "Low",
                    TargetDate = new DateTime(2025, 12, 01),
                    Status = "In Progress"
                },
                new Ticket {
                    Id = 3,
                    ShortDescription = "Data mismatch",
                    Description = "Report totals not matching source DB.",
                    CreatedDate = new DateTime(2025, 09, 10),
                    Severity = "Medium",
                    TargetDate = new DateTime(2025, 11, 30),
                    Status = "Closed"
                }
            };

            return Ok(tickets);
        }
    }
}
