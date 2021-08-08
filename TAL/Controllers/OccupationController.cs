using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TAL.ServiceRepo.Interfaces;
using TAL.ServiceRepo.Models;

namespace TAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : Controller
    {
        private readonly IOccupationService _occupationService;
        private readonly IMapper _mapper;

        public OccupationController(IOccupationService occupationService, IMapper mapper)
        {
            _occupationService = occupationService;
            _mapper = mapper;

        }
        [HttpGet]
        [Route("occupations")]
        [ProducesResponseType(typeof(IEnumerable<TAL.ServiceRepo.Models.Occupation>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOccupationList()
        
        {
            try
            {
                var occupationList = await _occupationService.GetAllOccupations();

                var list = _mapper.Map<IEnumerable<TAL.ServiceRepo.Models.Occupation>>(occupationList);
                return Ok(list);
            }
           catch(Exception ex)
            {
                return this.Content(null, ex.Message);
            }
          
        }

        [HttpGet]
        [Route("states")]
        [ProducesResponseType(typeof(List<State>), (int)HttpStatusCode.OK)]
        public IActionResult GetStateList()

        {
            List<State> stateList = new List<State>();
            stateList.Add(new State { StateId = 1, StateName = "state 1" });

            stateList.Add(new State { StateId = 2, StateName = "state 2" });

            return  Ok(stateList);

        }


    }
}
