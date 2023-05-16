using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using T3RXEA_HFT_2022231.Logic;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;
        IHubContext<SignalRHub> hub;
        public BrandController(IBrandLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return bl.ReadAllBrand();
        }
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return bl.ReadBrand(id);
        }
        [HttpPost]
        public void Post([FromBody] Brand brand)
        {
            bl.CreateBrand(brand.Id, brand.SuggestedSportId, brand.Name, brand.Manufacturer, brand.Owner);
            hub.Clients.All.SendAsync("BrandCreated", brand.Id, brand.SuggestedSportId, brand.Name, brand.Manufacturer, brand.Owner);
        }
        [HttpPut]
        public void Put([FromBody] Brand brand)
        {
            bl.UpdateBrand(brand.Id, brand.SuggestedSportId, brand.Name, brand.Manufacturer, brand.Owner);
            hub.Clients.All.SendAsync("BrandUpdated", brand.Id, brand.SuggestedSportId, brand.Name, brand.Manufacturer, brand.Owner);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brand = this.bl.ReadBrand(id);
            bl.DeleteBrand(id);
            hub.Clients.All.SendAsync("BrandDeleted", brand);
        }
    }
}
