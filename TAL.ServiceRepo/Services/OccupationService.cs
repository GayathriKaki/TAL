using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;

using TAL.ServiceRepository.Interfaces;


namespace TAL.ServiceRepository.Services
{


    public class OccupationService : IOccupationService
    {
        private readonly DBContext _dbcontext;
  
        public OccupationService(DBContext context)
        {
            _dbcontext = context;
           
        }
        public async Task<IEnumerable<Occupation>> GetAllOccupations()
        {
            return await _dbcontext.Occupations.ToListAsync() as IQueryable<Occupation>;          
            

        }

    }
}
