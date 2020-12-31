using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCrud.Models
{
    public abstract class ModelBase
    {
        [NotMapped]
        public string DisplayValue => ToString();
    }
}
