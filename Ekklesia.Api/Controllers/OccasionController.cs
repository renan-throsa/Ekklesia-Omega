using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
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
        public async Task<ActionResult<OccasionDTO>> Get(string id)
        {
            OccasionDTO occasion = await _occasionBusiness.FindSync(id);
            if (occasion != null) return Ok(occasion);
            return NotFound(id);
        }


        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] OccasionDTO dto)
        {
            var result = await _occasionBusiness.AddAsync(dto);
            if (!result.success) return BadRequest(result);
            var url = Url.Action("Get", new { dto.Id });
            return Created(url, dto.Id);
        }


        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] OccasionDTO dto)
        {
            OccasionDTO occasion = await _occasionBusiness.FindSync(dto.Id);
            if (occasion == null) return NotFound(dto.Id);

            var result = await _occasionBusiness.UpdateAsync(dto);
            if (!result.success) return BadRequest(result);
            return Ok(result);
        }
    }
}
