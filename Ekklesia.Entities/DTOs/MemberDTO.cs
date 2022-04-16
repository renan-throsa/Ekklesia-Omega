using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Reflection;

namespace Ekklesia.Entities.DTOs
{
    public class MemberDTO : BaseDto<Member>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Role? Role { get; set; }

        public MemberDTO()
        {
            this.Name = string.Empty;
            this.Phone = string.Empty;
            this.Photo = string.Empty;
        }

        public override Member ToEntity(params string[] props)
        {
            if (props == null || props.Length == 0)
            {
                return new Member()
                {
                    Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                    Name = this.Name,
                    Phone = this.Phone,
                    Photo = this.Photo,
                    Role = this.Role.HasValue ? this.Role.Value : Entities.Role.Membro
                };
            }

            var member = new Member();
            Type type = member.GetType();
            foreach (string prop in props)
            {
                PropertyInfo? propertyInfo = type.GetProperty(prop);
                var value = this.GetType()?.GetProperty(prop)?.GetValue(this);
                propertyInfo?.SetValue(member, value);
            }
            return member;


        }
    }
}
