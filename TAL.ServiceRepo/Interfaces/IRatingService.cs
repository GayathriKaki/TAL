using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;

namespace TAL.ServiceRepo.Interfaces
{
    public interface IRatingService
    {
        Task<Rating> GetRating(int occupationId);
        Task<Decimal> GetRatingFactor(int occupationId);
    }
}
