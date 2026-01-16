using ExempleCqs.Domain.Commands;
using ExempleCqs.Domain.Entities;
using ExempleCqs.Domain.Queries;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace ExempleCqs.Domain.Repositories
{
    public interface IProduitRepository :
        IQueryHandler<GetAllProduitQuery, IEnumerable<Produit>>,
        IQueryHandler<GetProduitByIdQuery, Produit>,
        IQueryHandler<GetProduitParNomQuery, IEnumerable<Produit>>,
        ICommandHandler<AddProduitCommand>,
        ICommandHandler<UpdateProduitCommand>,
        ICommandHandler<DeleteProduitCommand>
    {
    }
}
