using AutoMapper;
using Ekklesia.Application.Abstractions;
using Ekklesia.Application.Implementations;
using Ekklesia.Application.Infrastructure;
using Ekklesia.Application.Mapping;
using Ekklesia.Application.Models;
using Ekklesia.Domain.Enums;
using Ekklesia.IntegrationTesting.Builders;
using MongoDB.Bson;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ekklesia.IntegrationTesting
{
    public class OccasionBusinessTesting
    {
        private readonly Mock<IOccasionRepository> _occasionRepositoryMock;
        private readonly OccasionBuilder _occasionBuilder;
        private readonly IMapper _mapper;
        private readonly IOccasionBusiness _occasionBusiness;

        public OccasionBusinessTesting()
        {
            _occasionRepositoryMock = new Mock<IOccasionRepository>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new OccasionMapping())).CreateMapper();
            _occasionBusiness = new OccasionBusiness(_occasionRepositoryMock.Object, _mapper);

            _occasionBuilder = new OccasionBuilder();
        }

        [Fact]
        public async Task BaptismInsertion_Success()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                .WithHost(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Elza Isadora Oliveira" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Maria Pietra Clara das Neves" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Tânia Renata Peixoto" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Levi Ryan Aragão" })
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task BaptismInsertion_WithInvalidAttendees()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                .WithHost(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Elza Isadora Oliveira" })
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task BaptismInsertion_WithInvalidHost()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.BAPTISM)
                .WithPlace()
                .WithStarTime(DateTime.Today)
                 //.WithHost(new SaveOccasionMemberModel() { Id = ObjectId.Empty.ToString(), Name = "Elza Isadora Oliveira", Phone = "97984868076", Photo = "uma_foto_bonita.jpg", Role = Role.LIDER })
                 .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(),Name = "Maria Pietra Clara das Neves" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(),Name = "Tânia Renata Peixoto" })
                .WithAttendee(new SaveOccasionMemberModel() {Id = ObjectId.GenerateNewId().ToString(), Name = "Levi Ryan Aragão" })
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task BaptismInsertion_WithInvalidPlace()
        {
            var occasion = _occasionBuilder
                 .WithType(OccasionType.BAPTISM)
                 //.WithPlace()
                 .WithStarTime(DateTime.Today)
                 .WithHost(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Elza Isadora Oliveira" })
                 .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Maria Pietra Clara das Neves" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Tânia Renata Peixoto" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Levi Ryan Aragão" })
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task AtipycalInsertion_Success()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.ATYPICAL)
                .WithDescription()
                .WithStarTime(DateTime.Today)
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task AtipycalInsertion_WithoutDescription()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.ATYPICAL)
                .WithStarTime(DateTime.Today)
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task CellInsertion_Success()
        {
            var occasion = _occasionBuilder
               .WithType(OccasionType.CELL)
               .WithStarTime(DateTime.Today)
               .WithNumberOfConvertions(1)
               .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task CellInsertion_WithInvalidNumberOfConvertions()
        {
            var occasion = _occasionBuilder
               .WithType(OccasionType.CELL)
               .WithNumberOfConvertions(-1)
               .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task LeadershipMeetingInsertion_Success()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.REUNIAOLIDERANÇA)
                .WithStarTime(DateTime.Today)
                .WithEndTime(DateTime.Today.AddHours(2))
                .WithTopic()
                .WithHost(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Elza Isadora Oliveira" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Maria Pietra Clara das Neves" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Tânia Renata Peixoto" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Levi Ryan Aragão" })
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task LeadershipMeetingInsertion_WithInvalidTopic()
        {
            var occasion = _occasionBuilder
                .WithType(OccasionType.REUNIAOLIDERANÇA)
                .WithStarTime(DateTime.Today)
                .WithEndTime(DateTime.Today.AddHours(2))
                //.WithTopic()
                .WithHost(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Elza Isadora Oliveira" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Maria Pietra Clara das Neves" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Tânia Renata Peixoto" })
                .WithAttendee(new SaveOccasionMemberModel() { Id = ObjectId.GenerateNewId().ToString(), Name = "Levi Ryan Aragão" })
                .Build();

            var result = await _occasionBusiness.Insert(occasion);

            Assert.False(result.IsValid);
        }
    }
}
