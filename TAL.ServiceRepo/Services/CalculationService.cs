using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;
using TAL.ServiceRepo.Interfaces;

namespace TAL.ServiceRepo.Services
{
   public class CalculationService : ICalculationService
    {
        private IRatingService _ratingServ;
       

        public CalculationService(IRatingService ratingService)
        {
            _ratingServ = ratingService;
        }       

        public async Task<decimal> Calculate(decimal DeathSumInsured, int orgId, int age)
        {
            decimal TotalValue;
            var rating = await _ratingServ.GetRatingFactor(orgId);
            if (age > 0)
                TotalValue = (decimal)((DeathSumInsured * rating) / (100 * 12 * age));
            else
                TotalValue = 0;

            return TotalValue;
        }
    }
}
