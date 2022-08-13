using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekkleisa.Business.Contract.IBusiness
{
    public interface IMemberBusiness : IBaseBusiness<Member, MemberDTO>, IFilterGridService<Member>
    {
        IEnumerable<Member> FilterMembers(MemberFilter filter);
    }
}
