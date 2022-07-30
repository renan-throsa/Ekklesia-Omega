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
    //[Authorize]
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
        public async Task<ActionResult<MemberDTO>> Get(string id)
        {
            MemberDTO member = await _memberBusiness.FindSync(id);
            if (member == null) return NotFound(id);
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] MemberDTO member)
        {
            var result = await _memberBusiness.AddAsync(member);
            if (!result.success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] MemberDTO dto)
        {
            MemberDTO member = await _memberBusiness.FindSync(dto.Id);
            if (member == null) return NotFound(dto.Id);

            var result = await _memberBusiness.UpdateAsync(dto);
            if (!result.success) return BadRequest(result);
            return Ok(result);
        }

    }
}
