using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrud.Models
{
    public class Client : ModelBase
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public override string ToString() => $"{Nom}";
    }
}
