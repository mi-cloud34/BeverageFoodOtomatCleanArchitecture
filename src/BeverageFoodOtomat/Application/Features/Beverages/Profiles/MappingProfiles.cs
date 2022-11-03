using Application.Features.BeverageHotColdTypes.Commands.CreateBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Commands.DeleteBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Commands.UpdateBeverageHotColdType;
using Application.Features.Beverages.Commands.CreateBeverage;
using Application.Features.Beverages.Commands.DeleteBeverage;
using Application.Features.Beverages.Commands.UpdateBeverage;
using Application.Features.Beverages.Dtos;
using Application.Features.Beverages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Beverages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Beverage, CreateBeverageCommand>().ReverseMap();
        CreateMap<Beverage, CreateBeverageDto>().ReverseMap();
        CreateMap<Beverage, UpdateBeverageCommand>().ReverseMap();
        CreateMap<Beverage, UpdateBeverageDto>().ReverseMap();
        CreateMap<Beverage, DeleteBeverageCommand>().ReverseMap();
        CreateMap<Beverage, DeleteBeverageDto>().ReverseMap();
        CreateMap<Beverage, BeverageDto>().ReverseMap();
        CreateMap<Beverage, BeverageListDto>().ForMember(c => c.BeverageHotColdName, opt => opt.MapFrom(c => c.BeverageHotColdType.BeverageHotColdTypeName))
                                        .ForMember(c => c.BeverageSugarFreeName, opt => opt.MapFrom(c => c.BeverageSugarFreeType.BeverageSugarFreeTypeName)
                                        );
        CreateMap<IPaginate<Beverage>, BeverageListModel>().ReverseMap();
    }
}