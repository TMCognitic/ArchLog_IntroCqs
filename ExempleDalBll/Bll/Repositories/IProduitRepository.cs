using ExempleDalBll.Bll.Entities;

namespace ExempleDalBll.Bll.Repositories
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> Get();
        Produit? Get(int id);
        bool Insert(Produit produit);
        bool Update(int id, Produit produit);
        bool Delete(int id);
    }
}
