using Umbraco.Cms.Core.Services;
using v12.Data;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
var config = builder.Configuration;

builder.Services.AddUmbraco(env, config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddDeliveryApi()
    .Build();


//builder.Services.AddDbContext<MyContext>();

builder.Services.AddUmbracoEFCoreContext<MyContext>(
    config.GetConnectionString("umbracoDbDSN"),
    config.GetConnectionStringProviderName("umbracoDbDSN"));

builder.Services.AddControllers();

var app = builder.Build();
StaticServiceProvider.Instance = app.Services;
app.Services.GetRequiredService<IRuntimeState>().DetermineRuntimeLevel();

app.UseUmbraco()
             .WithMiddleware(u => {
                 u.UseBackOffice();
                 u.UseWebsite();
             })
             .WithEndpoints(u => {
                 u.UseInstallerEndpoints();
                 u.UseBackOfficeEndpoints();
                 u.UseWebsiteEndpoints();
             });

app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .WithOrigins("https://localhost:44351"));

app.Run();


