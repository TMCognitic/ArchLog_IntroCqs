using ExempleCqs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Queries;

namespace ExempleCqs.Domain.Queries
{
    public sealed class GetProduitByIdQuery : IQueryDefinition<Produit>
    {
        public int Id { get; }

        public GetProduitByIdQuery(int id)
        {
            Id = id;
        }
    }
}
