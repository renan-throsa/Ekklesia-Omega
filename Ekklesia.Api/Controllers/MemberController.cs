using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    
    public class MemberController : ApiController
    {
        private readonly IMemberBusiness _memberBusiness;

        public MemberController(IMemberBusiness memberBusiness)
        {
            this._memberBusiness = memberBusiness;
        }

        [HttpPost($"{nameof(Browse)}")]
        public ActionResult<Response> Browse([FromBody] BaseFilter<Member, MemberDTO> filter)
        {
            var response = _memberBusiness.Browse(filter);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

        [HttpGet($"{nameof(All)}")]
        public ActionResult<Response> All()
        {
            var response = _memberBusiness.All();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Read([FromRoute] string id)
        {
            var response = await _memberBusiness.FindSync(id);
            if (response.Status == ResponseStatus.Found) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpPost($"{nameof(Add)}")]
        public async Task<ActionResult<Response>> Add([FromForm] MemberDTO member)
        {
            var response = await _memberBusiness.AddAsync(member);
            if (response.Status == ResponseStatus.Created) return Ok(response);
            return ErrorResponse(response);
        }

        [HttpPut($"{nameof(Edit)}")]
        public async Task<ActionResult<Response>> Edit([FromForm] MemberDTO member)
        {
            var response = await _memberBusiness.UpdateAsync(member);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

    }
}
