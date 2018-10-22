using System.Threading.Tasks;
using BlazorSpa.Shared.Models;

namespace BlazorSpa.Client.Services
{
    public class AuthStore
    {
        public bool IsAuth { get; private set; }
        public User CurrentUser { get; private set; }
        public string Token { get; private set; }

        public async Task Login(User user, string token)
        {
            Token = token;
            await JSHelper.SaveAccessToken(token);

            CurrentUser = user;
            IsAuth = true;
        }

        public async Task Logout()
        {
            CurrentUser = null;
            IsAuth = false;

            await JSHelper.SaveAccessToken(null);
        }

        public async Task<bool> GetAccessToken()
        {
            Token = await JSHelper.GetAccessToken();
            IsAuth = !string.IsNullOrWhiteSpace(Token);
            return IsAuth;
        }
    }
}