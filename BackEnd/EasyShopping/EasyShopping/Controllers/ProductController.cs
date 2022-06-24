using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "A list of product";
        }
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "A single product";
        }
    }
}
