using Geometrie.DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Geometrie.DAL.Tests
{
    public class CercleControllerTest
    {
        private readonly Mock<GeometrieContext> _mockContext;
        private readonly CercleRepository _repository;

        public CercleControllerTest()
        {
            var mockSet = new Mock<DbSet<Cercle>>();
            var data = new List<Cercle>
            {
                new Cercle { Id = 1, X = 0, Y = 0, Rayon = 5, DateDeCreation = DateTime.Now },
                new Cercle { Id = 2, X = 1, Y = 1, Rayon = 10, DateDeCreation = DateTime.Now }
            }.AsQueryable();

            mockSet.As<IQueryable<Cercle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cercle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cercle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cercle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext = new Mock<GeometrieContext>();
            _mockContext.Setup(c => c.Cercles).Returns(mockSet.Object);

            _repository = new CercleRepository(_mockContext.Object);
        }

        [Fact]
        public void GetAllCercles_ReturnsAllCercles()
        {
            // Act
            var result = _repository.GetAllCercles();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetCercleById_ReturnsCercle()
        {
            // Act
            var result = _repository.GetCercleById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetCercleById_ReturnsNull_WhenIdDoesNotExist()
        {
            // Act
            var result = _repository.GetCercleById(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddCercle_AddsNewCercle()
        {
            // Arrange
            var newCercle = new Cercle_DAL(2, 2, 15);

            // Act
            _repository.AddCercle(newCercle);

            // Assert
            _mockContext.Verify(m => m.Cercles.Add(It.IsAny<Cercle>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void UpdateCercle_UpdatesExistingCercle()
        {
            // Arrange
            var updatedCercle = new Cercle_DAL(0, 0, 20) { Id = 1 };

            // Act
            _repository.UpdateCercle(1, updatedCercle);

            // Assert
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void DeleteCercle_RemovesCercle()
        {
            // Act
            _repository.DeleteCercle(1);

            // Assert
            _mockContext.Verify(m => m.Cercles.Remove(It.IsAny<Cercle>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void CalculerAireTotale_CalculatesTotalArea()
        {
            // Arrange
            var ids = new List<int> { 1, 2 };

            // Act
            var result = _repository.CalculerAireTotale(ids);

            // Assert
            Assert.Equal(Math.PI * 25 + Math.PI * 100, result, 2);
        }
    }
}