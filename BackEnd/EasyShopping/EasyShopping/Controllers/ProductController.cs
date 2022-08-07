using EasyShopping.Infrastructure.Database;
using EasyShopping.Core.Model.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShopping.Core.Interfaces;

namespace EasyShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepo.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {            
            return await _productRepo.GetProductByIdAsync(id);
        }
        [HttpGet("{brands}")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var brands = await _productRepo.GetProductBrands();
            return Ok(brands);
        }
        [HttpGet("{types}")]
        public async Task<ActionResult<List<Product>>> GetProductTypes()
        {
            var types = await _productRepo.GetProductTypes();
            return Ok(types);
        }
    }
}
