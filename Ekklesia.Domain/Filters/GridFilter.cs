using Ekklesia.Domain.DTOs;
using Ekklesia.Domain.Entities;
using System.Collections.Generic;

namespace Ekklesia.Domain.Filters
{
    public class GridFilter<TEntity> where TEntity : class, IEntity
    {
        public IList<string> Colunms { get; set; }
        public IList<GroupRule> GroupBy { get; set; }
        public BaseFilter<TEntity>? Filter { get; set; }

        public GridFilter()
        {
            Colunms = new List<string>();
            GroupBy = new List<GroupRule>();
        }
    }
}
