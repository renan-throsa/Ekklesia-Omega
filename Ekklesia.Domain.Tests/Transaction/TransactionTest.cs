using Ekkleisa.Business.Implementation.Validations;
using Ekklesia.Entities.DTOs;
using Ekklesia.Tests.Base;
using System;
using Xunit;

namespace Ekklesia.Tests.Transaction
{
    public class TransactionTest: BaseTest<TransactionDTO, TransactionValidation>
    {
        [Theory]
        [InlineData(float.MinValue)]
        [InlineData(float.NaN)]
        public void TestValue_Invalid(float value)
        {
            DTO.Amount = value;
            var result = IsValid(nameof(DTO.Amount));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestUpperDate_Invalide()
        {
            DTO.Date = DateTime.Now.AddDays(1);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestLowerDate_Invalide()
        {
            DTO.Date = DateTime.Now.AddDays(-32);
            var result = IsValid(nameof(DTO.Date));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestDate_Valide()
        {
            DTO.Date = DateTime.Now;
            var result = IsValid(nameof(DTO.Date));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestDescription_Empty()
        {
            DTO.Description = string.Empty;
            var result = IsValid(nameof(DTO.Description));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestDescription_IvalidSize()
        {
            DTO.Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium q";
            var result = IsValid(nameof(DTO.Description));
            Assert.False(result.IsValid);
        }

        [Fact]
        public void TestDescription_ValidSize()
        {
            DTO.Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium.";
            var result = IsValid(nameof(DTO.Description));
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestResponsable_Invalide()
        {
            DTO.Responsable = null;
            var result = IsValid(nameof(DTO.Responsable));
            Assert.False(result.IsValid);
        }
    }
}
