using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.UI.JSInterop
{
    public class ExampleJsInterop(IJSRuntime jsRuntime) : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                  "import", "./_content/Contacts.UI/ExampleJsInterop.js").AsTask());

        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("showPrompt", message);
        }

        public async Task AlertUser(string message)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("showAlert", message);
        }


        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
