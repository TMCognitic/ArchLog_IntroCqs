using ExempleCqs.Domain.Entities;
using Tools.Cqs.Queries;

namespace ExempleCqs.Domain.Queries
{
    public sealed class GetAllProduitQuery : IQueryDefinition<IEnumerable<Produit>>
    {
    }
}
