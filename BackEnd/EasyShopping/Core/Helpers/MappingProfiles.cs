using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EasyShopping.Core.Model.Product;
using EasyShopping.Core.ModelDTO;

namespace EasyShopping.Core.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
