using Assigment_PRN222_01.DAO;
using Assigment_PRN222_01.Models;
using Assigment_PRN222_01.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FunewsManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyStockDB"),
    sqlOptions => sqlOptions.EnableRetryOnFailure())
);
// Đăng ký cấu hình admin từ appsettings.json
builder.Services.Configure<AdminAccountSettings>(
 builder.Configuration.GetSection("AdminAccount"));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian tồn tại của Session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});







// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");


app.Run();
