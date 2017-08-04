using System.Collections.Generic;
using Checkout.ProductApi.NetCore.Models;

namespace Checkout.ProductApi.NetCore.Repositories
{
    public interface IProductRepository
    {
        Product Find(string name);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Remove(Product name);
    }
}
