using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Logic
{
    public interface IBrandLogic
    {
        void CreateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner);

        Brand ReadBrand(int Id);

        IQueryable<Brand> ReadAllBrand();

        void UpdateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner);

        void DeleteBrand(int Id);

        public IEnumerable<Brand> SportIs(int sportid);

        public IEnumerable<Brand> OwnerIs(string owner_name);
    }

    public interface IShoeLogic
    {
        void CreateShoe(int Id, int BrandId, int SportId, int Prize, string Name);

        Shoe ReadShoe(int Id);

        IQueryable<Shoe> ReadAllShoe();

        void UpdateShoe(int Id, int BrandId, int SportId, int Prize, string Name);

        void DeleteShoe(int Id);

        public IEnumerable<Shoe> LowerThan(int max);

        public IEnumerable<Shoe> MadeBy(int brandid);
    }

    public interface ISportLogic
    {
        void CreateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor);

        Sport ReadSport(int Id);

        IQueryable<Sport> ReadAllSport();

        void UpdateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor);

        void DeleteSport(int Id);

        public IEnumerable<Sport> OlimpicSport();
    }


}
