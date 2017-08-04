using System.Collections.Generic;
using System.Linq;
using Checkout.ProductApi.NetCore.Models;

namespace Checkout.ProductApi.NetCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public Product Find(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        
        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
