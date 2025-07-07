using AppReservas_Salas.Components;
using AppReservas_Salas.Contexto;
using AppReservas_Salas.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ReservaController>()
                .AddScoped<SalaController>()
                .AddScoped<TipoSalaController>()
                .AddScoped<TipoUsuarioController>()
                .AddScoped<UsuarioController>();
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/Error";
    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();


string mySqlConexao = builder.Configuration.GetConnectionString("ConexaoMySql");
builder.Services.AddDbContextPool<ContextoBD>(options => options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
