using Microsoft.EntityFrameworkCore;
using VuelosCRUD;
using VuelosCRUD.Areas.Identity.Data;
using VuelosCRUD.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;Port=3306;Database=vuelo;Uid=root;Pwd=cordillera;";

builder.Services.AddControllersWithViews();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));


builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseMySql(connectionString, serverVersion, options => options.EnableRetryOnFailure()));

builder.Services.AddDefaultIdentity<VuelosCRUDUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

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

app.UseAuthentication(); // añadido despues
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vuelos}/{action=Index}/{id?}");

app.MapRazorPages(); // si no, no se veia register y login pages.

app.Run();
