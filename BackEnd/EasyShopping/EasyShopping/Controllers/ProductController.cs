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

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTyepRepo;
        public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTyepRepo)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTyepRepo = productTyepRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //var products = await _productRepo.GetProducts();
            //return Ok(products);
            return Ok(await _productRepo.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {            
            return await _productRepo.GetByIdAsync(id);
        }
        [HttpGet("{brands}")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            //var brands = await _productRepo.GetProductBrands();
            //return Ok(brands);
            return Ok(await _productBrandRepo.GetAllAsync());
        }
        [HttpGet("{types}")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            //var types = await _productRepo.GetProductTypes();
            //return Ok(types);
            return Ok(await _productTyepRepo.GetAllAsync());
        }
    }
}
