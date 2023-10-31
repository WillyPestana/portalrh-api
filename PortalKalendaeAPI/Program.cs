using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.OData;
using PortalKalendaeAPI.Configurations;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Call the ConfigureServices method from the DependencyInjectionConfig class
DependencyInjectionConfig.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

//Tratamento Compatibilidade com Servidor
var supportedCultures = new[]
{
new CultureInfo("pt-BR")
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    // Formatting numbers, dates, etc.
    SupportedCultures = supportedCultures,
    // UI strings that we have localized.
    SupportedUICultures = supportedCultures
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{  
 
});

app.UseCors("PortaRH");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseODataRouteDebug();
app.UseStaticFiles();
app.MapControllers();
app.Run();