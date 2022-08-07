﻿using EasyShopping.Core.Interfaces;
using EasyShopping.Core.Model.Product;
using EasyShopping.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopping.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _context.Products.Include(p=> p.ProductBrand).Include(p=>p.ProductType).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
