using DataAccessLayer.Interface;
using DataAccessLayer.Utility;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using RetailSkuApi.Models;
using RetailSkuAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RetailSkuTest.UnitTest
{
    public class LocationControllerTests
    {
        Mock<ILocationRepository> locationRepository;

        [SetUp]
        public void Setup()
        {
            locationRepository = new Mock<ILocationRepository>();
        }

        [Test]
        public async Task LocationController_GetAllLocation_ReturnLocations()
        {
            //Arrange
            IEnumerable<Location> lstLocation = new List<Location> { new Location { LocationId = 1, LocationName = "Test" }, new Location { LocationId = 2, LocationName = "Test1" } };
            locationRepository.Setup(x => x.GetAllLocations()).Returns(Task.FromResult(lstLocation));
            LocationController locationController = new LocationController(locationRepository.Object);

            //Act
            var result = await locationController.GetAllLocations();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
