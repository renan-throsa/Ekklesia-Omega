namespace Ekklesia.Domain.Filters
{
    public class FilterRule
    {
        public FilterType Type { get; set; }
        public string Field { get; set; }
        public string Arg { get; set; }

        public FilterRule()
        {
            this.Field = string.Empty;
            this.Arg = string.Empty;
        }
        
    }
}
