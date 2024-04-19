using Asp.Versioning;
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
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ApiController
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
            var response = _memberBusiness.Browse(filter);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response>> Read([FromRoute] string id)
        {
            var response = await _memberBusiness.FindSync(id);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<ActionResult<Response>> Add([FromBody] MemberDTO member)
        {
            var response = await _memberBusiness.AddAsync(member);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

        [HttpPut]
        [Route(nameof(Edit))]
        public async Task<ActionResult<Response>> Edit([FromBody] MemberDTO member)
        {
            var response = await _memberBusiness.UpdateAsync(member);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

    }
}
