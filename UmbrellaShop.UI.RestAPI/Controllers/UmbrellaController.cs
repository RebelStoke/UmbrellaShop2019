using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UmbrellaShop.Core.ApplicationService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UmbrellaController : ControllerBase
    {
        IUmbrellaService service;
        public UmbrellaController(IUmbrellaService service){
            this.service = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Umbrella>> Get()
        {
            return service.GetUmbrellas();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Umbrella Get(int id)
        {
            return service.getUmbrellaByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Umbrella umbrella)
        {
            service.CreateUmbrella(umbrella);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Umbrella umbrella)
        {
            service.UpdateUmbrella(id, umbrella);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteUmbrella(id);
        }
    }
}