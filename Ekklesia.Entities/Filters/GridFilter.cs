using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using System.Collections.Generic;

namespace Ekklesia.Entities.Filters
{
    public class GridFilter<TEntity, TObject> where TEntity : class, IEntity where TObject : BaseDto<TEntity>, new()
    {
        public IList<string> Colunms { get; set; }
        public IList<GroupRule> GroupBy { get; set; }
        public BaseFilter<TEntity, TObject>? Filter { get; set; }

        public GridFilter()
        {
            Colunms = new List<string>();
            GroupBy = new List<GroupRule>();
        }
    }
}
