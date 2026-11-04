using Veterinaria.Negocios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string? cadena =
    builder.Configuration.GetConnectionString("Veterinaria");

if (!string.IsNullOrWhiteSpace(cadena))
{
    ConfiguracionNegocio.Inicializar(cadena);

    if (builder.Environment.IsDevelopment())
    {
        try
        {
            int total = ConfiguracionNegocio.ProbarConexion();

            Console.WriteLine(
                $"MYSQL OK. Clientes registrados: {total}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"MYSQL ERROR: {ex.Message}");
        }
    }
}
else if (builder.Environment.IsDevelopment())
{
    Console.WriteLine(
        "MYSQL AVISO: no se encontró ConnectionStrings:Veterinaria. " +
        "Configure User Secrets antes de probar la conexión.");
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