using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using T3RXEA_HFT_2022231.Logic;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        ISportLogic sl;

        public SportController(ISportLogic sl)
        {
            this.sl = sl;
        }

        [HttpGet]
        public IEnumerable<Sport> Get()
        {
            return sl.ReadAllSport();
        }
        [HttpGet("{id}")]
        public Sport Get(int id)
        {
            return sl.ReadSport(id);
        }
        [HttpPost]
        public void Post([FromBody] Sport sport)
        {
            sl.CreateSport(sport.Id, sport.Name, sport.Description, sport.IsOlimpic, sport.Inventor);
        }
        [HttpPut]
        public void Put([FromBody] Sport sport)
        {
            sl.UpdateSport(sport.Id, sport.Name, sport.Description, sport.IsOlimpic, sport.Inventor);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.DeleteSport(id);

        }
    }
}
