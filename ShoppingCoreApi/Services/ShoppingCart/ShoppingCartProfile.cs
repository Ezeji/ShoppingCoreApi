using AutoMapper;
using ShoppingCoreApi.Models.DTO;
using ShoppingCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Services.ShoppingCart
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<CartDTO, Cart>()
                .ForMember(dest => dest.ItemsSelected, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.ShoppingCode, opt => opt.MapFrom(src => src.ShoppingCode));

            CreateMap<Cart, CartDTO>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemsSelected))
                .ForMember(dest => dest.ShoppingCode, opt => opt.MapFrom(src => src.ShoppingCode));
        }
    }
}
