using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Commands;

namespace ExempleCqs.Domain.Commands
{
    public sealed class UpdateProduitCommand : ICommandDefinition
    {
        public int Id { get; }
        public string Nom { get; }
        public double Prix { get; }
        public UpdateProduitCommand(int id, string nom, double prix)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
        }
    }
}
