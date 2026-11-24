using Microsoft.AspNetCore.Mvc;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService orderService;
        public OrdersController(IOrdersService orderService)
        {
            this.orderService = orderService;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await orderService.GetAllOrders();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await orderService.GetOrderById(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            var createdOrder = await orderService.AddOrder(order);
            return CreatedAtAction(nameof(Get), new { id = createdOrder.Id }, createdOrder);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
