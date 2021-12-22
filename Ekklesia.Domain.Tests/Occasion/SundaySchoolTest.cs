using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class SundaySchoolTest : BaseTest<SundaySchoolDTO, SundaySchoolValidation>
    {
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
        private void TestInvalideTeacher()
        {
            DTO.Teacher = null;
            var result = IsValid(nameof(DTO.Teacher));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestInvalideParticipants()
        {
            DTO.Participants = null;
            var result = IsValid(nameof(DTO.Participants));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestEmptyTheme()
        {
            DTO.Theme = string.Empty;
            var result = IsValid(nameof(DTO.Theme));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestEmptyVerse()
        {
            DTO.Verse = string.Empty;
            var result = IsValid(nameof(DTO.Verse));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        private void TestInValidVisitants(int number)
        {
            DTO.Visitants = number;
            var result = IsValid(nameof(DTO.Visitants));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        private void TestValidVisitants(int number)
        {
            DTO.Visitants = number;
            var result = IsValid(nameof(DTO.Visitants));
            Assert.True(result.IsValid);
        }
    }
}
