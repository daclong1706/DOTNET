namespace LanguageFeatures.Controllers
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product?> cart)
        {
            decimal total = 0;

            foreach (var product in cart)
            {
                total += product?.Price ?? 0;

            }

            return total;
        }

        public static IEnumerable<Product?> FilterByPrice(this IEnumerable<Product?> productEnum, decimal minimunPrice)
        {
            {
                foreach (Product? prod in productEnum)
                {
                    if ((prod?.Price ?? 0) >= minimunPrice)
                    {
                        yield return prod;
                    }
                }
            }
        }

        public static IEnumerable<Product?> FilterByName(this IEnumerable<Product?> productEnum, char fisrtLetter)
        {
            {
                foreach (Product? prod in productEnum)
                {
                    if ((prod?.Name[0] ?? 0) == fisrtLetter)
                    {
                        yield return prod;
                    }
                }
            }
        }
    }
}