using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaxiCompany.WebApi.Client;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// ���������� ����������� �����������
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ����������� ��������
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new TaxiCompanyApi(builder.Configuration["OpenApi:ServerUrl"], new HttpClient()));

// ����������� Blazorise � Bootstrap 5 � FontAwesome
builder.Services.AddBlazorise(options => { options.Immediate = true; })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

// ������ � ��������� ����������
await builder.Build().RunAsync();
