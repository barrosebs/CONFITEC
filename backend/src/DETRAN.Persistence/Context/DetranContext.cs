using DETRAN.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DETRAN.Persistence.Data.Context
{
    public class DetranContext : DbContext
    {
        public DetranContext(DbContextOptions<DetranContext> options) : base (options){ }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Condutor> Condutores { get; set; }
            public DbSet<Veiculo> Veiculos { get; set; }
            public DbSet<CondutorVeiculo> CondutoresVeiculos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Usuario>().
            //.Where(p => p.Name == p.ReflectedType.Name + "Id")
            //.Configure(p => p.HasColumnType("varchar"));
            //modelBuilder.Properties<string>()
            //.Configure(p => p.HasMaxLength(100));

            //para definir uma chave composta no relacionamento das tabelas
            modelBuilder.Entity<CondutorVeiculo>().HasKey(cv => new { cv.CondutorId, cv.VeiculoId });
            //modelBuilder.Configurations.Add(new UsuarioConfiguration());
        }

        /// <summary>
        /// Sobrecrever médoto para quando salvar dataCadastro pegar o a data e hora atual do sistema
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if(entry.State == EntityState.Modified){
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
