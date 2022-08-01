using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Business;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using Humanizer;
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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionBusiness memberBusiness)
        {
            this._transactionBusiness = memberBusiness;
        }


        [HttpGet]
        public async Task<IEnumerable<TransactionDTO>> Browse()
        {
            return await _transactionBusiness.AllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(string id)
        {
            var response = await _transactionBusiness.FindSync(id);
            if (response.status == ResponseStatus.NotFound) return NotFound(id);
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] TransactionDTO transaction)
        {
            var result = await _transactionBusiness.AddAsync(transaction);
            if (result.status == ResponseStatus.BadRequest) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] TransactionDTO transaction)
        {
            var response = await _transactionBusiness.UpdateAsync(transaction);
            if (response.status == ResponseStatus.NotFound) return NotFound(transaction.Id);
            if (response.status == ResponseStatus.BadRequest) return BadRequest(transaction);
            return Ok(response);
        }

    }
}
