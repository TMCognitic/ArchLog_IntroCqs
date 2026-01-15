using ExempleCqs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Queries;

namespace ExempleCqs.Domain.Queries
{
    public sealed class GetProduitParNomQuery : IQueryDefinition<IEnumerable<Produit>>
    {
        public string Fragment { get; }

        public GetProduitParNomQuery(string fragment)
        {
            Fragment = fragment;
        }
    }
}
