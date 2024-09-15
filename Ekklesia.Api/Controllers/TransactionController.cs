using Ekkleisa.Business.Abstractions;
using Ekkleisa.Business.Models;
using Ekklesia.Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{

    public class TransactionController : BaseController
    {
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionBusiness memberBusiness)
        {
            this._transactionBusiness = memberBusiness;
        }


        [HttpPost($"{nameof(Browse)}")]
        public ActionResult<TransactionFilter> Browse([FromBody] BaseFilterParams filterParams)
        {
            var result = _transactionBusiness.Browse(filterParams);
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ViewTransactionModel>> Get(string id)
        {
            var result = await _transactionBusiness.FindById(id);           
            return CustomResponse(result);
        }


        [HttpPost($"{nameof(Add)}")]
        public async Task<ActionResult<string>> Add([FromForm] SaveTransactionModel transaction)
        {
            var result = await _transactionBusiness.Insert(transaction);
            return CustomResponse(result);
        }

        [HttpPut($"{nameof(Edit)}")]
        public async Task<ActionResult<string>> Edit([FromForm] EditTransactionModel transaction)
        {
            var result = await _transactionBusiness.Update(transaction);
            return CustomResponse(result);
        }

    }
}
