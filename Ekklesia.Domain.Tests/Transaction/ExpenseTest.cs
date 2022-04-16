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
        public void TestInvalidValue(float value)
        {
            DTO.Value = value;
            var result = IsValid(nameof(DTO.Value));
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
            DTO.Date = DateTime.Now.AddDays(-32);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestInvalideResponsable()
        {
            DTO.Responsable = null;
            var result = IsValid(nameof(DTO.Responsable));
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
        public void TestEmptyDescription()
        {
            DTO.Description = string.Empty;
            var result = IsValid(nameof(DTO.Description));
            Assert.False(result.IsValid);
        }

    }
}
