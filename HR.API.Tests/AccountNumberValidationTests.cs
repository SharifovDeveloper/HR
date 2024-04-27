using HR.Services;

namespace HR.API.Tests
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidationService validationSvc;

        public AccountNumberValidationTests() => validationSvc = new AccountNumberValidationService();

        [Fact]
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            Assert.True(validationSvc.IsValid("123-1234567890-54"));
        }

        [Theory]
        [InlineData("1283-1234567890-54")]
        [InlineData("1-1234567890-54")]
        public void IsValid_FirstPartIsWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(validationSvc.IsValid(accountNumber));
        }


        [Theory]
        [InlineData("1283-abc567890-54")]
        [InlineData("1-12345s67890-54")]
        public void IsValid_MiddlePartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(validationSvc.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("123-1234567890-5")]
        [InlineData("123-1234567890-5445")]
        public void IsValid_LastPartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(validationSvc.IsValid(accountNumber));
        }


        [Theory]
        [InlineData("123-1234567890 51")]
        [InlineData("123+1234567890-5445")]
        public void IsValid_InvalidDelimiters_ThrowArgumentExeption(string accountNumber)
        {
            Assert.Throws<ArgumentException>(() => validationSvc.IsValid(accountNumber));
        }
    }
}