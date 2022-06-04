using AutoFixture;
using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.IntegrationTesting.Builders;
using System;
using Xunit;

namespace Ekklesia.IntegrationTesting
{
    public class MemberBusinessTest : IClassFixture<DependencySetupFixture>
    {
        private readonly IMemberBusiness _memberBusiness;
        private readonly Fixture _fixture;
        private MemberBuilder _builder;

        public MemberBusinessTest(DependencySetupFixture fixture)
        {
            this._memberBusiness = fixture.GetRequiredService<IMemberBusiness>() ?? throw new ArgumentNullException(nameof(IMemberBusiness));
            this._fixture = new Fixture();
            this._builder = new MemberBuilder();
        }

        [Fact]
        public void TestMEMBER()
        {
            var member = _builder.WithName().WithPhone().WithPhoto().WithRole().Build();
            _memberBusiness.AddAsync(member);
            Assert.NotEmpty(member.Id);
        }

        [Fact]
        public void TestMEMBER_WithInvalidName()
        {
            var member = _builder.WithPhone().WithPhoto().WithRole().Build();
            _memberBusiness.AddAsync(member);
            Assert.Empty(member.Id);
        }

        [Fact]
        public void TestMEMBER_WithInvalidRole()
        {
            var member = _builder.WithName().WithPhone().WithPhoto().Build();
            _memberBusiness.AddAsync(member);
            Assert.Empty(member.Id);
        }

        

    }
}
