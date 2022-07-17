using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;

namespace Ekklesia.IntegrationTesting.Builders
{

    internal class MemberBuilder
    {
        private string Name { get; set; }
        private string Phone { get; set; }
        private string Photo { get; set; }
        private Role Role { get; set; }

        public MemberBuilder()
        {
            Name = string.Empty;
            Phone = string.Empty;
            Photo = string.Empty;
        }

        public MemberBuilder WithRole(Role role = Entities.Entities.Role.MEMBRO)
        {
            this.Role = role;
            return this;
        }

        public MemberBuilder WithPhoto(string photo = "FBQUFBQYGBQgIBwgICwoJCQoLEQwNDA0MERoQExAQExAaFxsWFRYbFykgHBwgKS8nJScvOTMzOUdER11dff/CABEIAeoCvAMBIQACEQEDEQH")
        {
            this.Photo = photo;
            return this;
        }

        public MemberBuilder WithPhone(string phone = "67983468003")
        {
            this.Phone = phone;
            return this;
        }

        public MemberBuilder WithName(string name = "Julius Asiagenus")
        {
            this.Name = name;
            return this;
        }

        public MemberDTO Build()
        {
            return new MemberDTO
            {
                Name = Name,
                Phone = Phone,
                Photo = Photo,
                Role = Role
            };
        }
    }
}
