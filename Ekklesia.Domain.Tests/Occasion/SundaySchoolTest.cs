using Ekkleisa.Business.Implementation.Validations;
using Ekklesia.Entities.DTOs;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class SundaySchoolTest : BaseTest<SundaySchoolDTO, SundaySchoolValidation>
    {    

        [Fact]
        public void TestEmptyTheme()
        {
            DTO.Theme = string.Empty;
            var result = IsValid(nameof(DTO.Theme));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestEmptyVerse()
        {
            DTO.Verse = string.Empty;
            var result = IsValid(nameof(DTO.Verse));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityVisitants(int number)
        {
            DTO.Visitants = number;
            var result = IsValid(nameof(DTO.Visitants));
            if (number >= 0)
            {
                Assert.True(result.IsValid);
            }
            else
            {
                Assert.False(result.IsValid);
            }
        }

    }
}
