using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCrud.Models
{
    public partial class TypeVehiculeNew : ModelBase
    {
        public TypeVehiculeNew()
        {
            VehiculeNewTypeVehicule = new HashSet<VehiculeNew>();
        }

        public Guid Id { get; set; }
        [MaxLength(3)]
        public string TypeVehiculeTexte { get; set; }
        [MaxLength(40)]
        public string Libelle { get; set; }
        public bool Remorque { get; set; }
        public bool Camion { get; set; }
        public bool Tracteur { get; set; }
        public bool SousTraitant { get; set; }
        public double? Autoroute { get; set; }
        public double? Route { get; set; }
        public double? RouteSec { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateSaisie { get; set; }

        public virtual ICollection<VehiculeNew> VehiculeNewTypeVehicule { get; set; }

        public override string ToString() => $"{TypeVehiculeTexte} ({Libelle})";
    }
}
