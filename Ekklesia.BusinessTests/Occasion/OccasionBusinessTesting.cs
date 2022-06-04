using AutoFixture;
using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.IntegrationTesting.Builders;
using MongoDB.Bson;
using System;
using Xunit;

namespace Ekklesia.IntegrationTesting
{
    public class OccasionBusinessTesting : IClassFixture<DependencySetupFixture>
    {
        private readonly OccasionBuilder _occasionBuilder;
        private readonly IOccasionBusiness _occasionBusiness;
        private readonly Fixture _fixture;

        public OccasionBusinessTesting(DependencySetupFixture fixture)
        {
            this._occasionBusiness = fixture.GetRequiredService<IOccasionBusiness>() ?? throw new ArgumentNullException(nameof(IOccasionBusiness));
            this._fixture = new Fixture();
            this._occasionBuilder = new OccasionBuilder();
        }

        [Fact]
        public void Test_BAPTISM()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO })
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.NotEmpty(occasion.Id);
        }

        [Fact]
        public void TestBAPTISM_WithInvalidAttendees()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.Empty(occasion.Id);
        }

        [Fact]
        public void TestBAPTISM_WithInvalidHost()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                 //.WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                 .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO })
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.Empty(occasion.Id);
        }

        [Fact]
        public void TestBAPTISM_WithInvalidPlace()
        {
            var occasion = _occasionBuilder
                 .WithType(OccasionType.BAPTISM)
                 //.WithPlace()
                 .WithStarTime(DateTime.Today)
                 .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                 .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO })
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.Empty(occasion.Id);
        }

        [Fact]
        public void TestATYPICAL()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.ATYPICAL)
                .WithDescription()
                .WithStarTime(DateTime.Today)
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.NotEmpty(occasion.Id);
        }

        [Fact]
        public void TestATYPICAL_WithoutDescription()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.ATYPICAL)
                .WithStarTime(DateTime.Today)
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.Empty(occasion.Id);
        }

        [Fact]
        public void TestCELL()
        {
            var occasion = _occasionBuilder
               .WithType(OccasionType.CELL)
               .WithStarTime(DateTime.Today)
               .WithNumberOfConvertions(1)
               .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.NotEmpty(occasion.Id);
        }

        [Fact]
        public void TestCELL_WIthInvalidNumberOfConvertions()
        {
            var occasion = _occasionBuilder
               .WithType(OccasionType.CELL)
               .WithNumberOfConvertions(-1)
               .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.Empty(occasion.Id);
        }

        [Fact]
        public void Test_REUNIAOLIDERANÇA()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.REUNIAOLIDERANÇA)
                .WithStarTime(DateTime.Today)
                .WithEndTime(DateTime.Today.AddHours(2))
                .WithTopic()
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO })
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.NotEmpty(occasion.Id);
        }

        [Fact]
        public void TestREUNIAOLIDERANÇA_WithInvalidTopic()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.REUNIAOLIDERANÇA)
                .WithStarTime(DateTime.Today)
                .WithEndTime(DateTime.Today.AddHours(2))
                //.WithTopic()
                .WithHost(new MemberDTO() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Maria Pietra Clara das Neves", Phone = "27999976270", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                .WithAttendees(new MemberDTO() { Name = "Tânia Renata Peixoto", Phone = "51984043717", Photo = "uma_foto_bonita.jpg", Role = Role.PROFESSOR })
                .WithAttendees(new MemberDTO() { Name = "Levi Ryan Aragão", Phone = "66994084086", Photo = "uma_foto_bonita.jpg", Role = Role.MEMBRO })
                .Build();

            _occasionBusiness.AddAsync(occasion);

            Assert.Empty(occasion.Id);
        }
    }
}
