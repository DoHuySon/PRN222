using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.Models;
using RestaurantDataAccess.Dao;
using RestaurantRepositories.IRepository;
using RestaurantRepositories.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Sp25Prn222RestaurantContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});

builder.Services.AddScoped<UserDAO>();
builder.Services.AddScoped<TableDAO>();
builder.Services.AddScoped<ReservationDAO>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
