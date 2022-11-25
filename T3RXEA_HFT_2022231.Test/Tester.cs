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
       

    }
}
