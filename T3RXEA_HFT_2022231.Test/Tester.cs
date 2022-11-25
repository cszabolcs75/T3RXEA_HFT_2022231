using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using T3RXEA_HFT_2022231.Logic;
using T3RXEA_HFT_2022231.Models;
using T3RXEA_HFT_2022231.Repository;

namespace T3RXEA_HFT_2022231.Test
{
    [TestFixture]
    public class Tester
    {
        BrandLogic bl;
        ShoeLogic shl;
        SportLogic spl;
        [SetUp]
        public void SetUp() 
        {
            var mockBrandRepository = new Mock<IBrandRepository>();
            var mockShoeRepository = new Mock<IShoeRepository>();
            var MockSportRepository = new Mock<ISportRepository>();
            Sport fakesport = new Sport() {Id=1, Description="Faked", Inventor="Fake inv", IsOlimpic= true, Name="Fake sport"};
            Brand fakebrand = new Brand() { Id = 1, Manufacturer = "FakeM", Name = "FakeN", Owner = "FakeO", SuggestedSportId = 1 };
            var sportlist = new List<Sport> { fakesport}.AsQueryable();
            var brandlist = new List<Brand> { fakebrand }.AsQueryable();
            var shoelist = new List<Shoe> { new Shoe() {Id=1, BrandId= 1, SportId=1, Name="FakeS1", Prize=50 }, new Shoe() { Id =2, BrandId = 1, SportId = 1, Name = "FakeS2", Prize = 30 } }.AsQueryable();
            mockBrandRepository.Setup(t => t.GetAll()).Returns(brandlist);
            mockShoeRepository.Setup(s => s.GetAll()).Returns(shoelist);
            MockSportRepository.Setup(t => t.GetAll()).Returns(sportlist);
            bl = new BrandLogic(mockBrandRepository.Object);
            shl = new ShoeLogic(mockShoeRepository.Object);
            spl = new SportLogic(MockSportRepository.Object);
        }
        [TestCase(80, 1, null, "test", "test2")]
        public void BrandCreateTest(int Id, int SuggestedSportId, string Name, string Manufacturer, string Owner)
        {
            Assert.That(() => bl.CreateBrand(Id, SuggestedSportId, Name, Manufacturer, Owner), Throws.TypeOf<ArgumentException>());
        }
        [TestCase(90, 1, 1, 10, null)]
        public void CreateShoeTest(int Id, int BrandId, int SportId, int Prize, string Name)
        {
            Assert.That(() => shl.CreateShoe(Id, BrandId, SportId, Prize, Name), Throws.TypeOf<ArgumentException>());
        }
        [TestCase(100, null, "Test", true, "Test2")]
        public void CreateSport(int Id, string Name, string Description, bool IsOlimpic, string Inventor)
        {
            Assert.That(() => spl.CreateSport(Id, Name, Description, IsOlimpic, Inventor), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(1)]
        public void SportIsTest(int sportid)
        {
            Assert.That(() => bl.SportIs(sportid).ToList().Count(), Is.EqualTo(1));
        }

        [TestCase("Somebody")]
        public void OwnerIsTest(string owner_name)
        {
            Assert.That(() => bl.OwnerIs(owner_name).ToList().Count(), Is.EqualTo(0));
        }
        [TestCase(40)]
        public void LowerThanTest(int max)
        {
            Assert.That(() => shl.LowerThan(max).ToList().Count(), Is.EqualTo(1));
        }

        [TestCase(1)]
        public void MadeByTest(int brandid)
        {
            Assert.That(() => shl.MadeBy(brandid).ToList().Count(), Is.EqualTo(2));
        }

        [TestCase]
        public void OlimpicSportTester()
        {
            Assert.That(() => spl.OlimpicSport().ToList().Count(), Is.EqualTo(1));
        }

        

    }
}
