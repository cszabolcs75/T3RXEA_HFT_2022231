using System;
using T3RXEA_HFT_2022231.Models;

namespace T3RXEA_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:2286");
            while (true)
            {
                Console.WriteLine("Which table do you want to use?. (Accepted keywords: Sport, Brand, Shoe, NONCRUD)");
                string inp = Console.ReadLine();
                while (inp != "Sport" && inp != "Brand" && inp != "Shoe" && inp != "NONCRUD")
                {
                    Console.WriteLine("Wrong keyword!");
                    Console.WriteLine("Which table do you want to use?. (Accepted keywords: Sport, Brand, Shoe, NONCRUD)");
                    inp = Console.ReadLine();
                }
                string function;
                if (inp == "NONCRUD")
                {
                    function = "Other";
                }
                else
                {
                    Console.WriteLine("What kind of function do you want to test?(Accepted keywords: Read, ReadAll, Create, Delete, Update)");
                    function = Console.ReadLine();
                }

                while (function != "Read" && function != "ReadAll" && function != "Create" && function != "Delete" && function != "Update" && function != "Other")
                {
                    Console.WriteLine("Wrong keyword!");
                    Console.WriteLine("What kind of function do you want to test?(Accepted keywords: Read, ReadAll, Create, Delete, Update)");
                    function = Console.ReadLine();
                }
                int id;
                switch (inp)
                {
                    #region Sport functions
                    case "Sport":
                        switch (function)
                        {
                            case "Read":
                                Console.WriteLine("Give me an ID (1-3 exists by default)");
                                id = int.Parse(Console.ReadLine());
                                var sport = rest.GetSingle<Sport>("sport/" + id);
                                Console.WriteLine($"Name of sport: {sport.Name}, Description: {sport.Description}, Is Olimpic? {sport.IsOlimpic}, Inventor: {sport.Inventor}");
                                break;
                            case "ReadAll":
                                var sports = rest.Get<Sport>("sport");
                                Console.WriteLine("Content of sport table");
                                foreach (var item in sports)
                                {
                                    Console.WriteLine($"Name of sport: {item.Name}, Description: {item.Description}, Is Olimpic? {item.IsOlimpic}, Inventor: {item.Inventor}");
                                }
                                break;
                            case "Create":
                                Console.Write("Name of sport:");
                                string name = Console.ReadLine();
                                Console.Write("Description:");
                                string description = Console.ReadLine();
                                Console.Write("Is Olimpic?");
                                bool isolimpic = bool.Parse(Console.ReadLine());
                                Console.Write("Inventor:");
                                string inventor = Console.ReadLine();
                                rest.Post<Sport>(new Sport() { Name = name, Description = description, IsOlimpic = isolimpic, Inventor = inventor }, "sport");
                                Console.WriteLine("Added into the database");
                                break;
                            case "Delete":
                                Console.WriteLine("Give me an ID: ");
                                id = int.Parse(Console.ReadLine());
                                rest.Delete(id, "sport");
                                Console.WriteLine("Deleted!");
                                break;
                            case "Update":
                                Console.WriteLine("Give me an ID: ");
                                id = int.Parse(Console.ReadLine());
                                Console.Write("New name of the sport:");
                                string newsport_name = Console.ReadLine();
                                Console.Write("New description:");
                                string newdescription = Console.ReadLine();
                                Console.Write("New IsOlimpic:");
                                bool newisolimpic = bool.Parse(Console.ReadLine());
                                Console.Write("New inventor:");
                                string newinventor = Console.ReadLine();
                                rest.Put<Sport>(new Sport() { Id = id, Name = newsport_name, Description = newdescription, IsOlimpic = newisolimpic, Inventor = newinventor }, "sport");
                                Console.WriteLine("Updated in the database");
                                break;
                        }
                        break;
                    #endregion
                    #region Brand functions
                    case "Brand":
                        switch (function)
                        {
                            case "Read":
                                Console.WriteLine("Give me an ID (1-9 exists by default)");
                                id = int.Parse(Console.ReadLine());
                                var brand = rest.GetSingle<Brand>("brand/" + id);
                                Console.WriteLine($"SuggestedSportId :{brand.SuggestedSportId}, Name of the brand :{brand.Name}, Manufacturer: {brand.Manufacturer}, Owner: {brand.Owner}");
                                break;
                            case "ReadAll":
                                var brands = rest.Get<Brand>("brand");
                                Console.WriteLine("Content of the table:");
                                foreach (var item in brands)
                                {
                                    Console.WriteLine($"SuggestedSportId :{item.SuggestedSportId}, Name of the brand :{item.Name}, Manufacturer: {item.Manufacturer}, Owner: {item.Owner}");
                                }
                                break;
                            case "Create":
                                Console.Write("SuggestedSportId:");
                                int suggestedSportId = int.Parse(Console.ReadLine());
                                Console.Write("Name of the brand:");
                                string name = Console.ReadLine();
                                Console.Write("Manufacturer:");
                                string manufacturer = Console.ReadLine();
                                Console.WriteLine("Owner:");
                                string owner = Console.ReadLine();
                                rest.Post<Brand>(new Brand() { SuggestedSportId = suggestedSportId, Name = name, Manufacturer = manufacturer, Owner = owner }, "brand");
                                Console.WriteLine("Inserted into the datatable");
                                break;
                            case "Delete":
                                Console.WriteLine("Give me an ID: ");
                                id = int.Parse(Console.ReadLine());
                                rest.Delete(id, "brand");
                                Console.WriteLine("Deleted!");
                                break;
                            case "Update":
                                Console.WriteLine("Give me an ID: ");
                                id = int.Parse(Console.ReadLine());
                                Console.Write("SuggestedSportId: ");
                                int newsuggestedSportId = int.Parse(Console.ReadLine());
                                Console.Write("Name:");
                                string newname = Console.ReadLine();
                                Console.Write("Manufacturer:");
                                string newmanufacturer = Console.ReadLine();
                                Console.WriteLine("Owner:");
                                string newowner = Console.ReadLine();
                                rest.Put<Brand>(new Brand() { Id = id, SuggestedSportId = newsuggestedSportId, Name = newname, Manufacturer = newmanufacturer, Owner = newowner }, "brand");
                                Console.WriteLine("Updated!");
                                break;
                        }
                        break;
                    #endregion
                    #region Shoe functions
                    case "Shoe":
                        switch (function)
                        {
                            case "Read":
                                Console.WriteLine("Give me an ID (1-27 exists by default)");
                                id = int.Parse(Console.ReadLine());
                                var shoe = rest.GetSingle<Shoe>("shoe/" + id);
                                Console.WriteLine($"BrandId :{shoe.BrandId}, SportId:{shoe.SportId}, Prize: {shoe.Prize}, Name: {shoe.Name}");
                                break;
                            case "ReadAll":
                                var shoes = rest.Get<Shoe>("shoe");
                                Console.WriteLine("Content of the table:");
                                foreach (var item in shoes)
                                {
                                    Console.WriteLine($"BrandId :{item.BrandId}, SportId:{item.SportId}, Prize: {item.Prize}, Name: {item.Name}");
                                }
                                break;
                            case "Create":
                                Console.Write("BrandId:");
                                int brandId = int.Parse(Console.ReadLine());
                                Console.Write("SportId:");
                                int sportId = int.Parse(Console.ReadLine());
                                Console.Write("Prize:");
                                int prize = int.Parse(Console.ReadLine());
                                Console.WriteLine("Name:");
                                string name = Console.ReadLine();
                                rest.Post<Shoe>(new Shoe() { BrandId = brandId, SportId = sportId, Prize = prize, Name = name }, "shoe");
                                Console.WriteLine("Inserted into the datatable");
                                break;
                            case "Delete":
                                Console.WriteLine("Give me an ID: ");
                                id = int.Parse(Console.ReadLine());
                                rest.Delete(id, "shoe");
                                Console.WriteLine("Deleted!");
                                break;
                            case "Update":
                                Console.WriteLine("Give me an ID: ");
                                id = int.Parse(Console.ReadLine());
                                Console.Write("BrandId: ");
                                int newbrandId = int.Parse(Console.ReadLine());
                                Console.Write("SportId:");
                                int newsportId = int.Parse(Console.ReadLine());
                                Console.Write("Prize:");
                                int newprize = int.Parse(Console.ReadLine());
                                Console.WriteLine("Name:");
                                string newname = Console.ReadLine();
                                rest.Put<Shoe>(new Shoe() { BrandId = newbrandId, SportId = newsportId, Prize = newprize, Name = newname }, "shoe");
                                Console.WriteLine("Updated!");
                                break;
                        }
                        break;


                    #endregion
                    #region NON-CRUD 
                    case "NONCRUD":
                        Console.WriteLine("1 - LowerThanTest");
                        Console.WriteLine("2 - MadeByTest");
                        Console.WriteLine("3 - OlimpicSportTest");
                        Console.WriteLine("4 - OwnerIsTest");
                        Console.WriteLine("5 - SportIsTest");

                        Console.Write("Select a function (number):");
                        int funcnumb = int.Parse(Console.ReadLine());
                        while (funcnumb != 1 && funcnumb != 2 && funcnumb != 3 && funcnumb != 4 && funcnumb != 5)
                        {
                            Console.WriteLine("Wrong number!");
                            Console.Write("Select a function (number):");
                            funcnumb = int.Parse(Console.ReadLine());
                        }
                        switch (funcnumb)
                        {
                            case 1:
                                Console.Write("Lower price:");
                                int lowerprice = int.Parse(Console.ReadLine());
                                var LowerThanTest = rest.Get<Shoe>("stat/LowerThan/?lowerprice=" + lowerprice);
                                Console.WriteLine("Shoes with lower price:");
                                foreach (var item in LowerThanTest)
                                {
                                    Console.WriteLine($"BrandId :{item.BrandId}, SportId:{item.SportId}, Prize: {item.Prize}, Name: {item.Name}");
                                }
                                break;
                            case 2:
                                Console.WriteLine("This shoe is made by: ");
                                int madeby = int.Parse(Console.ReadLine());
                                var MadeByTest = rest.Get<Shoe>("stat/MadeBy/?madeby=" + madeby);
                                Console.WriteLine("The following shoe is made by:");
                                foreach (var item in MadeByTest)
                                {
                                    Console.WriteLine($"BrandId :{item.BrandId}, SportId:{item.SportId}, Prize: {item.Prize}, Name: {item.Name}");
                                }
                                break;
                            case 3:
                                Console.Write("Is this sport Olimpic? ");
                                var OlimpicSportTest = rest.Get<Sport>("stat/OlimpicSport/");
                                Console.WriteLine("The following sport is/is not Olimpic:");
                                foreach (var item in OlimpicSportTest)
                                {
                                    Console.WriteLine($"Name of sport: {item.Name}, Description: {item.Description}, Is Olimpic? {item.IsOlimpic}, Inventor: {item.Inventor}");
                                }
                                break;
                            case 4:
                                Console.Write("Owner of brand: ");
                                string owner = Console.ReadLine();
                                var OwnerIsTest = rest.Get<Brand>("stat/OwnerIs/?owner=" + owner);
                                Console.WriteLine("The following owner of the brand:");
                                foreach (var item in OwnerIsTest)
                                {
                                    Console.WriteLine($"SuggestedSportId :{item.SuggestedSportId}, Name of the brand :{item.Name}, Manufacturer: {item.Manufacturer}, Owner: {item.Owner}");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Sport of brand:");
                                int sport = int.Parse(Console.ReadLine());
                                var SportIsTest = rest.Get<Brand>("stat/SportIs/?sport=" + sport);
                                Console.WriteLine($"The following sport of the brand  {sport}:");
                                foreach (var item in SportIsTest)
                                {
                                    Console.WriteLine($"SuggestedSportId :{item.SuggestedSportId}, Name of the brand :{item.Name}, Manufacturer: {item.Manufacturer}, Owner: {item.Owner}");
                                }
                                break;


                        }
                        break;
                        #endregion
                }


            }

            ;
        }
    }
}
