using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;
using TAL.ServiceRepo.Interfaces;


namespace TAL.ServiceRepo.Services
{
  public  class RatingService: IRatingService
    {
      
        private readonly DBContext _dbcontext;

        public RatingService(DBContext context)
        {
            _dbcontext = context;

        }
        public async Task<Rating> GetRating(int occupationId)
        {

            var l = await _dbcontext.Occupations.Where(a => a.OccupationId == occupationId).ToListAsync();// ..FirstOrDefault();//?.Rating;

            var ratings = await (from occ in _dbcontext.Occupations
                        join rating in _dbcontext.Ratings on occ.RatingId equals rating.RatingId
                        select new { rating }).ToListAsync() as IEnumerable<Rating>;            

            return ratings.FirstOrDefault();

        }

        public async Task<Decimal> GetRatingFactor(int occupationId)
        {

           // var l = await _dbcontext.Occupations.Where(a => a.OccupationId == occupationId).ToListAsync();// ..FirstOrDefault();//?.Rating;

            var ratings = await (from occ in _dbcontext.Occupations
                                 join rating in _dbcontext.Ratings on occ.RatingId equals rating.RatingId where occ.OccupationId == occupationId
                                 select new { rating }).ToListAsync();

            return (decimal)ratings.FirstOrDefault().rating.Factor;

        }
    }
}
