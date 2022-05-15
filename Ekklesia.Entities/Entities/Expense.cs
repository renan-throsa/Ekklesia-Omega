namespace Ekklesia.Entities.Entities
{
    public class Expense
    {
        public string Receipt { get; set; }
        public string Description { get; set; }
        public Member Responsable { get; set; }

        public Expense()
        {
            this.Receipt = string.Empty;
            this.Description = string.Empty;
            this.Responsable = new Member();
        }
        
    }
}
