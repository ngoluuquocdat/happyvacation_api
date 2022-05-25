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

        //[HttpPost]
        //[Authorize]
        //public async Task<ActionResult> CreateOrderPayment(CreateTourOrderRequest request)
        //{
        //    try
        //    {
        //        var claimsPrincipal = this.User;
        //        var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

        //        // get payment url
        //        var paymentUrl = await _orderRepository.CreateOrderPayment(userId, request);

        //        return Ok(paymentUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(DateTime.Now + "- Server Error: " + ex);
        //        return StatusCode(500);
        //    }
        //}

        [HttpPatch("{orderId:int}/confirm-transaction")]
        [Authorize]
        public async Task<ActionResult> ConfirmOrderTransaction(int orderId, [FromQuery] string transactionId)
        {
            try
            {
                // get payment url
                var result = await _orderRepository.ConfirmOrderTransaction(orderId, transactionId);
                if(result == null)
                {
                    return BadRequest("Something wrong.");
                }

                return Ok(result);
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
        public async Task<ActionResult> GetOrderById(int orderId)   // this is for management (provider)
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


        [HttpGet("{orderId:int}/detail")]
        [Authorize]
        public async Task<ActionResult> GetOrderDetail(int orderId)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.GetOrderDetail(userId, orderId);
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

        [HttpGet("{orderId:int}/detail-manage")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> GetOrderDetailManage(int orderId)
        {
            try
            {
                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.GetOrderDetailManage(userId, orderId);
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

        [HttpPut("{orderId:int}/confirm")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> ConfirmOrder(int orderId)
        {
            try
            {

                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.ConfirmOrder(userId, orderId);
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

        [HttpPut("{orderId:int}/cancel")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> CancelOrder(int orderId)
        {
            try
            {

                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.CancelOrder(userId, orderId);
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

        [HttpPut("{orderId:int}/departure")]
        [Authorize(Roles = "Provider")]
        public async Task<ActionResult> ChangeDepartureDate(int orderId, [FromBody] ChangeDepartureDateRequest request)
        {
            try
            {

                var claimsPrincipal = this.User;
                var userId = Int32.Parse(claimsPrincipal.FindFirst("id").Value);

                var result = await _orderRepository.ChangeDepartureDate(userId, orderId, request.NewDate);
                if (result == -1)
                {
                    return Forbid();
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
