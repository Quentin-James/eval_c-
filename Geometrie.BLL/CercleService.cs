using Geometrie.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Geometrie.BLL
{
    public class CercleService
    {
        private readonly CercleRepository _cercleRepository;

        public CercleService(CercleRepository cercleRepository)
        {
            _cercleRepository = cercleRepository;
        }

        public IEnumerable<Cercle> GetAllCercles()
        {
            var cerclesDal = _cercleRepository.GetAllCercles();
            return cerclesDal.Select(c => new Cercle(new Point((int)c.X, (int)c.Y), (int)c.Rayon)).ToList();
        }

        public void AddCercle(Cercle cercle)
        {
            var cercleDal = new Cercle_DAL(cercle.Centre.X, cercle.Centre.Y, cercle.Rayon);
            _cercleRepository.AddCercle(cercleDal);
        }
    }
}