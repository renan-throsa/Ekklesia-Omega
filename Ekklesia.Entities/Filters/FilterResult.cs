using Ekklesia.Entities.Entities;
using System.Collections.Generic;

namespace Ekklesia.Entities.Filters
{
    public class FilterResult<TEntity, TObject> where TEntity : IEntity where TObject : IObject<TEntity>
    {
        public IEnumerable<TObject> Data { get; set; }
        public PageInfo PageInfo { get; set; }

        public FilterResult()
        {
            Data = new List<TObject>();
            PageInfo = new PageInfo();
        }
    }
}
