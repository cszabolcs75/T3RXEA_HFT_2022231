using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ShoeManamegementDBContext ctx):base(ctx)
        {
            
        }

        public void CreateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner)
        {
            Brand tmp = new Brand() { Id=Id, SuggestedSportId=SuggestedSportId, Name=Name, Manufacturer=Manufacturer, Owner=Owner};
            Create(tmp);
            ctx.SaveChanges();
        }

        public void DeleteBrand(int Id)
        {
            Delete(GetOne(Id));
            ctx.SaveChanges();
        }

        public override Brand GetOne(int Id)
        {
            return GetAll().SingleOrDefault(x => x.Id==Id);
        }

        public IQueryable<Brand> ReadAllBrand()
        {
            return (IQueryable<Brand>)GetAll();
        }

        public Brand ReadBrand(int Id)
        {
            return GetOne(Id);
        }

        public void UpdateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner)
        {
            var ToUpdate=GetOne(Id);
            ToUpdate.SuggestedSportId = SuggestedSportId;
            ToUpdate.Name = Name;
            ToUpdate.Manufacturer = Manufacturer;
            ToUpdate.Owner = Owner;
            ctx.SaveChanges();
        }
    }
}
