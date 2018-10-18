using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorSpa.Client.Services
{
    public static class JSHelper
    {
        public static Task SaveAccessToken(string accessToken)
        {
            return JSRuntime.Current.InvokeAsync<object>("wasmHelper.saveAccessToken", accessToken);
        }
        public static Task<string> GetAccessToken()
        {
            return JSRuntime.Current.InvokeAsync<string>("wasmHelper.getAccessToken");
        }
    }
}
