using HappyVacation.DTOs.Orders;
using HappyVacation.Repositories.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyVacation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOrder(CreateTourOrderRequest request)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var newOrderId = await _orderRepository.CreateOrder(userId, request);

                // get new order created
                var newOrder = await _orderRepository.GetOrderById(newOrderId);

                return CreatedAtAction(nameof(GetOrderById), new { orderId = newOrderId }, newOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }

        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult> GetUserOrders([FromQuery] string? state, int page, int perPage)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.GetUserOrders(userId, state, page, perPage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpGet("{orderId:int}")]
        public async Task<ActionResult> GetOrderById(int orderId)
        {
            try
            {
                var result = await _orderRepository.GetOrderById(orderId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }

        [HttpPut("{orderId:int}")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> ChangeOrderState(int orderId, [FromQuery] string state)
        {
            try
            {
                state = state.ToLower();
                if(!state.Equals("confirmed") && !state.Equals("canceled"))
                {
                    return BadRequest("Invalid state.");
                }

                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.ChangeOrderState(userId, orderId, state);
                if (result == -1)
                {
                    return Forbid();
                }
                if (result == 0)
                {
                    return BadRequest("Already in this state.");
                }

                var updatedOrder = await _orderRepository.GetOrderById(result);
                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
                return StatusCode(500);
            }
        }
    }
}
