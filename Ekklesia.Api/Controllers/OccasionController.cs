using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    
    public class OccasionController : ApiController
    {
        private readonly IOccasionBusiness _occasionBusiness;

        public OccasionController(IOccasionBusiness occasionBusiness)
        {
            this._occasionBusiness = occasionBusiness;
        }

        [HttpGet]
        public IEnumerable<OccasionDTO> All()
        {
            return   _occasionBusiness.All();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(string id)
        {
            var response = await _occasionBusiness.FindSync(id);
            if (response.Status == ResponseStatus.Found) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpPost($"{nameof(Add)}")]
        public async Task<ActionResult<Response>> Add([FromBody] OccasionDTO occasion)
        {
            var response = await _occasionBusiness.AddAsync(occasion);
            if (response.Status == ResponseStatus.Created) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpPut($"{nameof(Edit)}")]
        public async Task<ActionResult<Response>> Edit([FromBody] OccasionDTO occasion)
        {
            var response = await _occasionBusiness.UpdateAsync(occasion);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }
    }
}
