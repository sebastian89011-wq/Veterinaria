using Veterinaria.Negocios;

var builder =
    WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string? cadena =
    builder.Configuration
        .GetConnectionString("Veterinaria");

if (!string.IsNullOrWhiteSpace(cadena))
{
    ConfiguracionNegocio.Inicializar(cadena);
}
else
{
    System.Diagnostics.Debug.WriteLine(
        "No se encontró ConnectionStrings:Veterinaria. " +
        "Revise User Secrets.");
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();