using System.Collections.Generic;

namespace Ekklesia.Entities.Filters
{
    public class FilterResult<TModel> where TModel : new()
    {
        public IEnumerable<TModel> Data { get; set; }
        public PageInfo PageInfo { get; set; }

        public FilterResult()
        {
            Data = new List<TModel>();
            PageInfo = new PageInfo();
        }
    }
}
