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
    public class BaptismTest : BaseTest<BaptismDTO, BaptismValidation>
    {
        [Fact]
        public void TestInvalideBaptizedsList()
        {
            DTO.Baptizeds = null;
            var result = IsValid(nameof(DTO.Baptizeds));
            Assert.False(result.IsValid);
        }

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
        public void TestValideDate()
        {
            DTO.Date = DateTime.Now;
            var result = IsValid(nameof(DTO.Date));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestEmptyDescription()
        {
            DTO.Place = string.Empty;
            var result = IsValid(nameof(DTO.Place));
            Assert.False(result.IsValid);
        }
    }
}
