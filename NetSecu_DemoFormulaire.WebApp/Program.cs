using NetSecu_DemoFormulaire.Repository;
using NetSecu_DemoFormulaire.WebApp.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajout session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { 
    options.Cookie.Name = "test";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});

builder.Services.Configure<CookiePolicyOptions>(options => {
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.Secure = CookieSecurePolicy.Always;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SessionManager>();

//Si tu as besoin d'un Iuserrepo==> new Userrepo(cnstr)
builder.Services.AddScoped<IUserRepository, UserRepository>(r => new UserRepository(builder.Configuration.GetConnectionString("dev")));
builder.Services.AddScoped<IGameRepository, GameRepository>(r => new GameRepository(builder.Configuration.GetConnectionString("dev")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseCookiePolicy();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
