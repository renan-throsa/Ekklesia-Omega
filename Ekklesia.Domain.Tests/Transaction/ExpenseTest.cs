using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using System;
using Xunit;

namespace Ekklesia.Tests.Transaction
{
    public class ExpenseTest
    {
        private ExpenseDTO Expense { get; }

        private ExpenseValidation Validation { get; }

        public ExpenseTest()
        {
            Expense = new ExpenseDTO();
            Validation = new ExpenseValidation();
        }

        [Theory]
        [InlineData(float.MinValue)]
        [InlineData(float.NaN)]
        private void TestInvalidValue(float value)
        {
            Expense.Value = value;
            var result = Validation.Validate(Expense);
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("0001-01-01T00:00:00.0000000")]
        [InlineData("9999-12-31T23:59:59.9999999")]
        private void TestInvalideDate(string date)
        {
            Expense.Date = DateTime.Parse(date);
            var result = Validation.Validate(Expense);
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestEmptyDescription()
        {
            Expense.Description = string.Empty;
            var result = Validation.Validate(Expense);
            Assert.False(result.IsValid);
        }



    }
}
