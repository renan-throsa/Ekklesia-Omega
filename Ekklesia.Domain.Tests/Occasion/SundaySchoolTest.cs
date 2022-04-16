using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class SundaySchoolTest : BaseTest<SundaySchoolDTO, SundaySchoolValidation>
    {
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
        public void TestInvalideTeacher()
        {
            DTO.Teacher = null;
            var result = IsValid(nameof(DTO.Teacher));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestInvalideParticipants()
        {
            DTO.Participants = null;
            var result = IsValid(nameof(DTO.Participants));
            Assert.False(result.IsValid);
        }

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
