using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pointeuse.Data.Models;

namespace Pointeuse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Pointage> Pointages { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // ⚠️ Adapte la chaîne de connexion à ta base SQL Server
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-G2Q30PB\\MSSQLSERVER01;Database=PointeuseAlternantsDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
