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
    public class MemberController : ControllerBase
    {
        private readonly IMemberBusiness _memberBusiness;        

        public MemberController(IMemberBusiness memberBusiness)
        {
            this._memberBusiness = memberBusiness;
        }

        // GET: api/<Member>
        [HttpGet]
        public async Task<IEnumerable<MemberDTO>> Get()
        {
            return await _memberBusiness.AllAsync();
        }

        // GET api/<Member>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            MemberDTO member = await _memberBusiness.FindSync(id);
            if (member != null) return Ok(member);
            return NotFound(id);
        }

        // POST api/<Member>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MemberDTO dto)
        {
            await _memberBusiness.AddAsync(dto);
            var url = Url.Action("Get", new { dto.Id });
            return Created(url, dto.Id);
        }

        // PUT api/<User>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MemberDTO dto)
        {
            MemberDTO member = await _memberBusiness.FindSync(dto.Id);
            if (member == null) return NotFound(dto.Id);
            return Ok(_memberBusiness.UpdateAsync(dto));
        }

    }
}
