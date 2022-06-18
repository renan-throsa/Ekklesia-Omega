using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<TransactionDTO>> Get(string id)
        {
            TransactionDTO transaction = await _transactionBusiness.FindSync(id);
            if (transaction != null) return Ok(transaction);
            return NotFound(id);
        }

        
        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] TransactionDTO transaction)
        {
            var result = await _transactionBusiness.AddAsync(transaction);
            if (!result.success) return BadRequest(result);
            var url = Url.Action("Get", new { transaction.Id });
            return Created(url, transaction.Id);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] TransactionDTO transactionDTO)
        {
            TransactionDTO transaction = await _transactionBusiness.FindSync(transactionDTO.Id);
            if (transaction == null) return NotFound(transaction.Id);

            var result = await _transactionBusiness.UpdateAsync(transactionDTO);
            if (!result.success) return BadRequest(result);
            return Ok(result);
        }
       
    }
}
