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
        public ActionResult<IEnumerable<Umbrella>> Get([FromQuery] Filter filter)
        {
            if (filter.CurrentPage == 0 || filter.ItemsPrPage == 0)
            {
                filter = null;
            }
            return service.GetUmbrellas(filter);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Umbrella Get(int id)
        {
            return service.getUmbrellaByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Umbrella> Post([FromBody] Umbrella umbrella)
        {
            if (umbrella.Brand == "")
            {
                return BadRequest("No brand provided");
            }
            foreach (var item in service.GetUmbrellas(null))
            {
                if (item.Id == umbrella.Id)
                {
                    return BadRequest("Wrong ID");
                }
            }
            return service.CreateUmbrella(umbrella);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Umbrella> Put(int id, [FromBody] Umbrella umbrella)
        {

            foreach (var item in service.GetUmbrellas(null))
            {
                if (item.Id == id)
                {
                    return service.UpdateUmbrella(id, umbrella);
                }
            }
            return BadRequest("Wrong Id");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Umbrella> Delete(int id)
        {
            return service.DeleteUmbrella(id);
        }
    }
}