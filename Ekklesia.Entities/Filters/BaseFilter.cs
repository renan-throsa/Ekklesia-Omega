using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ekklesia.Entities.Filters
{
    public class BaseFilter
    {
        private const int DEFAULT_ROWS_PER_PAGE = 10;

        [DataMember(Name = "orderByColumns")]
        public List<FilterOrderBy> OrderByColumns { get; set; }

        [DataMember(Name = "filterList")]
        public List<FilterDto> FilterList { get; set; }

        [DataMember(Name = "paginated")]
        public bool Paginated { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "pageSize")]
        public int PageSize { get; set; }

        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        public virtual bool FiltroAvancado { get; set; }

        public virtual string TextoFiltroSimples { get; set; }

        public int PageTotal => (int)Math.Ceiling((double)TotalCount / (double)PageSize);

        public int SkipSize => Page * PageSize;

        public BaseFilter(List<FilterOrderBy>? orderByColumn = null, bool paginated = true, int page = 0, int pageSize = 10)
        {
            OrderByColumns = orderByColumn ?? new List<FilterOrderBy>
            {
                new FilterOrderBy()
            };
            Paginated = paginated;
            Page = page;
            PageSize = pageSize;
            FilterList = new List<FilterDto>();
            TextoFiltroSimples = string.Empty;
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
