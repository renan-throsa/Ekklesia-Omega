namespace Ekklesia.Entities.Entities
{
    public class Expense : Transaction
    {
        public string Receipt { get; set; }
        public string Description { get; set; }
    }
}
