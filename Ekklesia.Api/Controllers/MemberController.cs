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
    public class MemberController : ControllerBase
    {
        private readonly IMemberBusiness _memberBusiness;

        public MemberController(IMemberBusiness memberBusiness)
        {
            this._memberBusiness = memberBusiness;
        }


        [HttpGet]
        public async Task<IEnumerable<MemberDTO>> Get()
        {
            return await _memberBusiness.AllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(string id)
        {
            var response = await _memberBusiness.FindSync(id);
            if (response.status == ResponseStatus.NotFound) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] MemberDTO member)
        {
            var result = await _memberBusiness.AddAsync(member);
            if (result.status == ResponseStatus.BadRequest) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] MemberDTO member)
        {
            var response = await _memberBusiness.UpdateAsync(member);
            if (response.status == ResponseStatus.NotFound) return NotFound(response);
            if (response.status == Entities.Enums.ResponseStatus.BadRequest) return BadRequest(member);
            return Ok(response);
        }

    }
}
