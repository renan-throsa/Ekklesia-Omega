using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class ReunionTest : BaseTest<ReunionDTO, ReunionValidation>
    {
        [Fact]
        private void TestInvalideUpperDate()
        {
            DTO.Date = DateTime.Now.AddDays(1);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestInvalideLowerDate()
        {
            DTO.Date = DateTime.Now.AddDays(-31);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestInvalideEndDate()
        {
            DTO.Date = DateTime.Now;
            DTO.EndTime = DateTime.Now.AddHours(-5);
            var result = IsValid(nameof(DTO.EndTime));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestValideEndDate()
        {
            DTO.Date = DateTime.Now;
            DTO.EndTime = DateTime.Now.AddHours(1);
            var result = IsValid(nameof(DTO.EndTime));
            Assert.True(result.IsValid);
        }

        [Fact]
        private void TestValideDate()
        {
            DTO.Date = DateTime.Now;
            var result = IsValid(nameof(DTO.Date));
            Assert.True(result.IsValid);
        }

        [Fact]
        private void TestInvalideSpeaker()
        {
            DTO.Speaker = null;
            var result = IsValid(nameof(DTO.Speaker));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestInvalideParticipants()
        {
            DTO.Participants = null;
            var result = IsValid(nameof(DTO.Participants));
            Assert.False(result.IsValid);
        }

        [Fact]
        private void TestEmptyTopic()
        {
            DTO.Topic = string.Empty;
            var result = IsValid(nameof(DTO.Topic));
            Assert.False(result.IsValid);
        }
        
    }
}
