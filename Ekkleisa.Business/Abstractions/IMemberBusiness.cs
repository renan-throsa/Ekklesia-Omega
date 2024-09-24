using Ekklesia.Application.Models;
using Ekklesia.Domain.Filters;

namespace Ekklesia.Application.Abstractions
{
    public interface IMemberBusiness
    {
        OperationResultModel Browse(BaseFilterParams filter);

        OperationResultModel FindAll();

        Task<OperationResultModel> FindById(string id);

        Task<OperationResultModel> Insert(SaveMemberModel model);

        Task<OperationResultModel> Update(SaveMemberModel model);

        Task<OperationResultModel> Remove(string id);
    }
}
