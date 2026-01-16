using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Results;

namespace ExempleCqs.CustomErrors
{
    internal static class Errors
    {
        internal static Error ProductNotFound => Error.Create("Produit non trouvé");
    }
}
