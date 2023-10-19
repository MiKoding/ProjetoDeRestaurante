//namespace ProjetoDeRestaurante;

//public class program
//{
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args);
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//        }
//        );


//} 
using ProjetoDeRestaurante.Context;
using Microsoft.EntityFrameworkCore;
using ProjetoDeRestaurante.Repositories.Interface;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.Repositories;
using ProjetoDeRestaurante.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Microsoft.Extensions.Options;
using ProjetoDeRestaurante.Areas.Admin.Services;

var builder = WebApplication.CreateBuilder(args );

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPaging(options =>
{
    options.ViewName = "Bootstrap4";
    options.PageParameterName = "pageindex";
}
);


builder.Services.AddDbContext<AppDbContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/AccessDenied");
builder.Services.Configure<ConfigurationImagens>(builder.Configuration.GetSection("ConfigurationPastaImagens"));

builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ICompraRepository, CompraRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// adicionado para registrar a interface IhttpcontextAcessor para injeção de dependencias
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
builder.Services.AddScoped<RelatorioVendasService>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", 
        politica =>
        {
            politica.RequireRole("Admin");
        });
});// adição de politica de regras de perfil admin
builder.Services.AddMemoryCache();// adicionado para implementar o cache de memoria
builder.Services.AddSession();// adicionado para aplicar a Session


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

CriarPerfisUsuario(app);// chama para que seja executada a criação de perfis e regras na inicialização.

app.UseSession();// adicionado para usar Sessio

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "categoriaFiltro",
    pattern: "Pedido/{action}/{categoria?}",
    defaults: new { Controller = "Pedido", action = "List" }

    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



 

app.Run();

void CriarPerfisUsuario(WebApplication app)
{
    var scopedfactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedfactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service.SeedUsers();
        service.SeedRoles();
    }
}
