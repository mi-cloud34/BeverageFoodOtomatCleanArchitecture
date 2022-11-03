
using Application.Features.PaymentTypes.Commands.CreatePaymentType;
using Application.Features.PaymentTypes.Commands.DeletePaymentType;
using Application.Features.PaymentTypes.Commands.UpdatePaymentType;
using Application.Features.PaymentTypes.Dtos;
using Application.Features.PaymentTypes.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.PaymentTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PaymentType, CreatePaymentTypeCommand>().ReverseMap();
        CreateMap<PaymentType, CreatePaymentTypeDto>().ReverseMap();
        CreateMap<PaymentType, UpdatePaymentTypeCommand>().ReverseMap();
        CreateMap<PaymentType, UpdatePaymentTypeDto>().ReverseMap();
        CreateMap<PaymentType, DeletePaymentTypeCommand>().ReverseMap();
        CreateMap<PaymentType, DeletePaymentTypeDto>().ReverseMap();
        CreateMap<PaymentType, PaymentTypeDto>().ReverseMap();
        CreateMap<PaymentType, PaymentTypeListDto>().ReverseMap();
        CreateMap < IPaginate<PaymentType>, PaymentTypeListModel>().ReverseMap();
    }
}