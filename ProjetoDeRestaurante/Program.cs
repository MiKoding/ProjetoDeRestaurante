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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// adicionado para registrar a interface IhttpcontextAcessor para inj~ção de dependencias
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));


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

app.UseAuthorization();

app.UseSession();// adicionado para usar Sessio

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
