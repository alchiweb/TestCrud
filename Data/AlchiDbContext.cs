using System;
using System.Collections.Generic;
using System.Text;
using EntitySignal.Server.EFDbContext.Data;
using EntitySignal.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestCrud.Models;

namespace TestCrud.Data
{
    public class AlchiDbContext : EntitySignalIdentityDbContext<AlchiUser>
    {
        public AlchiDbContext(DbContextOptions<AlchiDbContext> options, EntitySignalDataProcess entitySignalDataProcess)
            : base(options, entitySignalDataProcess)
        {
        }

        public virtual DbSet<CategorieVehiculeNew> CategorieVehiculeNew { get; set; }
        public virtual DbSet<TypeVehiculeNew> TypeVehiculeNew { get; set; }
        public virtual DbSet<TypePlanningNew> TypePlanningNew { get; set; }

        public virtual DbSet<ChauffeurNew> ChauffeurNew { get; set; }
        public virtual DbSet<VehiculeNew> VehiculeNew { get; set; }
        public virtual DbSet<AdresseNew> AdresseNew { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorieVehiculeNew>(entity =>
            {
                entity.ToTable("CategorieVehicule_New");
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");
                //entity.HasKey(e => e.Categorie)
                //    .HasName("PK_CategorieVehicule_Categorie");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateSaisie).HasColumnType("datetime");

                entity.Property(e => e.Libelle)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<TypeVehiculeNew>(entity =>
            {
                entity.ToTable("TypeVehicule_New");
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                //entity.HasKey(e => e.TypeVehiculeTexte)
                //    .HasName("PK_TypeVehicule_TypeVehicule");


                entity.Property(e => e.TypeVehiculeTexte)
                    .HasColumnName("TypeVehicule")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateSaisie).HasColumnType("datetime");

                entity.Property(e => e.Libelle)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypePlanningNew>(entity =>
            {
                entity.ToTable("TypePlanning_New");
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                //entity.HasKey(e => e.TypePlanningTexte)
                //    .HasName("PK_TypePlanning_TypePlanning");

                entity.Property(e => e.TypePlanningTexte)
                    .HasColumnName("TypePlanning")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiviteAnalytique)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<AdresseNew>(entity =>
            {
                entity.ToTable("Adresse_New");
                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.AdresseTexte).HasMaxLength(50);

                entity.Property(e => e.CodePostal).HasMaxLength(6);

                entity.Property(e => e.Complement).HasMaxLength(50);

                entity.Property(e => e.Departement).HasMaxLength(10);

                entity.Property(e => e.NomDepartement).HasMaxLength(50);

                entity.Property(e => e.NomPays).HasMaxLength(50);

                entity.Property(e => e.NomRegion).HasMaxLength(50);

                entity.Property(e => e.NomVille).HasMaxLength(50);

                entity.Property(e => e.Pays).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(10);

                entity.Property(e => e.Ville).HasMaxLength(10);
            });


            modelBuilder.Entity<VehiculeNew>(entity =>
            {
                entity.ToTable("Vehicule_New");

                entity.HasIndex(e => e.AdresseId);

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Acquisition).HasColumnType("datetime");

                entity.Property(e => e.Carrosserie).HasMaxLength(25);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateSaisie).HasColumnType("datetime");

                entity.Property(e => e.DateSortie).HasColumnType("datetime");

                entity.Property(e => e.DebutCabotage).HasColumnType("datetime");

                entity.Property(e => e.Genre).HasMaxLength(10);

                entity.Property(e => e.Immatriculation).HasMaxLength(11);

                entity.Property(e => e.Libelle).HasMaxLength(50);

                entity.Property(e => e.Marque).HasMaxLength(20);

                entity.Property(e => e.MiseEnService).HasColumnType("datetime");

                entity.Property(e => e.NoCg)
                    .HasColumnName("NoCG")
                    .HasMaxLength(11);

                entity.Property(e => e.NoSerie).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PaysOrigine)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Ptac).HasColumnName("PTAC");

                entity.Property(e => e.TypeCg)
                    .HasColumnName("TypeCG")
                    .HasMaxLength(15);

                entity.Property(e => e.VehiculeTexte)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.HasOne(d => d.TypePlanning)
                    .WithMany(p => p.VehiculeNewTypePlanning)
                    .HasForeignKey(d => d.TypePlanningId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TypeVehicule)
                    .WithMany(p => p.VehiculeNewTypeVehicule)
                    .HasForeignKey(d => d.TypeVehiculeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CategorieVehicule)
                    .WithMany(p => p.VehiculeNewCategorieVehicule)
                    .HasForeignKey(d => d.CategorieVehiculeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasOne(d => d.Adresse)
                    .WithMany(p => p.VehiculeNew)
                    .HasForeignKey(d => d.AdresseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<ChauffeurNew>(entity =>
            {
                entity.ToTable("Chauffeur_New");

                entity.HasIndex(e => e.AdresseChuteId);

                entity.HasIndex(e => e.AdresseId);

                entity.HasIndex(e => e.RemorqueId);

                entity.HasIndex(e => e.VehiculeId);

                entity.Property(e => e.Id).HasDefaultValueSql("newid()");

                entity.Property(e => e.Abrege).HasMaxLength(12);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateSaisie).HasColumnType("datetime");

                entity.Property(e => e.DateSortie).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(50);

                entity.Property(e => e.NbHeures).HasColumnName("nbHeures");

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.Operateur).HasMaxLength(10);

                entity.Property(e => e.Permis).HasColumnType("datetime");

                entity.Property(e => e.Portable).HasMaxLength(25);

                entity.Property(e => e.Prenom).HasMaxLength(20);

                entity.Property(e => e.Telephone).HasMaxLength(25);

                entity.Property(e => e.Telephone2).HasMaxLength(25);

                entity.HasOne(d => d.TypePlanning)
                    .WithMany(p => p.ChauffeurNewTypePlanning)
                    .HasForeignKey(d => d.TypePlanningId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.AdresseChute)
                    .WithMany(p => p.ChauffeurNewAdresseChute)
                    .HasForeignKey(d => d.AdresseChuteId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Adresse)
                    .WithMany(p => p.ChauffeurNewAdresse)
                    .HasForeignKey(d => d.AdresseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Remorque)
                    .WithMany(p => p.ChauffeurNewRemorque)
                    .HasForeignKey(d => d.RemorqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vehicule)
                    .WithMany(p => p.ChauffeurNewVehicule)
                    .HasForeignKey(d => d.VehiculeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
