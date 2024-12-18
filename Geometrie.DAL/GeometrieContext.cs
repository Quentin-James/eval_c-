using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Geometrie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour les formes géométriques
    /// en Entity Framework (Code First)
    /// </summary>
    public class GeometrieContext : DbContext
    {
        private readonly IConfiguration configuration;

        public GeometrieContext(DbContextOptions<GeometrieContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Geometrie"));
            }
        }

        public DbSet<Point_DAL> Points { get; set; }
        public DbSet<Log_DAL> Logs { get; set; }
        public DbSet<Cercle> Cercles { get; set; }
    }

    public class Cercle
    {
        public int? Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Rayon { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }
    }
}