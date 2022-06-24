using Ekklesia.Entities.DTOs;
using System.Threading.Tasks;

namespace Ekkleisa.Business.Contract.IBusiness
{
    public interface IAccountBusiness
    {
        Task<Response> SignUp(SignUpDTO Dto);
        Task<Response> SignIn(SignInDTO Dto);
                
    }
}
