﻿using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class MemberDTO : BaseDto<Member>
    {
        public string RoleName
        {
            get { return this.Role.GetDescription(); }

        }
        public Role Role { get; set; }

        
        public string Name { get; set; }

        
        public string Phone { get; set; }

        [BsonIgnore]
        public string Photo { get; set; }

        [BsonIgnore]
        public IFormFile? FormFile { get; set; }

        public DateTime BirthDay { get; set; }


        public MemberDTO()
        {
            this.Name = string.Empty;
            this.Phone = string.Empty;
            this.Photo = string.Empty;
            this.Role = Role.INDEFINIDO;
            this.BirthDay = new DateTime();
        }

        public override Member ToEntity(params string[] props)
        {
            if (props == null || props.Length == 0)
            {
                return new Member()
                {
                    Id = string.IsNullOrEmpty(Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                    Name = this.Name,
                    Phone = this.Phone,
                    Photo = this.Photo,
                    Role = this.Role,
                    BirthDay = this.BirthDay,
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
                        propertyInfo.SetValue(member, string.IsNullOrEmpty(Id) ? ObjectId.Empty : ObjectId.Parse(Id));
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
                    if (prop == nameof(BirthDay))
                    {
                        propertyInfo.SetValue(member, BirthDay);
                    }
                }
            }
            return member;

        }        
    }
}
