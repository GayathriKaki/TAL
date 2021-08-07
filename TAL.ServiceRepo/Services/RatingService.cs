using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;
using TAL.ServiceRepository.Interfaces;


namespace TAL.ServiceRepo.Services
{
  public  class RatingService: IRatingService
    {
        private readonly DBContext _dbcontext;
        public async Task<Rating> GetRating(int occupationId)
        {

            var ratings = await (from occ in _dbcontext.Occupations
                        join rating in _dbcontext.Ratings on occ.RatingId equals rating.RatingId
                        select new { rating }).ToListAsync() as IQueryable<Rating>;            

            return ratings.FirstOrDefault();

        }
    }
}
