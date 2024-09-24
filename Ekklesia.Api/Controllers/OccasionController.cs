using Ekklesia.Application.Abstractions;
using Ekklesia.Application.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult All()
        {
            var response = _occasionBusiness.FindAll();
            return CustomResponse(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var response = await _occasionBusiness.FindById(id);
            return CustomResponse(response);
        }


        [HttpPost($"{nameof(Add)}")]
        public async Task<ActionResult> Add([FromBody] SaveOccasionModel model)
        {
            var response = await _occasionBusiness.Insert(model);
            return CustomResponse(response);
        }


        [HttpPut($"{nameof(Edit)}")]
        public async Task<ActionResult> Edit([FromBody] EditOccasionModel model)
        {
            var response = await _occasionBusiness.Update(model);
            return CustomResponse(response);
        }
    }
}
