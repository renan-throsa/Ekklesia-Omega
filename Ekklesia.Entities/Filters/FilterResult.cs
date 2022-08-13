namespace Ekklesia.Entities.Filters
{
    public class FilterResult
    {
        public object Data { get; set; }
        public GridFilter Filter { get; set; }
        public PageInfo PageInfo { get; set; }

        public FilterResult()
        {
            Data = new object();
            Filter = new GridFilter();
            PageInfo = new PageInfo();
        }
    }
}
