﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;

namespace TAL.ServiceRepository.Interfaces
{
   public interface IOccupationService
    {
       Task<IEnumerable<Occupation>> GetAllOccupations();
       
    }
}
