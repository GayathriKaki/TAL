using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;
using TAL.ServiceRepository.Interfaces;

namespace TAL.ServiceRepo.Services
{
   public class CalculationService : ICalculationService
    {
        public async Task<decimal> CalculateTotal(Member member)
        {
            RatingService ratingServ = new RatingService();

            var age = member.Age;
            var factor=member.Occupation.Rating.Factor;
            // var rating =await ratingServ.GetRating(member.OccupationId);
            if (age > 0)
                return (decimal)((member.DeathSumInsured * factor) / (100 * 12 * age));
            else
                return 0;
        }
    }
}
