using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route(nameof(Browse))]
        public ActionResult<Response> Browse([FromBody] BaseFilter<Member, MemberDTO> filter)
        {
            return Ok(_memberBusiness.Browse(filter));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response>> Read([FromRoute] string id)
        {
            var response = await _memberBusiness.FindSync(id);
            if (response.status == ResponseStatus.NotFound) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<ActionResult<Response>> Add([FromBody] MemberDTO member)
        {
            var result = await _memberBusiness.AddAsync(member);
            if (result.status == ResponseStatus.BadRequest) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        [Route(nameof(Edit))]
        public async Task<ActionResult<Response>> Edit([FromBody] MemberDTO member)
        {
            var response = await _memberBusiness.UpdateAsync(member);
            if (response.status == ResponseStatus.NotFound) return NotFound(response);
            if (response.status == Entities.Enums.ResponseStatus.BadRequest) return BadRequest(member);
            return Ok(response);
        }

    }
}
