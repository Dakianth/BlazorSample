using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorSpa.Client.Services
{
    public class TokenService
    {
        public Task SaveAccessToken(string accessToken)
        {
            return JSRuntime.Current.InvokeAsync<object>("wasmHelper.saveAccessToken", accessToken);
        }
        public Task<string> GetAccessToken()
        {
            return JSRuntime.Current.InvokeAsync<string>("wasmHelper.getAccessToken");
        }
    }
}
