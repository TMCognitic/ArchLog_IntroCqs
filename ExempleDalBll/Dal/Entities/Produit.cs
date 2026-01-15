using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDalBll.Dal.Entities
{
#nullable disable
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
    }
}
