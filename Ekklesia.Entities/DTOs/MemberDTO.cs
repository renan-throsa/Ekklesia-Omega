using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;

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
            this.Role = null;
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
                    Role = this.Role.Value
                };
            }

            var member = new Member();
            Type type = member.GetType();
            foreach (string prop in props)
            {
                var propertyInfo = type.GetProperty(prop);
                if (propertyInfo != null)
                {

                    //propertyInfo.SetValue(member, value);
                    if (prop == nameof(Id))
                    {
                        propertyInfo.SetValue(member, ObjectId.Parse(Id));
                    }
                    if (prop == nameof(Name))
                    {
                        propertyInfo.SetValue(member, Name);
                    }
                    if (prop == nameof(Phone))
                    {
                        propertyInfo.SetValue(member, Phone);
                    }
                    if (prop == nameof(Photo))
                    {
                        propertyInfo.SetValue(member, Photo);
                    }
                    if (prop == nameof(Role))
                    {
                        propertyInfo.SetValue(member, Role);
                    }
                }
            }
            return member;

        }
    }
}
