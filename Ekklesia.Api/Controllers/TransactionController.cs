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
    public class TransactionController : ApiController
    {
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionBusiness memberBusiness)
        {
            this._transactionBusiness = memberBusiness;
        }


        [HttpPost($"{nameof(Browse)}")]
        public ActionResult<Response> Browse([FromBody] BaseFilter<Transaction, TransactionDTO> filter)
        {
            return Ok(_transactionBusiness.Browse(filter));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response>> Get(string id)
        {
            var response = await _transactionBusiness.FindSync(id);
            if (response.Status == ResponseStatus.Found) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpPost($"{nameof(Add)}")]
        public async Task<ActionResult<Response>> Add([FromBody] TransactionDTO transaction)
        {
            var response = await _transactionBusiness.AddAsync(transaction);
            if (response.Status == ResponseStatus.Created) return Ok(response);
            return ErrorResponse(response);
        }

        [HttpPut($"{nameof(Edit)}")]
        public async Task<ActionResult<Response>> Edit([FromBody] TransactionDTO transaction)
        {
            var response = await _transactionBusiness.UpdateAsync(transaction);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

    }
}
