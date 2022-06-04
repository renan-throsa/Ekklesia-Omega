using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using Xunit;

namespace Ekklesia.Tests.Transaction
{
    public class IncomeTest : BaseTest<IncomeDTO, IncomeValidation>
    {

        [Fact]
        public void TestObservationIvalidSize()
        {
            DTO.Observation = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium q";
            var result = IsValid(nameof(DTO.Observation));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestObservationValidSize()
        {
            DTO.Observation = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium.";
            var result = IsValid(nameof(DTO.Observation));
            Assert.True(result.IsValid);
        }
    }
}
