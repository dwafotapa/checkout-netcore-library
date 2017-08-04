using System.Collections.Generic;
using Checkout.ProductApi.NetCore.Models;

namespace Checkout.ProductApi.NetCore.UnitTests
{
    public class TestHelper
    {
        public static Product MakeProduct()
        {
            return new Product {
                Name = "Orangina",
                Quantity = 1
            };
        }

        public static IEnumerable<Product> MakeProducts()
        {
            var p1 = new Product {
                Name = "Orangina",
                Quantity = 1
            };
            var p2 = new Product {
                Name = "Coca Cola",
                Quantity = 10
            };
            var p3 = new Product {
                Name = "San Pellegrino",
                Quantity = 100
            };
            return new List<Product>() { p1, p2 , p3 };
        }
    }
}
