using Microsoft.VisualStudio.TestTools.UnitTesting;
using Location_Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Location_Service.MvcControllers;

namespace Location_Service.Models.Tests
{
    [TestClass()]
    public class DbUtilitiesTests
    {
        [TestMethod()]
        public void PostLocationTest()
        {
            //ARRANGE
            DbUtilities dbu = new DbUtilities();
            Location l = new Location()
            {
                City = "Roskilde",
                District = "Roskilde komune",
                PostalCode = 4000,
                SurveyId = 23,
                Region = "Sjælland",
                LongtitudeCoords = 31.21312312,
                LatitudeCoords = 16.12312312
            };
            //ACT
            int a = dbu.PostLocation(l);
            //ASSERT
            Assert.AreEqual(7,a);
        }

        [TestMethod()]
        public void testingShit()
        {
            LocationMvcController l = new LocationMvcController();

            l.CreateLocation(4000, 23);
        }
    }
}