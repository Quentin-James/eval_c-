namespace Geometrie.BLL.Tests
{
    public class PointTests
    {
        //Des TU xUnit pour la classe Point
        [Fact]
        public void Geometrie_BLL_Point_Constructor()
        {
            //Arrange
            //Act
            var point = new Point(1, 2);

            //Assert
            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
        }

        [Fact]
        public void Geometrie_BLL_Point_Constructor_With_Id()
        {
            //Arrange
            //Act
            var point = new Point(1, 2, 3);

            //Assert
            Assert.Equal(1, point.Id);
            Assert.Equal(2, point.X);
            Assert.Equal(3, point.Y);
        }

        [Fact]
        public void Geometrie_BLL_Point_Distance()
        {
            //Arrange
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 5);

            //Act
            var distance = point1.CalculerDistance(point2);

            //Assert
            Assert.Equal(4, distance);
        }

        //levée d'erreur ArgumentNullException sur CalculerDistance
        [Fact]
        public void Geometrie_BLL_Point_Distance_ArgumentNullException()
        {
            //Arrange
            var point1 = new Point(1, 1);
            Point point2 = null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => point1.CalculerDistance(point2));
        }

        //operateur ==
        [Fact]
        public void Geometrie_BLL_Point_Operator_Equal()
        {
            //Arrange
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 1);

            //Act
            var result = point1 == point2;

            //Assert
            Assert.True(result);
        }

        //operateur !=
        [Fact]
        public void Geometrie_BLL_Point_Operator_NotEqual()
        {
            //Arrange
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 2);

            //Act
            var result = point1 != point2;

            //Assert
            Assert.True(result);
        }
    }
}