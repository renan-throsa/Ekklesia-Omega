using Asp.Versioning;
using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class OccasionController : ControllerBase
    {
        private readonly IOccasionBusiness _occasionBusiness;

        public OccasionController(IOccasionBusiness occasionBusiness)
        {
            this._occasionBusiness = occasionBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<OccasionDTO>> Get()
        {
            return await _occasionBusiness.AllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(string id)
        {
            var response = await _occasionBusiness.FindSync(id);
            if (response.status == ResponseStatus.NotFound) return NotFound(response);
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] OccasionDTO occasion)
        {
            var result = await _occasionBusiness.AddAsync(occasion);
            if (result.status == ResponseStatus.BadRequest) return BadRequest(result);
            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] OccasionDTO occasion)
        {          

            var response = await _occasionBusiness.UpdateAsync(occasion);
            if (response.status == ResponseStatus.NotFound) return NotFound(occasion.Id);
            if (response.status == ResponseStatus.BadRequest) return BadRequest(occasion);
            return Ok(response);
        }
    }
}
