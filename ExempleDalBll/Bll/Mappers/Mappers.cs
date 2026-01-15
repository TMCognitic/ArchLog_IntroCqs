using D = ExempleDalBll.Dal.Entities;
using B = ExempleDalBll.Bll.Entities;

namespace ExempleDalBll.Bll.Mappers
{
    internal static class Mappers
    {
        public static D.Produit ToDal(this B.Produit produit)
        {
            return new D.Produit() { Id = produit.Id, Nom = produit.Nom, Prix = produit.Prix };
        }

        public static B.Produit ToBll(this D.Produit produit)
        {
            return new B.Produit(produit.Id, produit.Nom, produit.Prix);
        }
    }
}
