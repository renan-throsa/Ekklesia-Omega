using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        private readonly IOccasionBusiness _occasionBusiness;

        public OccasionController(IOccasionBusiness occasionBusiness)
        {
            this._occasionBusiness = occasionBusiness;
        }

        // GET: api/<Occasion>
        [HttpGet]
        public async Task<IEnumerable<OccasionDTO>> Get()
        {
            return await _occasionBusiness.AllAsync();
        }

        // GET api/<Occasion>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            OccasionDTO occasion = await _occasionBusiness.FindSync(id);
            if (occasion != null) return Ok(occasion);
            return NotFound(id);
        }

        // POST api/<Occasion>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OccasionDTO dto)
        {
            await _occasionBusiness.AddAsync(dto);
            var url = Url.Action("Get", new { dto.Id });
            return Created(url, dto.Id);
        }

        // PUT api/<User>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OccasionDTO dto)
        {
            OccasionDTO occasion = await _occasionBusiness.FindSync(dto.Id);
            if (occasion == null) return NotFound(dto.Id);
            return Ok(_occasionBusiness.UpdateAsync(dto));
        }
    }
}
