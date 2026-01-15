using ExempleCqs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleCqs.Domain.Mappers
{
    internal static class Mappers
    {
        internal static Produit ToProduit(this IDataRecord record)
        {
            return new Produit((int)record["Id"], (string)record["Nom"], (double)record["Prix"]);
        }
    }
}
