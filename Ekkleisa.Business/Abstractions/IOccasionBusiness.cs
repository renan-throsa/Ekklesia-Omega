using Ekklesia.Application.Models;

namespace Ekklesia.Application.Abstractions
{
    public interface IOccasionBusiness
    {
        OperationResultModel FindAll();

        Task<OperationResultModel> FindById(string id);

        Task<OperationResultModel> Insert(SaveOccasionModel model);

        Task<OperationResultModel> Update(EditOccasionModel model);

        Task<OperationResultModel> Remove(string id);
    }
}
