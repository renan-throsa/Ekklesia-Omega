using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using Xunit;

namespace Ekklesia.Domain.Tests.Member
{
    public class MemberTest : BaseTest<MemberDTO, MemberValidation>
    {
        [Fact]
        public void TestEmptyName()
        {
            DTO.Name = string.Empty;
            var result = IsValid(nameof(DTO.Name));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("Gaius Julius Caesar")]
        [InlineData("Gaius Július Caesar")]
        [InlineData("Gaius Július César")]
        [InlineData("Gaius Július Çésar")]
        public void TestValidName(string name)
        {
            DTO.Name = name;
            var result = IsValid(nameof(DTO.Name));
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("4aius Julius Caesar")]
        [InlineData("G@ius Julius Caesar")]
        [InlineData("Gaius J*lius Caesar")]
        [InlineData("Gaius Július [aesar")]
        [InlineData("Gaiu$ Július Caesar")]
        public void TestInvalidName(string name)
        {
            DTO.Name = name;
            var result = IsValid(nameof(DTO.Name));
            Assert.False(result.IsValid);
        }


        [Theory]
        [InlineData("63994544665")]
        [InlineData("91993261520")]
        public void TestValidNumber(string number)
        {
            DTO.Phone = number;
            var result = IsValid(nameof(DTO.Phone));
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("03994544665")]
        [InlineData("a5984601531")]
        [InlineData("00000000000")]
        [InlineData("6798601721")]
        [InlineData("")]
        public void TestInValidNumber(string number)
        {
            DTO.Phone = number;
            var result = IsValid(nameof(DTO.Phone));
            Assert.False(result.IsValid);
        }
    }
}
