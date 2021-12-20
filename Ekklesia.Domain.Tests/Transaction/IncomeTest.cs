using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Xunit;

namespace Ekklesia.Tests.Transaction
{
    public class IncomeTest
    {
        private IncomeDTO Expense { get; }

        private IncomeValidation Validation { get; }

        public IncomeTest()
        {
            Expense = new IncomeDTO();
            Validation = new IncomeValidation();
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



    }
}
