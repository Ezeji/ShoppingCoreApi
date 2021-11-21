using AutoMapper;
using ShoppingCoreApi.Models.DTO;
using ShoppingCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Services.ShoppingStore
{
    public class ShoppingStoreProfile : Profile
    {
        public ShoppingStoreProfile()
        {
            CreateMap<DiscountStoreDTO, DiscountStore>()
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
                .ForMember(dest => dest.DiscountStoreId, opt => opt.MapFrom(src => src.DiscountStoreId));

            CreateMap<DiscountStore, DiscountStoreDTO>()
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
                .ForMember(dest => dest.DiscountStoreId, opt => opt.MapFrom(src => src.DiscountStoreId));
        }
    }
}
