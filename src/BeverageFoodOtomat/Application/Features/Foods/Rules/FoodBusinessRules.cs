using Application.Features.Foods.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Foods.Rules
{
    public class FoodBusinessRules: BaseBusinessRules
    {
        private readonly IFoodRepository _foodRepository;

        public FoodBusinessRules(IFoodRepository foodRepository)
        {
            _foodRepository =foodRepository;
        }
        public async Task BeveragePlotCanNotBeDuplicatedWhenInserted(int plot)
        {
            Food? result = await _foodRepository.GetAsync(b => b.PlotNumber == plot);
            if (Convert.ToInt32(result) < 0 && Convert.ToInt32(result) < 20) throw new BusinessException(FoodMessages.FoodPlotExists);
        }
    }
}
