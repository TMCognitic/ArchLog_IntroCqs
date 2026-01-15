using ExempleDalBll.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDalBll.Dal.Mappers
{
    internal static class Mappers
    {
        internal static Produit ToProduit(this IDataRecord record)
        {
            return new Produit() { Id = (int)record["Id"], Nom = (string)record["Nom"], Prix = (double)record["Prix"] };
        }
    }
}
