using Geometrie.DTO;
using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Point_Controller : Controller
    {
        private IPoint_Service service;

        public Point_Controller(IPoint_Service service)
        {
            this.service = service;
        }

        //On mappe toutes les méthodes de service dans des méthodes de contrôleurs

        [HttpPost]
        public Point_DTO Add(Point_DTO point)
        {
            return service.Add(point);
        }

        [HttpPost]
        [ActionName("DeleteObject")]
        public IActionResult Delete(Point_DTO point)
        {
            return Ok(service.Delete(point));
        }

        [HttpPost]
        [ActionName("DeleteById")]
        public IActionResult Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        [HttpGet]
        public IEnumerable<Point_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet]
        public Point_DTO? GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public Point_DTO Update(Point_DTO point)
        {
            return service.Update(point);
        }

        [HttpPost]
        [ActionName("CalculerDistanceByDTO")]
        public double CalculerDistance(IEnumerable<Point_DTO> points)
        {
            //on vérifie qu'on en a 2
            if (points.Count() != 2)
                throw new System.ArgumentException("Il faut 2 points pour calculer une distance");

            //on récupère l'adresse IP du client
            var IP = HttpContext.Connection.RemoteIpAddress?.ToString();
            IP = IP ?? "inconnue";

            return service.CalculerDistance(points.ElementAt(0), points.ElementAt(1), IP);
        }

        [HttpPost]
        [ActionName("CalculerDistanceById")]
        public double CalculerDistance(int id1, int id2)
        {
            //on récupère l'adresse IP du client
            var IP = HttpContext.Connection.RemoteIpAddress?.ToString();
            IP = IP ?? "inconnue";

            return service.CalculerDistance(id1, id2, IP);
        }
    }
}
