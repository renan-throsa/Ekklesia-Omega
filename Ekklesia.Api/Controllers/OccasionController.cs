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
    public class OccasionController : ApiController
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
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] OccasionDTO occasion)
        {
            var response = await _occasionBusiness.AddAsync(occasion);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] OccasionDTO occasion)
        {
            var response = await _occasionBusiness.UpdateAsync(occasion);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }
    }
}
