namespace Ekklesia.Domain.Filters
{
    public class GroupRule
    {
        public string Property { get; set; }
        public int Position { get; set; }
        public GridFilterType Type { get; set; }

        public GroupRule()
        {
            Property = string.Empty;
            Type = new GridFilterType();
        }
    }
}
