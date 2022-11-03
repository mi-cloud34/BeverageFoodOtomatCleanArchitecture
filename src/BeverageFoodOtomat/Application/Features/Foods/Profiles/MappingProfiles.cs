
using Application.Features.Foods.Commands.CreateFood;
using Application.Features.Foods.Commands.DeleteFood;
using Application.Features.Foods.Commands.UpdateFood;
using Application.Features.Foods.Dtos;
using Application.Features.Foods.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Foods.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Food, CreateFoodCommand>().ReverseMap();
        CreateMap<Food, CreateFoodDto>().ReverseMap();
        CreateMap<Food, UpdateFoodCommand>().ReverseMap();
        CreateMap<Food, UpdateFoodDto>().ReverseMap();
        CreateMap<Food, DeleteFoodCommand>().ReverseMap();
        CreateMap<Food, DeleteFoodDto>().ReverseMap();
        CreateMap<Food, FoodDto>().ReverseMap();
        CreateMap<Food, FoodListDto>().ForMember(c => c.FoodAqueousAnhydrousTypeName, opt => opt.MapFrom(c => c.FoodAqueousAnhydrousType.FoodAqueousAnhydrousTypeName));                            
        CreateMap<IPaginate<Food>, FoodListModel>().ReverseMap();
    }
}