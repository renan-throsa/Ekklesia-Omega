using Ekkleisa.Business.Models;
using Ekklesia.Entities.Filters;

namespace Ekkleisa.Business.Abstractions
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
