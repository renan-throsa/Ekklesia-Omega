using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Filters;

namespace Ekkleisa.Business.Contract.IBusiness
{
    public interface IFilterBusiness<TEntity, TObject> where TEntity : IEntity where TObject : IObject<TEntity>
    {
        Response Browse(BaseFilter<TEntity, TObject> filter);

        BaseFilter<TEntity, TObject> GetFilter();

        void SaveFilter(BaseFilter<TEntity, TObject> filter);
    }
}
