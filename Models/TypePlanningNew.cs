using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCrud.Models
{
    public partial class TypePlanningNew : ModelBase
    {
        public TypePlanningNew()
        {
            ChauffeurNewTypePlanning = new HashSet<ChauffeurNew>();
            VehiculeNewTypePlanning = new HashSet<VehiculeNew>();
        }

        public Guid Id { get; set; }
        [MaxLength(3)]
        public string TypePlanningTexte { get; set; }
        [MaxLength(30)]
        public string Libelle { get; set; }
        [MaxLength(2)]
        public string ActiviteAnalytique { get; set; }

        public bool GenereDemandePrix { get; set; }

        public virtual ICollection<ChauffeurNew> ChauffeurNewTypePlanning { get; set; }
        public virtual ICollection<VehiculeNew> VehiculeNewTypePlanning { get; set; }

        public override string ToString() => $"{TypePlanningTexte} ({Libelle})";

    }
}
