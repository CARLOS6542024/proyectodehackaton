var builder = WebApplication.CreateBuilder(args);

// Forzar Kestrel a usar un puerto distinto para evitar conflictos con el puerto 5000
builder.WebHost.ConfigureKestrel(options =>
{
    // Escucha en localhost:5002 en vez del puerto por defecto 5000
    options.ListenLocalhost(5003);
    // Escucha HTTPS en localhost:5004 (usa el certificado de desarrollo por defecto)
    options.ListenLocalhost(5004, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
