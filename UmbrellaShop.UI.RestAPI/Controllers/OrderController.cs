using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UmbrellaShop.Core.ApplicationService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService service;
        public OrderController(IOrderService service){
            this.service = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return service.GetOrder();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return service.getOrderByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Order Order)
        {
            service.CreateOrder(Order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order Order)
        {
            service.UpdateOrder(id, Order);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteOrder(id);
        }
    }
}