using Ekkleisa.Business.Implementation.Validations;
using Ekklesia.Entities.DTOs;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Transaction
{
    public class ExpenseTest : BaseTest<ExpenseDTO, ExpenseValidation>
    {
        
        [Fact]
        public void TestInvalideResponsable()
        {
            DTO.Responsable = null;
            var result = IsValid(nameof(DTO.Responsable));
            Assert.False(result.IsValid);
        }

    }
}
