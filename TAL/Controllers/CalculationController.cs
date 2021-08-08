using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TAL.EF.Models;
using TAL.ServiceRepo.Interfaces;

namespace TAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calculationService;
        private readonly IMapper _mapper;
        public CalculationController(ICalculationService calculationService, IMapper mapper)
        {
            _calculationService = calculationService;
            _mapper = mapper;
        }
       

        [Route("GetTotal")]
        [HttpGet]
        [ProducesResponseType(typeof(Decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTotal(decimal DeathSumInsured,int orgId,int age)
        {
            try
            {
                var result = await _calculationService.Calculate(DeathSumInsured, orgId, age);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return this.Content(null, ex.Message);
            }

        }
    }
}
