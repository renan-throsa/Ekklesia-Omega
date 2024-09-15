using AutoMapper;
using Ekkleisa.Business.Implementation.Business;
using Ekkleisa.Business.Mapping;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.Entities;
using Ekklesia.IntegrationTesting.Builders;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ekklesia.IntegrationTesting
{
    public class MemberBusinessTest
    {
        private readonly Mock<IMemberRepository> _memberRepositoryMock;
        private readonly IMapper _mapper;
        private readonly MemberBusiness _memberBusinnes;
        private readonly MemberBuilder _builder;

        public MemberBusinessTest()
        {
            _memberRepositoryMock = new Mock<IMemberRepository>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MemberMapping())).CreateMapper();
            _memberBusinnes = new MemberBusiness(_memberRepositoryMock.Object, _mapper);
            _builder = new MemberBuilder();
        }

        [Fact]
        public void MemberListing_Success()
        {
            _memberRepositoryMock.Setup(x => x.All(m => new Member() { Id = m.Id, Name = m.Name, Phone = m.Phone })).Returns(MockData.Members);
            var result = _memberBusinnes.FindAll();
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("Gaius Julius Caesar", "(22) 99908-7919")]
        [InlineData("Gaius Július Caesar", "(96) 98213-6538")]
        [InlineData("Gaius Július César", "(82) 99457-8711")]
        [InlineData("Gaius Július Çésar", "(89) 98770-6218")]
        public async Task MemberInsertion_Success(string name,string phone)
        {
            var memberModel = _builder.WithName(name).WithPhone(phone).WithPhoto().WithRole().WithBirthDay().Build();
            var result = await _memberBusinnes.Insert(memberModel);
            Assert.True(result.IsValid);
        }       


        [Theory]        
        [InlineData("4aius Julius Caesar")]
        [InlineData("G@ius Julius Caesar")]
        [InlineData("Gaius J*lius Caesar")]
        [InlineData("Gaius Július [aesar")]
        [InlineData("Gaiu$ Július Caesar")]
        public async Task MemberInsertion_InvalidName(string name)
        {
            var memberModel = _builder.WithName(name).WithPhone().WithPhoto().WithRole().WithBirthDay().Build();
            var result = await _memberBusinnes.Insert(memberModel);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task MemberInsertion_InvalidRole()
        {
            var memberModel = _builder.WithName().WithPhone().WithPhoto().WithBirthDay().Build();
            var result = await _memberBusinnes.Insert(memberModel);
            Assert.False(result.IsValid);
        }

        [Theory]        
        [InlineData("a5984601531")]
        [InlineData("00000000000")]        
        [InlineData("")]
        public async Task MemberInsertion_InvalidPhone(string phone)
        {
            var memberModel = _builder.WithName().WithPhone(phone).WithPhoto().WithRole().WithBirthDay().Build();
            var result = await _memberBusinnes.Insert(memberModel);
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(1,'h')]
        [InlineData(-101,'y')]

        public async Task MemberInsertion_InvalidBirthDay(int quantity,char option)
        {
            DateTime date = DateTime.Today;

            switch (option)
            {
                case 'h':
                    date = date.AddHours(quantity);
                    break;
                case 'd':
                    date = date.AddDays(quantity);
                    break;
                case 'm':
                    date = date.AddMonths(quantity);
                    break;
                case 'y':
                    date = date.AddYears(quantity);
                    break;
                
            }

            var memberModel = _builder.WithName().WithPhone().WithPhoto().WithRole().WithBirthDay(date).Build();
            var result = await _memberBusinnes.Insert(memberModel);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task MemberUpdating_InvalidId()
        {
            var memberModel = _builder.WithName().WithPhone().WithPhoto().WithRole().WithBirthDay().Build();
            var result = await _memberBusinnes.Update(memberModel);
            Assert.False(result.IsValid);
        }


    }
}
