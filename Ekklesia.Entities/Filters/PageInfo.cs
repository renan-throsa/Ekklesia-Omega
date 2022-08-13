namespace Ekklesia.Entities.Filters
{
    public class PageInfo
    {
        public int Page { get; set; }
        public int? GroupPageSize { get; set; }
        public int? TablePageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
