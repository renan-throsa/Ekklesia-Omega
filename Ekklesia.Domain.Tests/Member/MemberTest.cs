using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Xunit;

namespace Ekklesia.Domain.Tests.Member
{
    public class MemberTest
    {
        private MemberDTO Member { get; }
        private MemberValidation Validation { get; }
        public MemberTest()
        {
            Member = new MemberDTO();
            Validation = new MemberValidation();
        }

        [Fact]
        private void TestEmptyName()
        {
            Member.Name = string.Empty;
            var result = Validation.Validate(Member);
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("Gaius Julius Caesar")]
        [InlineData("Gaius Július Caesar")]
        [InlineData("Gaius Július César")]
        [InlineData("Gaius Július Çésar")]
        private void TestValidName(string name)
        {
            Member.Name = name;
            var result = Validation.Validate(Member);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("4aius Julius Caesar")]
        [InlineData("G@ius Julius Caesar")]
        [InlineData("Gaius J*lius Caesar")]
        [InlineData("Gaius Július [aesar")]
        [InlineData("Gaiu$ Július Caesar")]
        private void TestInvalidName(string name)
        {
            Member.Name = name;
            var result = Validation.Validate(Member);
            Assert.False(result.IsValid);
        }
               

        [Theory]
        [InlineData("63994544665")]
        [InlineData("91993261520")]
        private void TestValidNumber(string number)
        {
            Member.Phone = number;
            var result = Validation.Validate(Member);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("03994544665")]
        [InlineData("a5984601531")]
        [InlineData("00000000000")]
        [InlineData("6798601721")]
        [InlineData("")]
        private void TestInValidNumber(string number)
        {
            Member.Phone = number;
            var result = Validation.Validate(Member);
            Assert.False(result.IsValid);
        }
    }
}
