using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BeerLibrary.Tests
{
    [TestClass()]
    public class BeerTests
    {
        [TestMethod()]
        public void BeerTest()
        {            
            int id = 1;
            string name = "IPA";
            double abv = 6.5;

            var beer = new Beer(id, name, abv);
                       
            Assert.IsNotNull(beer);
            Assert.AreEqual(id, beer.Id);
            Assert.AreEqual(name, beer.Name);
            Assert.AreEqual(abv, beer.Abv);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            int id = 1;
            string name = "IPA";
            double abv = 6.5;
            var beer = new Beer(id, name, abv);

            var result = beer.ToString();
            Assert.AreEqual($"Beer: Id={id}, Name={name}, ABV={abv}", result);
        }

        [TestMethod()]
        public void ValidateIdTestInvalid()
        {
            int invalidId = -1;
            var beer = new Beer(invalidId, "IPA", 6.5);

           
            Assert.ThrowsException<ArgumentException>(() => beer.ValidateId());
        }

        [TestMethod()]
        public void ValidateNameTestInvalid()
        {
            string invalidName = "";
            var beer = new Beer(1, invalidName, 6.5);
                        
            Assert.ThrowsException<ArgumentException>(() => beer.ValidateName());
        }

        [TestMethod()]
        public void ValidateNameTestValid()
        {
            string validName = "IPA";
            var beer = new Beer(1, validName, 6.5);
            try
            {
                beer.ValidateName();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected exception was thrown.");
            }
        }
    }
}