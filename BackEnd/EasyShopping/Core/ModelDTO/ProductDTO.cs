using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShopping.Core.ModelDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductPhotoUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
        
    }
}
