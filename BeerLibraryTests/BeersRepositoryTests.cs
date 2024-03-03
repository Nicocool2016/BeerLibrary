using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibrary.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {
        [TestMethod()]
        public void GetBeer()
        {            
            var repository = new BeersRepository();                        
            var beers = repository.Get();                        
            Assert.AreEqual(5, beers.Count);
        }

        [TestMethod()]
        public void AddBeer()
        {           
            var repository = new BeersRepository();
            var newBeer = new Beer(6, "New Beer", 5.5);
            var addedBeer = repository.Add(newBeer);
            Assert.AreEqual(newBeer, addedBeer);
            Assert.AreEqual(6, repository.Get().Count);
        }


        [TestMethod()]
        public void DeleteBeer()
        {           
            var repository = new BeersRepository();            
            var deletedBeer = repository.Delete(1);            
            Assert.IsNotNull(deletedBeer);
            Assert.AreEqual(4, repository.Get().Count);
        }

    }
}