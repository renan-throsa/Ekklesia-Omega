using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class CellTest: BaseTest<CellDTO, CellValidation>
    {        
        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityOfNumberOfConvertions(int number)
        {
            DTO.NumberOfConvertions = number;
            var result = IsValid(nameof(DTO.NumberOfConvertions));
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
