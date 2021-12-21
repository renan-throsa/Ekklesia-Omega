using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Transaction
{
    public class ExpenseTest : BaseTest<ExpenseDTO, ExpenseValidation>
    {
        [Theory]
        [InlineData(float.MinValue)]
        [InlineData(float.NaN)]
        private void TestInvalidValue(float value)
        {
            DTO.Value = value;
            var result = IsValid(nameof(DTO.Value));
            Assert.False(result.IsValid);
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
        private void TestEmptyDescription()
        {
            DTO.Description = string.Empty;
            var result = IsValid(nameof(DTO.Description));
            Assert.False(result.IsValid);
        }




    }
}
