using System.Collections.Generic;

namespace Ekklesia.Entities.Filters
{
    public class GridFilter
    {
        public IEnumerable<string> Colunms { get; set; }
        public IEnumerable<FilterGroup> GroupBy { get; set; }
        public BaseFilter Filter { get; set; }

        public GridFilter()
        {
            Colunms = new List<string>();
            GroupBy = new List<FilterGroup>();
            Filter = new BaseFilter();
        }
    }
}
