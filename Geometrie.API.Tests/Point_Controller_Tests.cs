using Geometrie.API.Controllers;
using Geometrie.DTO;
using Moq;

namespace Geometrie.API.Tests
{
    public class Point_Controller_Tests
    {
        //on test le constructeur et toutes les méthodes de Point_Controller en Moq de IPoint_Service
        [Fact]
        public void Point_Controller_Constructeur()
        {
            //arrange
            var service = new Mock<IPoint_Service>().Object;
            var controller = new Point_Controller(service);

            //assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void Point_Controller_Add()
        {
            //arrange
            var service = new Mock<IPoint_Service>();
            service.Setup(s => s.Add(It.IsAny<Point_DTO>())).Returns(new Point_DTO() { Id = 1, X = 2, Y = 3 });
            var controller = new Point_Controller(service.Object);

            var point = new Point_DTO() { Id = 0, X = 2, Y = 3 };

            //act
            var result = controller.Add(point);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
            service.Verify(s => s.Add(It.IsAny<Point_DTO>()), Times.Once);
        }

        [Fact]
        public void Point_Controller_DeleteObject()
        {
            //arrange
            var service = new Mock<IPoint_Service>();
            service.Setup(s => s.Delete(It.IsAny<Point_DTO>())).Returns(service.Object);
            var controller = new Point_Controller(service.Object);

            var point = new Point_DTO() { Id = 1, X = 2, Y = 3 };

            //act
            var result = controller.Delete(point);

            //assert
            Assert.NotNull(result);
            service.Verify(s => s.Delete(It.IsAny<Point_DTO>()), Times.Once);
        }

        [Fact]
        public void Point_Controller_DeleteById()
        {
            //arrange
            var service = new Mock<IPoint_Service>();
            service.Setup(s => s.Delete(It.IsAny<int>())).Returns(service.Object);
            var controller = new Point_Controller(service.Object);

            //act
            var result = controller.Delete(1);

            //assert
            Assert.NotNull(result);
            service.Verify(s => s.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Point_Controller_GetAll()
        {
            //arrange
            var service = new Mock<IPoint_Service>();
            service.Setup(s => s.GetAll()).Returns(new List<Point_DTO>() { new Point_DTO() { Id = 1, X = 2, Y = 3 }, new Point_DTO() { Id = 4, X = 5, Y = 6 } });
            var controller = new Point_Controller(service.Object);

            //act
            var result = controller.GetAll();

            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(2, result.ElementAt(0).X);
            Assert.Equal(3, result.ElementAt(0).Y);
            Assert.Equal(4, result.ElementAt(1).Id);
            Assert.Equal(5, result.ElementAt(1).X);
            Assert.Equal(6, result.ElementAt(1).Y);

            service.Verify(s => s.GetAll(), Times.Once);
        }

        [Fact]
        public void Point_Controller_GetById()
        {
            //arrange
            var service = new Mock<IPoint_Service>();
            service.Setup(s => s.GetById(It.IsAny<int>())).Returns(new Point_DTO() { Id = 1, X = 2, Y = 3 });
            var controller = new Point_Controller(service.Object);

            //act
            var result = controller.GetById(1);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);

            service.Verify(s => s.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Point_Controller_Update()
        {
            //arrange
            var service = new Mock<IPoint_Service>();
            service.Setup(s => s.Update(It.IsAny<Point_DTO>())).Returns(new Point_DTO() { Id = 1, X = 2, Y = 3 });
            var controller = new Point_Controller(service.Object);

            var point = new Point_DTO() { Id = 1, X = 2, Y = 3 };

            //act
            var result = controller.Update(point);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);

            service.Verify(s => s.Update(It.IsAny<Point_DTO>()), Times.Once);
        }


        [Fact]
        public void Point_Controller_CalculerDistanceById()
        {
            //arrange
            var service = new Mock<IPoint_Service>();
            service.Setup(s => s.CalculerDistance(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(1.0);
            var controller = new Point_Controller(service.Object);

            //act
            var result = controller.CalculerDistance(1, 2);

            //assert
            Assert.Equal(1.0, result);
            service.Verify(s => s.CalculerDistance(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }
    }
}