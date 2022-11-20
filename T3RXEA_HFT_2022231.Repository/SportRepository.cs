using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Repository
{
    public class SportRepository : Repository<Sport>, ISportRepository
    {
        public SportRepository(ShoeManamegementDBContext ctx) : base(ctx)
        {

        }

        public void CreateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor)
        {
            Sport tmp = new Sport() { Id = Id, Name = Name, Description=Description, IsOlimpic=IsOlimpic, Inventor=Inventor };
            Create(tmp);
            ctx.SaveChanges();
        }

        public void DeleteSport(int Id)
        {
            Delete(GetOne(Id));
            ctx.SaveChanges();
        }

        public override Sport GetOne(int Id)
        {
            return GetAll().SingleOrDefault(x => x.Id == Id);
        }

        public IQueryable<Sport> ReadAllSport()
        {
            return (IQueryable<Sport>)GetAll();
        }

        public Sport ReadSport(int Id)
        {
            return GetOne(Id);
        }

        public void UpdateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor)
        {
            var ToUpdate = GetOne(Id);
           ToUpdate.Name = Name;
            ToUpdate.Description = Description;
            ToUpdate.IsOlimpic = IsOlimpic;
            ToUpdate.Inventor = Inventor;
            ctx.SaveChanges();
        }
    }
}
