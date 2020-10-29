using Application.DTOs.Account;
using Application.Features.Shops.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateShopCommand, Shop>();
            CreateMap<UpdateShopCommand, Shop>();
            
            CreateMap<RegisterRequest, User>();
        }
    }
}