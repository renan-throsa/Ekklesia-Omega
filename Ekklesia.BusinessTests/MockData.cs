using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Ekklesia.IntegrationTesting
{
    public static class MockData
    {
        public static IEnumerable<Member> Members => new List<Member>
        {
            new Member
            {
                Id = ObjectId.GenerateNewId(),
                Name = "João Silva",
                Phone = "(82) 98314-2106",
                Photo = "joao.jpg",
                Role = Role.MEMBRO,
                BirthDay = new DateTime(1990, 5, 15),
                Active = true
            },
            new Member
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Maria Oliveira",
                Phone = "(82) 98765-4321",
                Photo = "maria.jpg",
                Role = Role.LIDER,
                BirthDay = new DateTime(1985, 8, 25),
                Active = true
            },
            new Member
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Carlos Pereira",
                Phone = "(82) 95512-3456",
                Photo = "carlos.jpg",
                Role = Role.PROFESSOR,
                BirthDay = new DateTime(1978, 3, 10),
                Active = true
            },
            new Member
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Ana Souza",
                Phone = "(82) 94498-7654",
                Photo = "ana.jpg",
                Role = Role.INDEFINIDO,
                BirthDay = new DateTime(1995, 12, 20),
                Active = true
            },
            new Member
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Pedro Lima",
                Phone = "(82) 93345-6789",
                Photo = "pedro.jpg",
                Role = Role.MEMBRO,
                BirthDay = new DateTime(1982, 7, 30),
                Active = true
            }
        };
    }

}
