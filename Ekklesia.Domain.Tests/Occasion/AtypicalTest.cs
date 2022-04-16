using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class AtypicalTest : BaseTest<AtypicalDTO, AtypicalValidation>
    {

        [Fact]
        public void TestEmptyDescription()
        {
            DTO.Description = string.Empty;
            var result = IsValid(nameof(DTO.Description));
            Assert.False(result.IsValid);
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
    }
}
