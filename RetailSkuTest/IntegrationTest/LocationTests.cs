using DataAccessLayer.Interface;
using DataAccessLayer.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RetailSkuAPI.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RetailSkuTest.IntegrationTest
{
    public class LocationTests
    {

        ILocationRepository locationRepository;
        public IConfiguration configuration;

        [SetUp]
        public void SetUp()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            this.configuration = builder.Build();

            this.locationRepository = new LocationRepository(configuration);
        }

        [Test]
        public async Task GetAllLocationTest()
        {
            LocationController locationController = new LocationController(locationRepository);
            var result = await locationController.GetAllLocations();
            Assert.IsNotNull(result);
        }
    }
}
