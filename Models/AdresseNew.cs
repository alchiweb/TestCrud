using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestCrud.Models
{
    public partial class AdresseNew : ModelBase
    {
        public AdresseNew()
        {
            ChauffeurNewAdresse = new HashSet<ChauffeurNew>();
            ChauffeurNewAdresseChute = new HashSet<ChauffeurNew>();
            VehiculeNew = new HashSet<VehiculeNew>();
        }

        public Guid Id { get; set; }
        [MaxLength(50)]
        public string AdresseTexte { get; set; }
        [MaxLength(50)]
        public string Complement { get; set; }
        [MaxLength(6)]
        public string CodePostal { get; set; }
        [MaxLength(10)]
        public string Ville { get; set; }
        [MaxLength(50)]
        public string NomVille { get; set; }
        [MaxLength(10)]
        public string Departement { get; set; }
        [MaxLength(50)]
        public string NomDepartement { get; set; }
        [MaxLength(10)]
        public string Region { get; set; }
        [MaxLength(50)]
        public string NomRegion { get; set; }
        [MaxLength(10)]
        public string Pays { get; set; }
        [MaxLength(50)]
        public string NomPays { get; set; }

        public virtual ICollection<ChauffeurNew> ChauffeurNewAdresse { get; set; }
        public virtual ICollection<ChauffeurNew> ChauffeurNewAdresseChute { get; set; }
        public virtual ICollection<VehiculeNew> VehiculeNew { get; set; }

        public override string ToString() => AdresseTexte;

    }
}
