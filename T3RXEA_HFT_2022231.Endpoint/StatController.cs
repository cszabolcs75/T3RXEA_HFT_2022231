using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using T3RXEA_HFT_2022231.Logic;
using T3RXEA_HFT_2022231.Models;
namespace T3RXEA_HFT_2022231.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBrandLogic bl;
        IShoeLogic shl;
        ISportLogic spl;

        public StatController(IBrandLogic bl, IShoeLogic shl, ISportLogic spl)
        {
            this.bl = bl;
            this.shl = shl;
            this.spl = spl;
        }
        [HttpGet]
        public IEnumerable<Brand> OwnerIs(string owner_name) {
            return bl.OwnerIs(owner_name);
        }
        [HttpGet]
        public IEnumerable<Brand> SportIs(int sportid) 
        {
           return bl.SportIs(sportid);
        }
        [HttpGet]
        public IEnumerable<Shoe> LowerThan(int max) 
        {
            return shl.LowerThan(max);
        }
        [HttpGet]
        public IEnumerable<Shoe> MadeBy(int brandid) 
        {
            return shl.MadeBy(brandid);
        }
        [HttpGet]
        public IEnumerable<Sport> OlimpicSport() 
        {
            return spl.OlimpicSport();
        }
    }
}
