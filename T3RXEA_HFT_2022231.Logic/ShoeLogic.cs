using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;
using T3RXEA_HFT_2022231.Repository;

namespace T3RXEA_HFT_2022231.Logic
{
    public class ShoeLogic : IShoeLogic
    {
        IShoeRepository ShoeRepository;
        public ShoeLogic(IShoeRepository shoeRepository)
        {
            ShoeRepository = shoeRepository;
        }

        public void CreateShoe(int Id, int BrandId, int SportId, int Prize, string Name)
        {
            if (String.IsNullOrEmpty(Id.ToString()) || String.IsNullOrEmpty(BrandId.ToString()) || String.IsNullOrEmpty(SportId.ToString()) || String.IsNullOrEmpty(Prize.ToString()) || Name == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                var HasItem = from shoes in ShoeRepository.GetAll() where shoes.Id == Id select shoes.Id;

                if (HasItem.Count() > 0)
                {
                    throw new ArgumentException("Already Exist");
                }
                else
                {
                    ShoeRepository.CreateShoe(Id, BrandId, SportId, Prize, Name);
                }
            }
        }

        public void DeleteShoe(int Id)
        {
            try
            {
                ReadShoe(Id);
                ShoeRepository.DeleteShoe(Id);
            }
            catch (Exception)
            {

                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Shoe> LowerThan(int max)
        {
            var q1 = from shoe in ShoeRepository.GetAll()
                     where shoe.Prize < max
                     select new { shoe.Id, shoe.BrandId, shoe.SportId, shoe.Prize, shoe.Name };

            List<Shoe> list = new List<Shoe>();

            foreach (var item in q1)
            {
                list.Add(new Shoe()
                { Id = item.Id, BrandId = item.BrandId, Name = item.Name, SportId = item.SportId, Prize = item.Prize });
            }
            return list;

        }

        public IEnumerable<Shoe> MadeBy(int brandid)
        {
            var q1 = from shoe in ShoeRepository.GetAll()
                     where shoe.BrandId==brandid
                     select new { shoe.Id, shoe.BrandId, shoe.SportId, shoe.Prize, shoe.Name };

            List<Shoe> list = new List<Shoe>();

            foreach (var item in q1)
            {
                list.Add(new Shoe()
                { Id = item.Id, BrandId = item.BrandId, Name = item.Name, SportId = item.SportId, Prize = item.Prize });
            }
            return list;
        }

        public IQueryable<Shoe> ReadAllShoe()
        {
            return ShoeRepository.ReadAllShoe();
        }

        public Shoe ReadShoe(int Id)
        {
            var HasItem = from shoes in ShoeRepository.GetAll() where shoes.Id == Id select shoes.Id;

            if (HasItem.Count() > 0)
            {
                return ShoeRepository.ReadShoe(Id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

      

        public void UpdateShoe(int Id, int BrandId, int SportId, int Prize, string Name)
        {
            if (String.IsNullOrEmpty(Id.ToString()) || String.IsNullOrEmpty(BrandId.ToString()) || String.IsNullOrEmpty(SportId.ToString()) || String.IsNullOrEmpty(Prize.ToString()) || Name == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                try
                {
                    ReadShoe(Id);
                    ShoeRepository.UpdateShoe(Id, BrandId, SportId, Prize, Name);
                }
                catch (Exception)
                {

                    throw new KeyNotFoundException();
                }
            }
        }
    }
}
