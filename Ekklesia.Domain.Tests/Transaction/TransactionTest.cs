using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Transaction
{
    public class TransactionTest: BaseTest<TransactionDTO, TransactionValidation>
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
        public void TestValideDate()
        {
            DTO.Date = DateTime.Now;
            var result = IsValid(nameof(DTO.Date));
            Assert.True(result.IsValid);
        }
    }
}
