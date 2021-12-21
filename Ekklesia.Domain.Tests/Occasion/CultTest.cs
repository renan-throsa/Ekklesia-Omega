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
        private void TestInValidConvertions(int number)
        {
            DTO.Convertions = number;
            var result = IsValid(nameof(DTO.Convertions));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        private void TestValidConvertions(int number)
        {
            DTO.Convertions = number;
            var result = IsValid(nameof(DTO.Convertions));
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        private void TestInValidNumberOfPeople(int number)
        {
            DTO.NumberOfPeople = number;
            var result = IsValid(nameof(DTO.NumberOfPeople));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        private void TestValidNumberOfPeople(int number)
        {
            DTO.NumberOfPeople = number;
            var result = IsValid(nameof(DTO.NumberOfPeople));
            Assert.True(result.IsValid);
        }

        [Fact]
        private void TestInvalideUpperDate()
        {
            DTO.Date = DateTime.Now.AddDays(1);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestInvalideLowerDate()
        {
            DTO.Date = DateTime.Now.AddDays(-31);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestValideDate()
        {
            DTO.Date = DateTime.Now;
            var result = IsValid(nameof(DTO.Date));
            Assert.True(result.IsValid);
        }

        [Fact]
        private void TestEmptyKeyVerse()
        {
            DTO.KeyVerse = string.Empty;
            var result = IsValid(nameof(DTO.KeyVerse));
            Assert.False(result.IsValid);
        }
    }
}
