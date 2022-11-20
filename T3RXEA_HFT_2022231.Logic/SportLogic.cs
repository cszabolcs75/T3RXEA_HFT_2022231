using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3RXEA_HFT_2022231.Models;
using T3RXEA_HFT_2022231.Repository;

namespace T3RXEA_HFT_2022231.Logic
{
    public class SportLogic : ISportLogic
    {
        ISportRepository SportRepository;
        public SportLogic(ISportRepository sportRepository)
        {
            SportRepository = sportRepository;
        }

        public void CreateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor)
        {
            if (String.IsNullOrEmpty(Id.ToString()) || Name == null || Description == null || String.IsNullOrEmpty(IsOlimpic.ToString()) || Inventor == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                var HasItem = from sports in SportRepository.GetAll() where sports.Id == Id select sports.Id;

                if (HasItem.Count() > 0)
                {
                    throw new ArgumentException("Already Exist");
                }
                else
                {
                    SportRepository.CreateSport(Id, Name, Description, IsOlimpic, Inventor);
                }
            }
        }

        public void DeleteSport(int Id)
        {
            try
            {
                ReadSport(Id);
                SportRepository.DeleteSport(Id);
            }
            catch (Exception)
            {

                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Sport> OlimpicSport()
        {
            var q1 = from sport in SportRepository.GetAll()
                     where sport.IsOlimpic
                     select new { sport.Id, sport.Name, sport.Description, sport.IsOlimpic, sport.Inventor };

            List<Sport> list = new List<Sport>();

            foreach (var item in q1)
            {
                list.Add(new Sport()
                { Id = item.Id, Description = item.Description, Name = item.Name, IsOlimpic = item.IsOlimpic, Inventor = item.Inventor });
            }
            return list;
        }

        public IQueryable<Sport> ReadAllSport()
        {
            return SportRepository.ReadAllSport();
        }

        public Sport ReadSport(int Id)
        {
            var HasItem = from sports in SportRepository.GetAll() where sports.Id == Id select sports.Id;

            if (HasItem.Count() > 0)
            {
                return SportRepository.ReadSport(Id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void UpdateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor)
        {
            if (String.IsNullOrEmpty(Id.ToString()) || Name == null || Description == null || String.IsNullOrEmpty(IsOlimpic.ToString()) || Inventor == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                try
                {
                    ReadSport(Id);
                    SportRepository.UpdateSport(Id, Name, Description, IsOlimpic, Inventor);
                }
                catch (Exception)
                {

                    throw new KeyNotFoundException();
                }
            }
        }
    }
}
