using Microsoft.JSInterop;

namespace WaffleCorp.Web.Helpers
{
    public class AppJsInterop
    {
        protected IJSRuntime JSRuntime { get; }
        public AppJsInterop(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        public ValueTask<bool> SetBodyId(string bodyId)
          => JSRuntime.InvokeAsync<bool>("SetBodyId", bodyId);

        public ValueTask<bool> SetBodyCss(string cssClass)
         => JSRuntime.InvokeAsync<bool>("SetBodyCss",  cssClass);
    }
}
