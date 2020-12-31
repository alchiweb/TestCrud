using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestCrud.Models
{
    public partial class ChauffeurNew : ModelBase
    {
        public Guid Id { get; set; }
        //public Enums.TypePlanning TypePlanning { get; set; }
        [MaxLength(10)]
        public string Operateur { get; set; }
        [MaxLength(12)]
        public string Abrege { get; set; }
        [MaxLength(50)]
        public string Nom { get; set; }
        [MaxLength(20)]
        public string Prenom { get; set; }
        [MaxLength(25)]
        public string Telephone { get; set; }
        [MaxLength(25)]
        public string Telephone2 { get; set; }
        [MaxLength(25)]
        public string Portable { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime? Permis { get; set; }
        public short? NbHeures { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }
        public int? Tiers { get; set; }
        public DateTime? DateSortie { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateSaisie { get; set; }
        public Guid? AdresseId { get; set; }
        public Guid? AdresseChuteId { get; set; }
        public Guid? VehiculeId { get; set; }
        public Guid? RemorqueId { get; set; }
        public Guid? TypePlanningId { get; set; }

        public virtual TypePlanningNew TypePlanning { get; set; }
        public virtual AdresseNew Adresse { get; set; }
        public virtual AdresseNew AdresseChute { get; set; }
        public virtual VehiculeNew Remorque { get; set; }
        public virtual VehiculeNew Vehicule { get; set; }

        public override string ToString() => Abrege;
    }
}
