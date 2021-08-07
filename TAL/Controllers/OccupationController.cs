using Microsoft.AspNetCore.Http;
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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OccupationController : Controller
    {
        private readonly IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;

        }
        [HttpGet]
        [Route("occupations")]
        [ProducesResponseType(typeof(IEnumerable<Occupation>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOccupationList()
        {
            var occupationList = await _occupationService.GetAllOccupations();

            return Ok(occupationList);
        }      

     
    }
}
