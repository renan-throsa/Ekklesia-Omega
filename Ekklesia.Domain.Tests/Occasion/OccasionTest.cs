using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class OccasionTest : BaseTest<OccasionDTO, OccasionValidation>
    {

        [Fact]
        public void Test_InvalideUpperDate()
        {
            DTO.StartTime = DateTime.Now.AddDays(1);
            var result = IsValid(nameof(DTO.StartTime));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Test_InvalideLowerDate()
        {
            DTO.StartTime = DateTime.Now.AddDays(-31);
            var result = IsValid(nameof(DTO.StartTime));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Test_Date()
        {
            DTO.StartTime = DateTime.Now;
            var result = IsValid(nameof(DTO.StartTime));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestInvalide_Host()
        {
            DTO.Host = null;
            DTO.Type = Entities.Enums.OccasionType.REUNIAOLIDERANÇA;
            var result = IsValid(nameof(DTO.Host));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestInvalide_Attendees()
        {
            DTO.Attendees = null;            
            DTO.Type = Entities.Enums.OccasionType.REUNIAOLIDERANÇA;
            var result = IsValid(nameof(DTO.Attendees));
            Assert.False(result.IsValid);
        }


    }
}
