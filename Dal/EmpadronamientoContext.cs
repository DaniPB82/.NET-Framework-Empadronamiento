using Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using static Entidades.Persona;

namespace Dal
{
    public partial class EmpadronamientoContext : DbContext
    {
        public EmpadronamientoContext()
            : base(@"Data Source=ryzen5-3600;Initial Catalog=EmpadronamientoTest;Integrated Security=True")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Vivienda> Viviendas { get; set; }
        public virtual DbSet<Propiedad> Propiedades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Viviendas)
                .WithRequired(e => e.Municipios)
                .HasForeignKey(e => e.MunicipioId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Viviendas1)
                .WithMany(e => e.Personas1)
                .Map(m => m.ToTable("Propiedades").MapLeftKey("PropietarioId").MapRightKey("ViviendaId"));

            modelBuilder.Entity<Provincia>()
                .HasMany(e => e.Municipios)
                .WithRequired(e => e.Provincias)
                .HasForeignKey(e => e.ProvinciaId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Vivienda>()
                .HasMany(e => e.Empadronados)
                .WithRequired(e => e.Viviendas)
                .HasForeignKey(e => e.HogarId)
                .WillCascadeOnDelete(true);

            

        }
    }
}
