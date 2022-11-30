using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Sobczal.InPost.Client.Shared.Core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ServerAPI",
        client => client.BaseAddress =
            new Uri(builder.Configuration["ApiBaseUri"] ?? throw new InvalidOperationException()))
    .AddHttpMessageHandler(x =>
    {
        var handler = new AuthorizationMessageHandler(x.GetRequiredService<IAccessTokenProvider>(),
            x.GetRequiredService<NavigationManager>());
        handler.ConfigureHandler(new[] { builder.Configuration["ApiBaseUri"] });
        return handler;
    });

builder.Services.AddHttpClient("UnauthorizedServerAPI",
    client => client.BaseAddress =
        new Uri(builder.Configuration["ApiBaseUri"] ?? throw new InvalidOperationException()));

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("UnauthorizedServerAPI"));

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("ServerAPI"));


builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});

builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();