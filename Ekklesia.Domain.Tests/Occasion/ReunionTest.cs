using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
using Ekklesia.Tests.Base;
using MongoDB.Bson;
using System;
using Xunit;

namespace Ekklesia.Tests.Occasion
{
    public class ReunionTest : BaseTest<ReunionDTO, ReunionValidation>
    {
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
            DTO.Date = DateTime.Now.AddDays(-31);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestInvalideEndDate()
        {
            DTO.Date = DateTime.Now;
            DTO.EndTime = DateTime.Now.AddHours(-5);
            var result = IsValid(nameof(DTO.EndTime));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestValideEndDate()
        {
            DTO.Date = DateTime.Now;
            DTO.EndTime = DateTime.Now.AddHours(1);
            var result = IsValid(nameof(DTO.EndTime));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestValideDate()
        {
            DTO.Date = DateTime.Now;
            var result = IsValid(nameof(DTO.Date));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestInvalideSpeaker()
        {
            DTO.Speaker = null;
            var result = IsValid(nameof(DTO.Speaker));
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("Gaius Julius Caesar")]
        [InlineData("Gaius Július Caesar")]
        [InlineData("")]
        public void TestValiditySpeakerName(string name)
        {
            DTO.Speaker = new MemberDTO { Name = name,Id = ObjectId.GenerateNewId().ToString() };
            var result = IsValid(nameof(DTO.Speaker));
            if (string.IsNullOrEmpty(name))
            {
                Assert.False(result.IsValid);
            }
            else
            {
                Assert.True(result.IsValid);
            }
        }

        [Fact]
        public void TestInvalideParticipants()
        {
            DTO.Participants = null;
            var result = IsValid(nameof(DTO.Participants));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestEmptyTopic()
        {
            DTO.Topic = string.Empty;
            var result = IsValid(nameof(DTO.Topic));
            Assert.False(result.IsValid);
        }

    }
}
