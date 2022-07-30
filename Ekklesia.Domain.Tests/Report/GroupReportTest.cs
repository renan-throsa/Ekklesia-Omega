using Ekkleisa.Business.Implementation.Validations;
using Ekklesia.Entities.DTOs;
using Ekklesia.Tests.Base;
using Xunit;

namespace Ekklesia.Tests.Report
{
    public class GroupReportTest : BaseTest<GroupReportDTO, GroupReportValidation>
    {

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityOfNumberOfExternalCults(int number)
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

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityNumberOfCells(int number)
        {
            DTO.NumberOfCells = number;
            var result = IsValid(nameof(DTO.NumberOfCells));
            if (number >= 0)
            {
                Assert.True(result.IsValid);
            }
            else
            {
                Assert.False(result.IsValid);
            }
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityNumberOfBaptizeds(int number)
        {
            DTO.NumberOfBaptizeds = number;
            var result = IsValid(nameof(DTO.NumberOfBaptizeds));
            if (number >= 0)
            {
                Assert.True(result.IsValid);
            }
            else
            {
                Assert.False(result.IsValid);
            }
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.0001)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3.5666)]
        public void TestValidityNumberOfCoordinationMeetings(int number)
        {
            DTO.NumberOfCoordinationMeetings = number;
            var result = IsValid(nameof(DTO.NumberOfCoordinationMeetings));
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
