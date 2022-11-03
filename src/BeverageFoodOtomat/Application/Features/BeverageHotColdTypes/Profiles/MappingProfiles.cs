using Application.Features.BeverageHotColdTypes.Commands.CreateBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Commands.DeleteBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Commands.UpdateBeverageHotColdType;
using Application.Features.BeverageHotColdTypes.Dtos;
using Application.Features.BeverageHotColdTypes.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.BeverageHotColdTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BeverageHotColdType, CreateBeverageHotColdTypeCommand>().ReverseMap();
        CreateMap<BeverageHotColdType, CreateBeverageHotColdTypeDto>().ReverseMap();
        CreateMap<BeverageHotColdType, UpdateBeverageHotColdTypeCommand>().ReverseMap();
        CreateMap<BeverageHotColdType, UpdateBeverageHotColdTypeDto>().ReverseMap();
        CreateMap<BeverageHotColdType, DeleteBeverageHotColdTypeCommand>().ReverseMap();
        CreateMap<BeverageHotColdType, DeleteBeverageHotColdTypeDto>().ReverseMap();
        CreateMap<BeverageHotColdType, BeverageHotColdTypeDto>().ReverseMap();
        CreateMap<BeverageHotColdType, BeverageHotColdTypeListDto>().ReverseMap();
        CreateMap<IPaginate<BeverageHotColdType>, BeverageHotColdTypeListModel>().ReverseMap();
    }
}