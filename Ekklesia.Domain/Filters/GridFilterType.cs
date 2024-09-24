namespace Ekklesia.Domain.Filters
{
    public class GridFilterType
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Format { get; set; }

        public GridFilterType()
        {
            Name = string.Empty;
            Unit = string.Empty;
            Format = string.Empty;
        }
    }
}
