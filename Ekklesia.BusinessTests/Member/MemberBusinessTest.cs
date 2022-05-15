using AutoFixture;
using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using System;
using Xunit;

namespace Ekklesia.IntegrationTesting
{
    public class MemberBusinessTest : IClassFixture<DependencySetupFixture>
    {
        private readonly IMemberBusiness _memberBusiness;
        private readonly Fixture _fixture;

        public MemberBusinessTest(DependencySetupFixture fixture)
        {            
            this._memberBusiness = fixture.GetRequiredService<IMemberBusiness>() ?? throw new ArgumentNullException(nameof(IMemberBusiness));
            this._fixture = new Fixture();
        }

        [Fact]
        public void IncludesMemberSuccesfuly()
        {
            var member = _fixture.Build<MemberDTO>().With(x => x.Name).With(x => x.Phone).With(x => x.Photo).With(x => x.Role).Create();
            _memberBusiness.AddAsync(member);
            Assert.NotEmpty(member.Id);
        }

        [Fact]
        public void GetsMemberByIdSuccesfuly()
        {

        }

    }
}
