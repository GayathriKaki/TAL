using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TAL.EF.Models;
using TAL.ServiceRepository.Interfaces;

namespace TAL.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calculationService;
        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
           
        }
        [Route("Calculate")]
        [HttpPost]
        public async Task<decimal> CalculateTotal([FromBody] Member member)
        {
          
            var result = await _calculationService.CalculateTotal(member);
            return (result);
        }
    }
}
