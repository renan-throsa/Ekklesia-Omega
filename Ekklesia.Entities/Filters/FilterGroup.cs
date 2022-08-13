namespace Ekklesia.Entities.Filters
{
    public class FilterGroup
    {
        public string Property { get; set; }
        public int Position { get; set; }
        public GridFilterType Type { get; set; }

        public FilterGroup()
        {
            Property = string.Empty;
            Type = new GridFilterType();
        }
    }
}
