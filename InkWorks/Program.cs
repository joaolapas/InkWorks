using Microsoft.EntityFrameworkCore;
using InkWorks.Data;
using InkWorks.Repositorio;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Http;
using InkWorks.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ligação à base de dados
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Interfaces
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ITrabalhoRepositorio, TrabalhoRepositorio>();
builder.Services.AddScoped<IUtilizadorRepositorio, UtilizadorRepositorio>();
builder.Services.AddScoped<IMensagemRepositorio, MensagemRepositorio>();
builder.Services.AddScoped<IImagemRepositorio, ImagemRepositorio>();
builder.Services.AddScoped<ISessaoRepositorio, SessaoRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>();

//sessão

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;

});

//Toast Notifications
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopCenter;

});

//IHttpContext
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Publico}/{action=Index}/{id?}");


app.Run();
