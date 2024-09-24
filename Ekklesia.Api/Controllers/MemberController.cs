

using Ekklesia.Application.Abstractions;
using Ekklesia.Application.Models;
using Ekklesia.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{

    public class MemberController : BaseController
    {
        private readonly IMemberBusiness _memberBusiness;

        public MemberController(IMemberBusiness memberBusiness)
        {
            _memberBusiness = memberBusiness;
        }

        [HttpPost($"{nameof(Browse)}")]
        public ActionResult<MemberFilter> Browse([FromBody] BaseFilterParams filterParams)
        {
            var result = _memberBusiness.Browse(filterParams);
            return CustomResponse(result);
        }

        [HttpGet($"{nameof(All)}")]
        public ActionResult<IEnumerable<SimpleViewMemberModel>> All()
        {
            var result = _memberBusiness.FindAll();
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewMemberModel>> Read([FromRoute] string id)
        {
            var result = await _memberBusiness.FindById(id);
            return CustomResponse(result);
        }

        [HttpPost($"{nameof(Add)}")]
        public async Task<ActionResult<string>> Add([FromForm] SaveMemberModel member)
        {
            var result = await _memberBusiness.Insert(member);
            return CustomResponse(result);
        }

        [HttpPut($"{nameof(Edit)}")]
        public async Task<ActionResult<string>> Edit([FromForm] SaveMemberModel member)
        {
            var result = await _memberBusiness.Update(member);
            return CustomResponse(result);
        }

    }
}
