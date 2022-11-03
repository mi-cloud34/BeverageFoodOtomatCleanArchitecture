
using Application.Features.Payments.Commands.CreatePayment;
using Application.Features.Payments.Commands.DeletePayment;
using Application.Features.Payments.Commands.UpdatePayment;
using Application.Features.Payments.Dtos;
using Application.Features.Payments.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Payments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Payment, CreatePaymentCommand>().ReverseMap();
        CreateMap<Payment, CreatePaymentDto>().ReverseMap();
        CreateMap<Payment, UpdatePaymentCommand>().ReverseMap();
        CreateMap<Payment, UpdatePaymentDto>().ReverseMap();
        CreateMap<Payment, DeletePaymentCommand>().ReverseMap();
        CreateMap<Payment, DeletePaymentDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Payment, PaymentListDto>().ForMember(c => c.PaymentTypeName, opt => opt.MapFrom(c => c.PaymentType.PaymentTypeName))
                                        .ForMember(c => c.CustomerName, opt => opt.MapFrom(c => c.Customer.CustomerName))
                                        .ForMember(c => c.FoodName,opt => opt.MapFrom(c => c.Food.FoodName))
                                        .ForMember(c => c.BeverageName,opt => opt.MapFrom(c => c.Beverage.BeverageName));
        CreateMap<IPaginate<Payment>, PaymentListModel>().ReverseMap();
    }
}