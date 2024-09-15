
using Ekkleisa.Business.Models;
using Ekklesia.Entities.Filters;

namespace Ekkleisa.Business.Abstractions
{
    public interface ITransactionBusiness
    {
        OperationResultModel Browse(BaseFilterParams filter);
        OperationResultModel FindAll();

        Task<OperationResultModel> FindById(string id);

        Task<OperationResultModel> Insert(SaveTransactionModel model);

        Task<OperationResultModel> Update(EditTransactionModel model);                
    }
}
