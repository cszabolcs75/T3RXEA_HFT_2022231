using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Repository
{
    public class ShoeRepository : Repository<Shoe>, IShoeRepository
    {
        public ShoeRepository(ShoeManamegementDBContext ctx) : base(ctx)
        {

        }

        public void CreateShoe(int Id, int BrandId, int SportId, int Prize, string Name)
        {
            Shoe tmp = new Shoe() { Id = Id, Name = Name, BrandId=BrandId, SportId=SportId, Prize=Prize};
            Create(tmp);
            ctx.SaveChanges();
        }

        public void DeleteShoe(int Id)
        {
            Delete(GetOne(Id));
            ctx.SaveChanges();
        }

        public override Shoe GetOne(int Id)
        {
            return GetAll().SingleOrDefault(x => x.Id == Id);
        }

        public IQueryable<Shoe> ReadAllShoe()
        {
            return (IQueryable<Shoe>)GetAll();
        }

        public Shoe ReadShoe(int Id)
        {
            return GetOne(Id);
        }

        public void UpdateShoe(int Id, int BrandId, int SportId, int Prize, string Name)
        {
            var ToUpdate = GetOne(Id);
            ToUpdate.Name = Name;
            ToUpdate.BrandId = BrandId;
            ToUpdate.SportId = SportId;
            ToUpdate.Prize = Prize;
            ctx.SaveChanges();
        }
    }
}
