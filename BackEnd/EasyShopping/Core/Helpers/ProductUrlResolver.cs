using AutoMapper;
using EasyShopping.Core.Model.Product;
using EasyShopping.Core.ModelDTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShopping.Core.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        public IConfiguration _config { get; }

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }


        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductPhotoUrl))
            {
                return _config["ApiUrl"]+source.ProductPhotoUrl;
            }
            return null;
        }
    }
}
