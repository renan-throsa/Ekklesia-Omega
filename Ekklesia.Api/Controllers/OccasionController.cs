using Ekkleisa.Business.Abstractions;
using Ekkleisa.Business.Models;
using Ekklesia.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{
    
    public class OccasionController : BaseController
    {
        private readonly IOccasionBusiness _occasionBusiness;

        public OccasionController(IOccasionBusiness occasionBusiness)
        {
            _occasionBusiness = occasionBusiness;
        }

        [HttpGet]
        public ActionResult<Response> All()
        {
            var response = _occasionBusiness.FindAll();
            return CustomResponse(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(string id)
        {
            var response = await _occasionBusiness.FindById(id);
            return CustomResponse(response);
        }


        [HttpPost($"{nameof(Add)}")]
        public async Task<ActionResult<Response>> Add([FromBody] SaveOccasionModel model)
        {
            var response = await _occasionBusiness.Insert(model);
            return CustomResponse(response);
        }


        [HttpPut($"{nameof(Edit)}")]
        public async Task<ActionResult<Response>> Edit([FromBody] EditOccasionModel model)
        {
            var response = await _occasionBusiness.Update(model);
            return CustomResponse(response);
        }
    }
}
