using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using T3RXEA_HFT_2022231.Logic;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        IShoeLogic sl;

        public ShoeController(IShoeLogic sl)
        {
            this.sl = sl;
        }

        [HttpGet]
        public IEnumerable<Shoe> Get()
        {
            return sl.ReadAllShoe();
        }
        [HttpGet("{id}")]
        public Shoe Get(int id)
        {
            return sl.ReadShoe(id);
        }
        [HttpPost]
        public void Post([FromBody] Shoe shoe)
        {
            sl.CreateShoe(shoe.Id, shoe.BrandId, shoe.SportId, shoe.Prize, shoe.Name);
        }
        [HttpPut]
        public void Put([FromBody] Shoe shoe)
        {
            sl.UpdateShoe(shoe.Id, shoe.BrandId, shoe.SportId, shoe.Prize, shoe.Name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.DeleteShoe(id);

        }
    }
}
