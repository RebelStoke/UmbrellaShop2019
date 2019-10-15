using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UmbrellaShop.Core.ApplicationService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService service;
        public CustomerController(ICustomerService service){
            this.service = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return service.GetCustomer();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return service.getCustomerByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Customer Customer)
        {
            service.CreateCustomer(Customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer Customer)
        {
            service.UpdateCustomer(id, Customer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteCustomer(id);
        }
    }
}