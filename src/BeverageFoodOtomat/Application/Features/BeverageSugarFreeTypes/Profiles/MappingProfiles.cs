using Application.Features.BeverageSugarFreeTypes.Commands.CreateBeverageSugarFreeType;
using Application.Features.BeverageSugarFreeTypes.Commands.DeleteBeverageSugarFreeType;
using Application.Features.BeverageSugarFreeTypes.Commands.UpdateBeverageSugarFreeType;
using Application.Features.BeverageSugarFreeTypes.Dtos;
using Application.Features.BeverageSugarFreeTypes.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.BeverageSugarFreeTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BeverageSugarFreeType, CreateBeverageSugarFreeTypeCommand>().ReverseMap();
        CreateMap<BeverageSugarFreeType, CreateBeverageSugarFreeTypeDto>().ReverseMap();
        CreateMap<BeverageSugarFreeType, UpdateBeverageSugarFreeTypeCommand>().ReverseMap();
        CreateMap<BeverageSugarFreeType, UpdateBeverageSugarFreeTypeDto>().ReverseMap();
        CreateMap<BeverageSugarFreeType, DeleteBeverageSugarFreeTypeCommand>().ReverseMap();
        CreateMap<BeverageSugarFreeType, DeleteBeverageSugarFreeTypeDto>().ReverseMap();
        CreateMap<BeverageSugarFreeType, BeverageSugarFreeTypeDto>().ReverseMap();
        CreateMap<BeverageSugarFreeType, BeverageSugarFreeTypeListDto>().ReverseMap();
        CreateMap<IPaginate<BeverageSugarFreeType>, BeverageSugarFreeTypeListModel>();
    }
}