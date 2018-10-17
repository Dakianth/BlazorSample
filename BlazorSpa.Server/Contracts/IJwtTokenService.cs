namespace BlazorSpa.Server.Contracts
{
    public interface IJwtTokenService
    {
        string BuildToken(string email);
    }
}