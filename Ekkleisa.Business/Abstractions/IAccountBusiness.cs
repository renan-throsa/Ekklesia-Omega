
using Ekklesia.Application.Models;

namespace Ekklesia.Application.Abstractions
{
    public interface IAccountBusiness
    {
        Task<OperationResultModel> SignUp(SignUpModel model);
        Task<OperationResultModel> SignIn(SignInModel model);
    }
}
