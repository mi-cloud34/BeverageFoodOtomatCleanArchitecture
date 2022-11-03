
using Application.Features.FoodAqueousAnhydrousTypes.Commands.CreateFoodAqueousAnhydrousType;
using Application.Features.FoodAqueousAnhydrousTypes.Commands.DeleteFoodAqueousAnhydrousType;
using Application.Features.FoodAqueousAnhydrousTypes.Commands.UpdateFoodAqueousAnhydrousType;
using Application.Features.FoodAqueousAnhydrousTypes.Dtos;
using Application.Features.FoodAqueousAnhydrousTypes.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.FoodAqueousAnhydrousTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FoodAqueousAnhydrousType, CreateFoodAqueousAnhydrousTypeCommand>().ReverseMap();
        CreateMap<FoodAqueousAnhydrousType, CreateFoodAqueousAnhydrousTypeDto>().ReverseMap();
        CreateMap<FoodAqueousAnhydrousType, UpdateFoodAqueousAnhydrousTypeCommand>().ReverseMap();
        CreateMap<FoodAqueousAnhydrousType, UpdateFoodAqueousAnhydrousTypeDto>().ReverseMap();
        CreateMap<FoodAqueousAnhydrousType, DeleteFoodAqueousAnhydrousTypeCommand>().ReverseMap();
        CreateMap<FoodAqueousAnhydrousType, DeleteFoodAqueousAnhydrousTypeDto>().ReverseMap();
        CreateMap<FoodAqueousAnhydrousType, FoodAqueousAnhydrousTypeDto>().ReverseMap();
        CreateMap<FoodAqueousAnhydrousType, FoodAqueousAnhydrousTypeListDto>().ReverseMap();
        CreateMap<IPaginate<FoodAqueousAnhydrousType>, FoodAqueousAnhydrousTypesListModel>().ReverseMap();
    }
}