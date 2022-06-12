using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Validations;
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
               

        [Fact]
        public void TestEmptyDescription()
        {
            DTO.Description = string.Empty;
            var result = IsValid(nameof(DTO.Description));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestDescriptionIvalidSize()
        {
            DTO.Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium q";
            var result = IsValid(nameof(DTO.Description));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestDescriptionValidSize()
        {
            DTO.Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium.";
            var result = IsValid(nameof(DTO.Description));
            Assert.True(result.IsValid);
        }

    }
}
