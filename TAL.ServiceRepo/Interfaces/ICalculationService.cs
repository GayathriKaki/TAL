﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.EF.Models;

namespace TAL.ServiceRepo.Interfaces
{
    public interface ICalculationService
    {

       // Task<Member> CalculateTotal(Member member);
        Task<decimal> Calculate(decimal DeathSumInsured, int orgId, int age);
    }
}
