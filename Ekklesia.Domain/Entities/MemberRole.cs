namespace Ekklesia.Domain.Entities
{
    public class MemberRole
    {
        private string _name;

        public string Name
        {
            get { return this.Role.ToString(); }
            set { _name = value; }
        }

        public Role Role { get; set; }

        public MemberRole()
        {
            _name = string.Empty;
        }
    }
}
