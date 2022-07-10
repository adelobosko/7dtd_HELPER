using _7DTD_Directx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace _7DTD_Directx.Database
{
    public class DatabaseContext : DbContext
    {
        public static readonly string DatabasePath;

        public DbSet<Config> Configs { get; set; }
        public DbSet<Map> Maps { get; set; }

        static DatabaseContext()
        {
            if(!Directory.Exists(Utils.Paths.ConfigDirectory))
            {
                Directory.CreateDirectory(Utils.Paths.ConfigDirectory);
            }
            DatabasePath = Path.Combine(Utils.Paths.ConfigDirectory, "7dtdHelper.db");
        }


        public DatabaseContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Func<string, (string IP, string Port)> toIPAndPort = (host) =>
            {
                var hostValues = host.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                return (hostValues[0], hostValues[1]);
            };

            modelBuilder
                .Entity<Map>()
                .Property(c => c.Host)
                .HasColumnName("Host")
                .HasConversion(
                    host => $"{host.IP}:{host.Port}",
                    host => toIPAndPort(host)
                );

            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DatabasePath}");
    }
}
