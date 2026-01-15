using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Commands;

namespace ExempleCqs.Domain.Commands
{
    public class AddProduitCommand : ICommandDefinition
    {
        public string Nom { get; }
        public double Prix { get; }

        public AddProduitCommand(string nom, double prix)
        {
            Nom = nom;
            Prix = prix;
        }
    }
}
