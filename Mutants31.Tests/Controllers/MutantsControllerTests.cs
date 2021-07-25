using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mutants31.Controllers;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using FluentAssertions;

namespace Mutants31.Tests.Controllers
{
    [TestFixture]
    public class MutantsControllerTests : TestBase
    {
        [Test]
        public async Task IsMutant_WhenIsMutant_ReturnsOk()
        {
            //Arrange
            string dbName = Guid.NewGuid().ToString();
            ApplicationDBContext context = BuildContext(dbName);
            MutantsController controller = new MutantsController(context);

            //Act
            var result = controller.IsMutant(TestData._isMutant);
            var statusCode = result.Result as StatusCodeResult;

            var getContext = BuildContext(dbName);
            var count = await getContext.MutantsHistory.CountAsync();

            //Assert
            Assert.That(statusCode.StatusCode, Is.EqualTo(200));
            Assert.That(1, Is.EqualTo(count));
        }

        [Test]
        public async Task IsMutant_WhenIsNotMutant_ReturnsFordibben()
        {
            //Arrange
            string dbName = Guid.NewGuid().ToString();
            ApplicationDBContext context = BuildContext(dbName);
            MutantsController controller = new MutantsController(context);

            //Act
            var result = controller.IsMutant(TestData._isNotMutant);
            var statusCode = result.Result as StatusCodeResult;

            var getContext = BuildContext(dbName);
            var count = await getContext.MutantsHistory.CountAsync();

            //Assert
            Assert.That(statusCode.StatusCode, Is.EqualTo(403));
            Assert.That(1, Is.EqualTo(count));
        }

        [Test]
        public async Task GetMutantsHistory_WhenThereIsData_ReturnsCorrectStats()
        {
            //Arrange
            string dbName = Guid.NewGuid().ToString();
            ApplicationDBContext context = BuildContext(dbName);
            context.AddRange(TestData._mutants);
            await context.SaveChangesAsync();

            MutantsController controller = new MutantsController(BuildContext(dbName));

            //Act
            var result = await controller.GetMutantsHistory();
            var stats = result.Value;

            //Assert
            stats.Should().BeEquivalentTo(TestData._statsResult);
        }

        [Test]
        public async Task GetMutantsHistory_WhenThereIsNotData_ReturnsZero()
        {
            //Arrange
            ApplicationDBContext context = BuildContext(Guid.NewGuid().ToString());
            MutantsController controller = new MutantsController(context);

            //Act
            var result = await controller.GetMutantsHistory();
            var stats = result.Value;

            //Assert
            stats.Should().BeEquivalentTo(TestData._statsResultIsZero);
        }
    }
}
