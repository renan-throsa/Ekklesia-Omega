using Ekkleisa.Business.Models;
using Ekklesia.Entities.Entities;
using System;

namespace Ekklesia.IntegrationTesting.Builders
{

    internal class MemberBuilder
    {
        private string Name { get; set; }
        private string Phone { get; set; }
        private string Photo { get; set; }
        private Role Role { get; set; }
        private DateTime BirthDay { get; set; }        

        public MemberBuilder()
        {
            Name = string.Empty;
            Phone = string.Empty;
            Photo = string.Empty;
        }

        public MemberBuilder WithRole(Role role = Role.MEMBRO)
        {
            Role = role;
            return this;
        }

        public MemberBuilder WithPhoto(string photo = "FBQUFBQYGBQgIBwgICwoJCQoLEQwNDA0MERoQExAQExAaFxsWFRYbFykgHBwgKS8nJScvOTMzOUdER11dff/CABEIAeoCvAMBIQACEQEDEQH")
        {
            Photo = photo;
            return this;
        }

        public MemberBuilder WithPhone(string phone = "67983468003")
        {
            Phone = phone;
            return this;
        }

        public MemberBuilder WithName(string name = "Julius Asiagenus")
        {
            Name = name;
            return this;
        }       

        public MemberBuilder WithBirthDay(DateTime birthDay)
        {
            BirthDay = birthDay;
            return this;
        }

        public MemberBuilder WithBirthDay()
        {
            BirthDay = DateTime.Today.AddDays(-1);
            return this;
        }

        public SaveMemberModel Build()
        {
            return new SaveMemberModel
            {
                Name = Name,
                Phone = Phone,
                Photo = Photo,
                Role = Role,
                BirthDay = BirthDay,
            };
        }
    }
}
