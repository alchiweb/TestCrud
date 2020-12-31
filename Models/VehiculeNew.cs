using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestCrud.Models
{
    public partial class VehiculeNew : ModelBase
    {
        public VehiculeNew()
        {
            ChauffeurNewRemorque = new HashSet<ChauffeurNew>();
            ChauffeurNewVehicule = new HashSet<ChauffeurNew>();
        }

        public Guid Id { get; set; }
        [MaxLength(11)]
        public string Immatriculation { get; set; }
        [Required]
        [MaxLength(9)]
        public string VehiculeTexte { get; set; }
        [MaxLength(50)]
        public string Libelle { get; set; }
        public double? Autoroute { get; set; }
        public double? Route { get; set; }
        public double? RouteSec { get; set; }
        public int? Tiers { get; set; }
        [MaxLength(20)]
        public string Marque { get; set; }
        public DateTime? MiseEnService { get; set; }
        public DateTime? Acquisition { get; set; }
        [MaxLength(11)]
        public string NoCg { get; set; }
        [MaxLength(10)]
        public string Genre { get; set; }
        [MaxLength(15)]
        public string TypeCg { get; set; }
        [MaxLength(50)]
        public string NoSerie { get; set; }
        [MaxLength(25)]
        public string Carrosserie { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }
        public double? PoidsVide { get; set; }
        public short? Palette { get; set; }
        public float? Poids { get; set; }
        public float? MetrageLineaire { get; set; }
        public float? Volume { get; set; }
        public float? Longueur { get; set; }
        public float? Largeur { get; set; }
        public float? Hauteur { get; set; }
        public float? Ptac { get; set; }
        public DateTime? DateSortie { get; set; }
        [Required]
        [MaxLength(3)]
        public string PaysOrigine { get; set; }
        public bool Cabotage { get; set; }
        public DateTime? DebutCabotage { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateSaisie { get; set; }
        public Guid? AdresseId { get; set; }
        public Guid? TypePlanningId { get; set; }
        public Guid? TypeVehiculeId { get; set; }
        public Guid? CategorieVehiculeId { get; set; }

        public virtual TypePlanningNew TypePlanning { get; set; }
        public virtual TypeVehiculeNew TypeVehicule { get; set; }
        public virtual CategorieVehiculeNew CategorieVehicule { get; set; }
        public virtual AdresseNew Adresse { get; set; }
        public virtual ICollection<ChauffeurNew> ChauffeurNewRemorque { get; set; }
        public virtual ICollection<ChauffeurNew> ChauffeurNewVehicule { get; set; }

        public override string ToString() => VehiculeTexte;
    }
}
