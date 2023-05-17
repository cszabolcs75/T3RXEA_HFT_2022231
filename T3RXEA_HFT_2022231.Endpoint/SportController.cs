using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public SportController(ISportLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("SportCreated", sport.Id, sport.Name, sport.Description, sport.IsOlimpic, sport.Inventor);
        }
        [HttpPut]
        public void Put([FromBody] Sport sport)
        {
            sl.UpdateSport(sport.Id, sport.Name, sport.Description, sport.IsOlimpic, sport.Inventor);
            hub.Clients.All.SendAsync("SportUpdated", sport.Id, sport.Name, sport.Description, sport.IsOlimpic, sport.Inventor);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var sport= this.sl.ReadSport(id);
            sl.DeleteSport(id);
            hub.Clients.All.SendAsync("SportDeleted", sport);
        }
    }
}
