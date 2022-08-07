using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyShopping.Core.Model.Product
{
    public class Product : BaseModel
    {        
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductPhotoUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
