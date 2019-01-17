using System;
using System.Linq;
using AcCarPooling.Database;
using AcCarPooling.Models;
using AcCarPooling.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class JourneyTests
    {
        private IJourneyService _journeyService;
        CarPoolContext _carPoolContext;

        [SetUp]
        public void SetUp()
        {
            var dbContextOptions = new DbContextOptionsBuilder<CarPoolContext>()
                .UseInMemoryDatabase(databaseName:"TestDatabase")
                .Options;
            _carPoolContext = new CarPoolContext(dbContextOptions);
            _journeyService = new JourneyService(_carPoolContext);
        }

        [Test]
        public void TestNoJourneys()
        {
            var result = _journeyService.GetAllJourneys();

            Assert.IsEmpty(result);
        }

        [Test]
        public void TestJourneyAddsAndGetsAJourney()
        {
            var driver = new User()
            {
                Name = "Richard",
                From = "12345,54312"
            };

            var journey = new Journey()
            {
                Destination = "Hillington",
            };

            _journeyService.AddJourney(journey);

            var result = _journeyService.GetAllJourneys();

            Assert.Contains(journey, result.ToList());
        }


    }
}
