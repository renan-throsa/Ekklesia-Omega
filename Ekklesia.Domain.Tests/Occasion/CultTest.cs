using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class CultTest : BaseTest<CultDTO, CultValidation>
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityConvertions(int number)
        {
            DTO.Convertions = number;
            var result = IsValid(nameof(DTO.Convertions));
            if (number >= 0)
            {
                Assert.True(result.IsValid);
            }
            else
            {
                Assert.False(result.IsValid);
            }
        }        

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityNumberOfPeople(int number)
        {
            DTO.NumberOfPeople = number;
            var result = IsValid(nameof(DTO.NumberOfPeople));
            if (number >= 0)
            {
                Assert.True(result.IsValid);
            }
            else
            {
                Assert.False(result.IsValid);
            }
        }

        [Fact]
        public void TestInvalideUpperDate()
        {
            DTO.Date = DateTime.Now.AddDays(1);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestInvalideLowerDate()
        {
            DTO.Date = DateTime.Now.AddDays(-31);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestValideDate()
        {
            DTO.Date = DateTime.Now;
            var result = IsValid(nameof(DTO.Date));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestEmptyKeyVerse()
        {
            DTO.KeyVerse = string.Empty;
            var result = IsValid(nameof(DTO.KeyVerse));
            Assert.False(result.IsValid);
        }
    }
}
