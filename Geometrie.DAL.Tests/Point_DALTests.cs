namespace Geometrie.DAL.Tests
{
    public class Point_DALTests
    {
        [Fact]
        public void Geometrie_DAL_Point_Constructor()
        {
            //on teste le premier constructeur de la classe Point
            //un test se passe en 3 phases : Arrange, Act, Assert

            //Arrange : initialisation des données
            //ici le Act est fait en même temps (instanciation de la classe)
            var point = new Point_DAL(1, 2);

            //Assert : vérification des résultats
            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
        }

        //on teste le 2eme constructeur de la classe Point
        [Fact]
        public void Geometrie_DAL_Point_Constructor_With_Id()
        {
            //Arrange
            var point = new Point_DAL(1, 2, 3);

            //Assert
            Assert.Equal(1, point.Id);
            Assert.Equal(2, point.X);
            Assert.Equal(3, point.Y);
        }

        //fait la même chose mais avec des theory
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 6)]
        public void Geometrie_DAL_Point_Constructor_With_Id_Theory(int id, int x, int y)
        {
            //Arrange
            
            //Act
            var point = new Point_DAL(id, x, y);
            
            //Assert
            Assert.Equal(id, point.Id);
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }
    }
}