using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDalBll.Bll.Entities
{
    public class Produit
    {
        public int Id { get; }
        public string Nom { get; set; }
        public double Prix { get; set; }

        public Produit(string nom, double prix)
        {
            Nom = nom;
            Prix = prix;
        }

        internal Produit(int id, string nom, double prix)
            : this(nom, prix)
        {
            Id = id;
        }
    }
}
