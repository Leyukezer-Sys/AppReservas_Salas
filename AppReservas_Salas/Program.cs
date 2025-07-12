using AppReservas_Salas.Components;
using AppReservas_Salas.Contexto;
using AppReservas_Salas.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<ReservaController>()
                .AddScoped<SalaController>()
                .AddScoped<TipoSalaController>()
                .AddScoped<TipoUsuarioController>()
                .AddScoped<UsuarioController>();              

string mySqlConexao = builder.Configuration.GetConnectionString("ConexaoMySql");
builder.Services.AddDbContextPool<ContextoBD>(options =>
    options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
