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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionBusiness memberBusiness)
        {
            this._transactionBusiness = memberBusiness;
        }

        // GET: api/<Transaction>
        [HttpGet]
        public async Task<IEnumerable<TransactionDTO>> Browse()
        {
            return await _transactionBusiness.AllAsync();
        }

        // GET api/<Transaction>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            TransactionDTO transaction = await _transactionBusiness.FindSync(id);
            if (transaction != null) return Ok(transaction);
            return NotFound(id);
        }

        // POST api/<Transaction>
        [HttpPost]
        public IActionResult Post([FromBody] TransactionDTO transaction)
        {
            _transactionBusiness.AddAsync(transaction);
            var url = Url.Action("Get", new { transaction.Id });
            return Created(url, transaction.Id);
        }

        // PUT api/<Transaction>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TransactionDTO transactionDTO)
        {
            TransactionDTO transaction = await _transactionBusiness.FindSync(transactionDTO.Id);
            if (transaction == null) return NotFound(transaction.Id);
            return Ok(_transactionBusiness.UpdateAsync(transactionDTO));
        }
    }
}
