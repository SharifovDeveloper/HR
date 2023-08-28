namespace WebApplication1.Services
{
    public interface IAccountNumberValidationService
    {
        bool IsValid(string accountNumber);
    }
}
