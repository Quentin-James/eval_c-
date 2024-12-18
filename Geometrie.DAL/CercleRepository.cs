using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometrie.DAL
{
    public class CercleRepository
    {
        private readonly GeometrieContext _context;

        public CercleRepository(GeometrieContext context)
        {
            _context = context;
        }

        // Récupérer tous les cercles
        public IEnumerable<Cercle_DAL> GetAllCercles()
        {
            return _context.Cercles.Select(c => new Cercle_DAL(c.X, c.Y, c.Rayon)
            {
                Id = c.Id,
                DateDeCreation = c.DateDeCreation,
                DateDeModification = c.DateDeModification
            }).ToList();
        }

        // Récupérer un cercle par son ID
        public Cercle_DAL GetCercleById(int id)
        {
            var cercle = _context.Cercles.FirstOrDefault(c => c.Id == id);
            if (cercle != null)
            {
                return new Cercle_DAL(cercle.X, cercle.Y, cercle.Rayon)
                {
                    Id = cercle.Id,
                    DateDeCreation = cercle.DateDeCreation,
                    DateDeModification = cercle.DateDeModification
                };
            }
            return null;
        }

        // Ajouter un cercle
        public void AddCercle(Cercle_DAL cercle)
        {
            var cercleEntity = new Cercle
            {
                X = cercle.X,
                Y = cercle.Y,
                Rayon = cercle.Rayon,
                DateDeCreation = DateTime.Now
            };

            _context.Cercles.Add(cercleEntity);
            _context.SaveChanges();
        }

        // Mettre à jour un cercle
        public void UpdateCercle(int id, Cercle_DAL cercle)
        {
            var existingCercle = _context.Cercles.FirstOrDefault(c => c.Id == id);
            if (existingCercle != null)
            {
                existingCercle.X = cercle.X;
                existingCercle.Y = cercle.Y;
                existingCercle.Rayon = cercle.Rayon;
                existingCercle.DateDeModification = DateTime.Now;

                _context.SaveChanges();
            }
        }

        // Supprimer un cercle
        public void DeleteCercle(int id)
        {
            var cercle = _context.Cercles.FirstOrDefault(c => c.Id == id);
            if (cercle != null)
            {
                _context.Cercles.Remove(cercle);
                _context.SaveChanges();
            }
        }

        // Calculer l'aire totale des cercles à partir d'une liste d'IDs
        public double CalculerAireTotale(List<int> ids)
        {
            var cercles = _context.Cercles.Where(c => ids.Contains(c.Id.Value)).ToList();
            double aireTotale = 0;
            foreach (var cercle in cercles)
            {
                aireTotale += Math.PI * Math.Pow(cercle.Rayon, 2);
            }
            return aireTotale;
        }
    }
}