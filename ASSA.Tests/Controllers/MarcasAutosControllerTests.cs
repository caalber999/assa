using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using ASSA.Data;
using ASSA.Controllers;

namespace ASSA.Tests.Controllers
{
    public class MarcasAutosControllerTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "AutosDB")
            .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }
        [Fact]
        public async Task GetMarcasAutos_ReturnsCorrectData()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new MarcasAutosController(context);

            // Act
            var result = await controller.GetMarcasAutos();

            // Assert
            Assert.Equal(3, result.Value.Count());
            Assert.Contains(result.Value, m => m.Nombre == "Toyota");
            Assert.Contains(result.Value, m => m.Nombre == "Ford");
            Assert.Contains(result.Value, m => m.Nombre == "Chevrolet");
        }
    }
}
