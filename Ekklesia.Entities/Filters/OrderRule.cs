namespace Ekklesia.Entities.Filters
{

    public class OrderRule
    {
        public string Field { get; set; }

        public OrderType Direction { get; set; }

        public OrderRule()
        {
            this.Field = string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
