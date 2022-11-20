using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;
using T3RXEA_HFT_2022231.Repository;

namespace T3RXEA_HFT_2022231.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository BrandRepository;
        public BrandLogic(IBrandRepository brandRepository)
        {
            BrandRepository = brandRepository;
        }

        public void CreateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner)
        {
            if (String.IsNullOrEmpty(Id.ToString()) || String.IsNullOrEmpty(SuggestedSportId.ToString()) || Name==null || Manufacturer==null || Owner==null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                var HasItem=from brands in BrandRepository.GetAll() where brands.Id == Id select brands.Id;

                if (HasItem.Count()>0)
                {
                    throw new ArgumentException("Already Exist");
                }
                else
                {
                    BrandRepository.CreateBrand(Id, SuggestedSportId, Name, Manufacturer, Owner);
                }
            }
        }

        public void DeleteBrand(int Id)
        {
            try
            {
                ReadBrand(Id);
                BrandRepository.DeleteBrand(Id);
            }
            catch (Exception)
            {

                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Brand> OwnerIs(string owner_name)
        {
            var q1 = from brand in BrandRepository.GetAll() where brand.Owner == owner_name 
                     select new { brand.Id, brand.SuggestedSportId, brand.Name, brand.Manufacturer, brand.Owner };

            List<Brand> list = new List<Brand>();

            foreach (var item in q1)
            {
                list.Add(new Brand() 
                { Id = item.Id, SuggestedSportId = item.SuggestedSportId, Name = item.Name, Manufacturer = item.Manufacturer, Owner = item.Owner });
            }
            return list;
        }

        public IQueryable<Brand> ReadAllBrand()
        {
            return BrandRepository.ReadAllBrand();
        }

        public Brand ReadBrand(int Id)
        {
            var HasItem = from brands in BrandRepository.GetAll() where brands.Id == Id select brands.Id;

            if (HasItem.Count()>0)
            {
                return BrandRepository.ReadBrand(Id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Brand> SportIs(int sportid)
        {
            var q1 = from brand in BrandRepository.GetAll()
                     where brand.SuggestedSportId == sportid
                     select new { brand.Id, brand.SuggestedSportId, brand.Name, brand.Manufacturer, brand.Owner };

            List<Brand> list = new List<Brand>();

            foreach (var item in q1)
            {
                list.Add(new Brand()
                { Id = item.Id, SuggestedSportId = item.SuggestedSportId, Name = item.Name, Manufacturer = item.Manufacturer, Owner = item.Owner });
            }
            return list;
        }

        public void UpdateBrand(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner)
        {
            if (String.IsNullOrEmpty(Id.ToString()) || String.IsNullOrEmpty(SuggestedSportId.ToString()) || Name == null || Manufacturer == null || Owner == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                try
                {
                    ReadBrand(Id);
                    BrandRepository.UpdateBrand(Id, SuggestedSportId, Name, Manufacturer, Owner);
                }
                catch (Exception)
                {

                    throw new KeyNotFoundException();
                }
            }
        }
    }
}
