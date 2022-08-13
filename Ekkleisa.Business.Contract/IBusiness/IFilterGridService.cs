using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;

namespace Ekkleisa.Business.Contract.IBusiness
{
    public interface IFilterGridService<T> where T : IEntity
    {
        FilterResult FilterGrid(GridFilter filter);

        GridFilter GetFilter();

        void SaveFilter(GridFilter filter);
    }
}
