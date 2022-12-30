using DataAccess.Abstract;
using DataAccess.EntityFramework.Concrete;
using DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using NRM1_HastaneOtomasyon.Models.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HastaneDbContext>(_ =>
{
	_.UseSqlServer(builder.Configuration.GetConnectionString("HastaneConnectionStiring"));
});
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<ImanagerRepo, ManagerRepo>();
builder.Services.AddScoped<IPersonnelRepo, PersonnelRepo>();
//builder.Services.AddDbContext

//builder.Services.AddSession(options => {
//    options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
//});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
SeedData.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=Login}/{id?}");
app.Run();