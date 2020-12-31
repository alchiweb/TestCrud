using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCrud.Models
{
    public partial class CategorieVehiculeNew : ModelBase
    {
        public CategorieVehiculeNew()
        {
            VehiculeNewCategorieVehicule = new HashSet<VehiculeNew>();
        }

        public Guid Id { get; set; }
        [MaxLength(3)]
        public string Categorie { get; set; }
        [MaxLength(40)]
        public string Libelle { get; set; }
        public DateTime? DateCreation { get; set; }
        [Column("Date_Saisie")]
        public DateTime? DateSaisie { get; set; }

        public virtual ICollection<VehiculeNew> VehiculeNewCategorieVehicule { get; set; }

        public override string ToString() => $"{Categorie} ({Libelle})";
    }
}
