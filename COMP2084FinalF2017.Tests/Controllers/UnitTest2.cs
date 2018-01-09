using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using COMP2084FinalF2017.Controllers;
using Moq;
namespace COMP2084FinalF2017.Tests.Controllers
{

    [TestClass]
    public class UnitTest2
    {
        //globals
        CountriesController controller;
        Mock<icountryRepository> mock;
        List<Countries> country;

        [TestInitialize]
        public void TestInitialize()
        {
            // arrange
            mock = new Mock<icountery>();

            // mock table1 data
            country = new List<Countries>
            {
                new Countries {}
            };


            //add Table1 data to the mock object
            mock.Setup(m => m.Countries).Returns(country.AsQueryable());
            // pass the mock to the controller
            controller = new CountriesController(mock.Object);
        }
        [TestMethod]
        public void IndexLoadsValid()
        {


            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexShowsValidTable1()
        {
            //act
            var actual = (List<Country>)controller.Index().Model;

            //assert
            CollectionAssert.AreEqual(country, actual);
        }

        [TestMethod]
        public void DetailsValidTable1()
        {
            //act 
            var actual = ()controller.Details(1).Model;

            //assert
            Assert.AreEqual(country.ToList()[0], actual);

        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            //act 
            ViewResult actual = controller.Details(4);

            //assert
            Assert.AreEqual("Error", actual.ViewName);

        }
        [TestMethod]
        public void DetailsInvalidNoId()
        {
            //act 
            ViewResult actual = controller.Details(null);

            //assert
            Assert.AreEqual("Error", actual.ViewName);

        }
        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            //act
            ViewResult actual = controller.DeleteConfirmed(null);

            //assert
            Assert.AreEqual("Error", actual.ViewName);

        }
        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {

            //act
            ViewResult actual = controller.DeleteConfirmed(4);

            //assert
            Assert.AreEqual("Error", actual.ViewName);


        }
        [TestMethod]
        public void DeleteConfirmedValidId()
        {

            //act
            ViewResult actual = controller.DeleteConfirmed(1);

            //assert
            Assert.AreEqual("Index", actual.ViewName);


        }
    }
}

