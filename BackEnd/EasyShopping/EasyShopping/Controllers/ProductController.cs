using EasyShopping.Infrastructure.Database;
using EasyShopping.Core.Model.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShopping.Core.Interfaces;
using EasyShopping.Core.Specifications;
using EasyShopping.Core.ModelDTO;
using AutoMapper;

namespace EasyShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTyepRepo;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTyepRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTyepRepo = productTyepRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts()
        {
            //var products = await _productRepo.GetProducts();
            //return Ok(products);
            //return Ok(await _productRepo.GetAllAsync());
            var spec = new ProductsWithTypesAndBrandsSpecifications();
            var products = await _productRepo.ListAsync(spec);
            //return Ok(products.Select(x=> new ProductDTO { 
            //    Id= x.Id,
            //    Description = x.Description,
            //    Price = x.Price,
            //    ProductBrand = x.ProductBrand.Name,
            //    ProductName = x.ProductName,
            //    ProductPhoto = x.ProductPhoto,
            //    ProductPhotoUrl= x.ProductPhotoUrl,
            //    ProductType = x.ProductType.Name
            //}).ToList());
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            //return await _productRepo.GetByIdAsync(id);
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);
            var product = await _productRepo.GetModelWithSpec(spec);
            //return new ProductDTO
            //{
            //    Id = product.Id,
            //    Description = product.Description,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand.Name,
            //    ProductName = product.ProductName,
            //    ProductPhoto = product.ProductPhoto,
            //    ProductPhotoUrl = product.ProductPhotoUrl,
            //    ProductType = product.ProductType.Name
            //};
            return _mapper.Map<Product, ProductDTO>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            //var brands = await _productRepo.GetProductBrands();
            //return Ok(brands);
            return Ok(await _productBrandRepo.GetAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            //var types = await _productRepo.GetProductTypes();
            //return Ok(types);
            return Ok(await _productTyepRepo.GetAllAsync());
        }
    }
}
