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
            CreateMap<Product, ProductDTO>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.ProductPhotoUrl, o => o.MapFrom<ProductUrlResolver>());                                 

            
           
        }
    }
}
