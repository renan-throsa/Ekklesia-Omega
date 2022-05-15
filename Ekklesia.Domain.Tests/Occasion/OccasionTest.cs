using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using Ekklesia.UnitTesting.Occasion;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class OccasionTest : BaseTest<OccasionDTO, OccasionValidation>
    {
        private OccasionBuilder OccasionBuilder;

        public OccasionTest()
        {
            this.OccasionBuilder = new OccasionBuilder();
        }

        [Fact]
        public void Test_InvalideUpperDate()
        {
            DTO.StartTime = DateTime.Now.AddDays(1);
            var result = IsValid(nameof(DTO.StartTime));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Test_InvalideLowerDate()
        {
            DTO.StartTime = DateTime.Now.AddDays(-31);
            var result = IsValid(nameof(DTO.StartTime));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Test_Date()
        {
            DTO.StartTime = DateTime.Now;
            var result = IsValid(nameof(DTO.StartTime));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestInvalide_Host()
        {
            DTO.Host = null;
            var result = IsValid(nameof(DTO.Host));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestInvalide_Attendees()
        {
            DTO.Attendees = null;
            var result = IsValid(nameof(DTO.Attendees));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Test_BAPTISM()
        {
            OccasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO });

            var result = IsValid(OccasionBuilder.Build());

            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestBAPTISM_WithInvalidAttendees()
        {
            OccasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER });

            var result = IsValid(OccasionBuilder.Build());
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestBAPTISM_WithInvalidHost()
        {
            OccasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                 //.WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                 .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO });


            var result = IsValid(OccasionBuilder.Build());
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestBAPTISM_WithInvalidPlace()
        {
            OccasionBuilder
                 .WithType(OccasionType.BAPTISM)
                 //.WithPlace()
                 .WithStarTime(DateTime.Today)
                 .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                 .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO });

            var result = IsValid(OccasionBuilder.Build());
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestATYPICAL()
        {
            OccasionBuilder
                .WithType(OccasionType.ATYPICAL)
                .WithDescription()
                .WithStarTime(DateTime.Today);

            var result = IsValid(OccasionBuilder.Build());

            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestATYPICAL_WithoutDescription()
        {
            OccasionBuilder
                .WithType(OccasionType.ATYPICAL)
                .WithStarTime(DateTime.Today);

            var result = IsValid(OccasionBuilder.Build());

            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestCELL()
        {
            OccasionBuilder
               .WithType(OccasionType.CELL)
               .WithNumberOfConvertions(1);

            var result = IsValid(OccasionBuilder.Build());

            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestCELLWIth_InvalidNumberOfConvertions()
        {
            OccasionBuilder
               .WithType(OccasionType.CELL)
               .WithNumberOfConvertions(-1);

            var result = IsValid(OccasionBuilder.Build());

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Test_REUNIAOLIDERANÇA()
        {
            OccasionBuilder
                .WithType(OccasionType.REUNIAOLIDERANÇA)
                .WithStarTime(DateTime.Today)
                .WithEndTime(DateTime.Today.AddHours(2))
                .WithTopic()
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO });

            var result = IsValid(OccasionBuilder.Build());

            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestREUNIAOLIDERANÇA_WithInvalidTopic()
        {
            OccasionBuilder
                .WithType(OccasionType.REUNIAOLIDERANÇA)
                .WithStarTime(DateTime.Today)
                .WithEndTime(DateTime.Today.AddHours(2))
                //.WithTopic()
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO });

            var result = IsValid(OccasionBuilder.Build());

            Assert.True(result.IsValid);
        }
    }
}
