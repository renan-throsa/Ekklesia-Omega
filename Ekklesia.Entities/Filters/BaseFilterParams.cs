using System.Collections.Generic;

namespace Ekklesia.Entities.Filters
{
    public class BaseFilterParams
    {
        private const int DEFAULT_ROWS_PER_PAGE = 10;

        public List<OrderRule> OrderBy { get; set; }
        public List<FilterRule> FilterBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }       


        public BaseFilterParams(int pageNumber = 1, int pageSize = DEFAULT_ROWS_PER_PAGE)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            FilterBy = new List<FilterRule>();
            OrderBy = new List<OrderRule>();
        }
        

    }
}
