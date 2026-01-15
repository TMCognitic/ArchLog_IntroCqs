using ExempleDalBll.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDalBll.Dal.Repositories
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> Get();
        Produit? Get(int id);
        bool Insert(Produit produit);
        bool Update(Produit produit);
        bool Delete(int id);
    }
}
