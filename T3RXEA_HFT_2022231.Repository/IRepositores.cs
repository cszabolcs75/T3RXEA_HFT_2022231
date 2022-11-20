using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();

    }

    public interface IBrandRepository : IRepository<Brand>
    {
        void CreateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner);

        Brand ReadBrand(int Id);

        IQueryable<Brand> ReadAllBrand();

        void UpdateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner);

        void DeleteBrand(int Id);
    }

    public interface IShoeRepository : IRepository<Shoe>
    {
        void CreateShoe(int Id, int BrandId, int SportId, int Prize, string Name);

        Shoe ReadShoe(int Id);

        IQueryable<Shoe> ReadAllShoe();

        void UpdateShoe(int Id, int BrandId, int SportId, int Prize, string Name);

        void DeleteShoe(int Id);
    }

    public interface ISportRepository : IRepository<Sport>
    {
        void CreateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor);

        Sport ReadSport(int Id);

        IQueryable<Sport> ReadAllSport();

        void UpdateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor);

        void DeleteSport(int Id);
    }
}
