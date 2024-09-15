
using Ekkleisa.Business.Models;

namespace Ekkleisa.Business.Abstractions
{
    public interface IAccountBusiness
    {
        Task<OperationResultModel> SignUp(SignUpModel model);
        Task<OperationResultModel> SignIn(SignInModel model);
    }
}
