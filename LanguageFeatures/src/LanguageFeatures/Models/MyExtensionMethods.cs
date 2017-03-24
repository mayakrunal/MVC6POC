using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            return products?.Sum(x => x?.Price ?? 0) ?? 0;
        }

        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, 
                                                         decimal minimumPrice)
        {
            foreach (Product prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }
    }
}
