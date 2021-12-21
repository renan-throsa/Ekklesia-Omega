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
        private void TestInValidConvertions(int number)
        {
            DTO.Convertions = number;
            var result = IsValid(nameof(DTO.Convertions));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        private void TestValidConvertions(int number)
        {
            DTO.Convertions = number;
            var result = IsValid(nameof(DTO.Convertions));
            Assert.True(result.IsValid);
        }
    }
}
