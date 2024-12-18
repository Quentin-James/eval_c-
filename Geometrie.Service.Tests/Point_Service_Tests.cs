using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DTO;
using Moq;

namespace Geometrie.Service.Tests
{
    public class Point_Service_Tests
    {
        [Fact]
        public void Point_Service_Constructeur()
        {
            //arrange
            var depot = new Moq.Mock<IDepot<Point>>().Object;
            var log_depot = new Mock<IDepot<Log>>().Object;
            var service = new Point_Service(depot, log_depot);

            //assert
            Assert.NotNull(service);
        }

        //méthode Add
        [Fact]
        public void Point_Service_Add()
        {
            //arrange
            //dans les tests unitaires, on ne teste pas la couche d'en dessous
            //on va la simuler avec un Moq
            //avec ce Moq je fais un "faux objet" depot
            //je n'utilise pas vraiment la couche BLL
            var depot = new Mock<IDepot<Point>>();
            var log_depot = new Mock<IDepot<Log>>();
            //je paramètre une fausse méthode Add pour mon faux dépot
            //la fausse méthode imite la vraie : elle prend un Point en paramètre et retourne un Point
            depot.Setup(d => d.Add(It.IsAny<Point>())).Returns(new Point(1, 2, 3));
            //je peux créer mon service avec le faux objet
            var service = new Point_Service(depot.Object, log_depot.Object);

            var point = new Point_DTO() { Id=0, X=2, Y=3 };

            //act
            var result = service.Add(point);

            //assert
            //je vérifie le résulat
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
            //et avec Moq, je peux vérifier qu'il a bien appelé la méthode Add du dépot
            //une fois et une seule
            depot.Verify(d => d.Add(It.IsAny<Point>()), Times.Once);
        }

        //méthode Delete
        [Fact]
        public void Point_Service_Delete()
        {
            //arrange
            var depot = new Mock<IDepot<Point>>();
            var log_depot = new Mock<IDepot<Log>>();
            depot.Setup(d => d.Delete(It.IsAny<int>())).Returns(depot.Object);
            var service = new Point_Service(depot.Object, log_depot.Object);

            var point = new Point_DTO() { Id = 1, X = 2, Y = 3 };

            //act
            var result = service.Delete(point);

            //assert
            Assert.NotNull(result);
            depot.Verify(d => d.Delete(It.IsAny<int>()), Times.Once);
        }

        //méthode delete avec un int
        [Fact]
        public void Point_Service_Delete_Id()
        {
            //arrange
            var depot = new Mock<IDepot<Point>>();
            var log_depot = new Mock<IDepot<Log>>();
            depot.Setup(d => d.Delete(It.IsAny<int>())).Returns(depot.Object);
            var service = new Point_Service(depot.Object, log_depot.Object);

            //act
            var result = service.Delete(1);

            //assert
            Assert.NotNull(result);
            depot.Verify(d => d.Delete(It.IsAny<int>()), Times.Once);
        }

        //update
        [Fact]
        public void Point_Service_Update()
        {
            //arrange
            var depot = new Mock<IDepot<Point>>();
            var log_depot = new Mock<IDepot<Log>>();
            depot.Setup(d => d.Update(It.IsAny<Point>())).Returns(new Point(1, 2, 3));
            var service = new Point_Service(depot.Object, log_depot.Object);

            var point = new Point_DTO() { Id = 1, X = 2, Y = 3 };

            //act
            var result = service.Update(point);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
            depot.Verify(d => d.Update(It.IsAny<Point>()), Times.Once);
        }
        [Fact]
        public void Point_Service_GetAll()
        {
            //arrange
            var depot = new Mock<IDepot<Point>>();
            var log_depot = new Mock<IDepot<Log>>();
            depot.Setup(d => d.GetAll()).Returns(new List<Point>() { new Point(1, 2, 3), new Point(4, 5, 6) });
            var service = new Point_Service(depot.Object, log_depot.Object);

            //act
            var result = service.GetAll();

            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(2, result.ElementAt(0).X);
            Assert.Equal(3, result.ElementAt(0).Y);
            Assert.Equal(4, result.ElementAt(1).Id);
            Assert.Equal(5, result.ElementAt(1).X);
            Assert.Equal(6, result.ElementAt(1).Y);
            depot.Verify(d => d.GetAll(), Times.Once);
        }
        [Fact]
        public void Point_Service_GetById()
        {
            //arrange
            var depot = new Mock<IDepot<Point>>();
            var log_depot = new Mock<IDepot<Log>>();
            depot.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Point(1, 2, 3));
            var service = new Point_Service(depot.Object, log_depot.Object);

            //act
            var result = service.GetById(1);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
            depot.Verify(d => d.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}