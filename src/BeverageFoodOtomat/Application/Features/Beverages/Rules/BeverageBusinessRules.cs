

using Application.Features.Beverages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Beverages.Rules;

public class BeverageBusinessRules : BaseBusinessRules
{
    private readonly IBeverageRepository _BeverageRepository;
   
    public BeverageBusinessRules(IBeverageRepository BeverageRepository)
    {
        _BeverageRepository = BeverageRepository;
    }

    public async Task BeverageIdShouldExistWhenSelected(int id)
    {
        Beverage? result = await _BeverageRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(BeverageMessages.BeverageNotExists);
    }
    public async Task BeverageNameCanNotBeDuplicatedWhenInserted(int id)
    {
        IPaginate<Beverage> result = await _BeverageRepository.GetListAsync(b => b.Id == id);
        if (result.Items.Any()) throw new BusinessException(BeverageMessages.BeverageNameExists);
    }
    public async Task BeveragePlotCanNotBeDuplicatedWhenInserted(int plot)
    {
       Beverage? result = await _BeverageRepository.GetAsync(b => b.PlotNumber == plot);
        if (Convert.ToInt32( result)<0&& Convert.ToInt32(result) > 11) throw new BusinessException(BeverageMessages.BeveragePlotExists);
    }

}