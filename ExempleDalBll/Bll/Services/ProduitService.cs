using ExempleDalBll.Bll.Entities;
using ExempleDalBll.Bll.Mappers;
using ExempleDalBll.Bll.Repositories;

using IDalProduitRepository = ExempleDalBll.Dal.Repositories.IProduitRepository;
using DalProduit = ExempleDalBll.Dal.Entities.Produit;

namespace ExempleDalBll.Bll.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly IDalProduitRepository _repository;

        public ProduitService(IDalProduitRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Produit> Get()
        {
            return _repository.Get().Select(p => p.ToBll());
        }

        public Produit? Get(int id)
        {
            return _repository.Get(id)?.ToBll();
        }

        public bool Insert(Produit produit)
        {
            return _repository.Insert(produit.ToDal())  ;
        }

        public bool Update(int id, Produit produit)
        {
            DalProduit p = produit.ToDal();
            p.Id = id;

            return _repository.Update(p);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id); 
        }
    }
}
