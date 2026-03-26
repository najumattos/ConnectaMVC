using ConnectaMVC.Configuration;
using ConnectaMVC.Data;
using ConnectaMVC.Models;
using dotenv.net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// 1. CARREGAMENTO DE AMBIENTE
DotEnv.Load(options: new DotEnvOptions(envFilePaths: [".env"]));

var builder = WebApplication.CreateBuilder(args);

// 2. CONFIGURAÇÕES DE SERVIÇOS (BUILDER.SERVICES)
builder.Configuration.AddEnvironmentVariables();                

// AutoMapper 
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews();

// Conexão com o Banco
string conexao = builder.Configuration.GetConnectionString("DB_CONNECTION_STRING")
                 ?? throw new Exception("A string de conexão não foi carregada. Verifique o arquivo .env!");

var versao = ServerVersion.AutoDetect(conexao);
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conexao, versao));

// 3. Configuração do Identity (Essencial para Login no MVC)
builder.Services.AddIdentity<UsuarioModel, IdentityRole>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AcessoNegado";
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.SlidingExpiration = true;
});

// Registro automático de Services
builder.Services.AddSmartServices();

// 3.CONSTRUÇÃO DO APP
var app = builder.Build();

// 4. Configurações de Ambiente
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Página de erro amigável
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapStaticAssets();            // Serve CSS/JS de forma otimizada (.NET 9)
app.UseRouting();
app.UseAuthentication(); // Lê o Cookie
app.UseAuthorization();  // Verifica permissões (Roles)


// 5. Rota Padrão do MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
