using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using T3RXEA_HFT_2022231.Logic;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Endpoint
{
    [Route("[controller")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;

        public BrandController(IBrandLogic bl)
        {
            this.bl = bl;
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
        }
        [HttpPut]
        public void Put([FromBody] Brand brand)
        {
            bl.UpdateBrand(brand.Id, brand.SuggestedSportId, brand.Name, brand.Manufacturer, brand.Owner);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.DeleteBrand(id);

        }
    }
}
