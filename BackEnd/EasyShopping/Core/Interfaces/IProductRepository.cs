using EasyShopping.Core.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopping.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync();
        Task<IReadOnlyList<Product>> GetProducts();
    }
}
