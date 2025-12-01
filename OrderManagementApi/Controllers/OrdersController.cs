using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.Data;
using OrderManagementApi.Models;

namespace OrderManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ---------------------------------------------------------
        // CREATE ORDER (POST)
        // ---------------------------------------------------------
        [Authorize]
        [HttpPost("place")]
        public IActionResult PlaceOrder(Order order)
        {
            order.UserName = User.Identity.Name;
            order.TotalAmount = order.Quantity * order.UnitPrice;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return Ok(new { message = "Order placed successfully" });
        }

        // ---------------------------------------------------------
        // READ ALL ORDERS (GET)
        // ---------------------------------------------------------
        [Authorize]
        [HttpGet("all")]
        public IActionResult GetAllOrders()
        {
            var userName = User.Identity.Name;

            var orders = _context.Orders
                .Where(o => o.UserName == userName)
                .ToList();

            return Ok(orders);
        }

        // ---------------------------------------------------------
        // UPDATE ORDER (PUT)
        // ---------------------------------------------------------
        [Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateOrder(int id, Order updatedOrder)
        {
            var userName = User.Identity.Name;

            var order = _context.Orders
                .FirstOrDefault(o => o.Id == id && o.UserName == userName);

            if (order == null)
                return NotFound(new { message = "Order not found or unauthorized" });

            order.ItemName = updatedOrder.ItemName;
            order.Quantity = updatedOrder.Quantity;
            order.UnitPrice = updatedOrder.UnitPrice;
            order.TotalAmount = updatedOrder.Quantity * updatedOrder.UnitPrice;

            _context.SaveChanges();

            return Ok(new { message = "Order updated successfully" });
        }

        // ---------------------------------------------------------
        // DELETE ORDER (DELETE)
        // ---------------------------------------------------------
        [Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var userName = User.Identity.Name;

            var order = _context.Orders
                .FirstOrDefault(o => o.Id == id && o.UserName == userName);

            if (order == null)
                return NotFound(new { message = "Order not found or unauthorized" });

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return Ok(new { message = "Order deleted successfully" });
        }
    }
}


