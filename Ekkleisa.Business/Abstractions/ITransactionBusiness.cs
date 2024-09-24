
using Ekklesia.Application.Models;
using Ekklesia.Domain.Filters;

namespace Ekklesia.Application.Abstractions
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
