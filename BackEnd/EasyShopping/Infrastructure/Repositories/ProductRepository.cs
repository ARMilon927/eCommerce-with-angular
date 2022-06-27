using EasyShopping.Core.Interfaces;
using EasyShopping.Core.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopping.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
