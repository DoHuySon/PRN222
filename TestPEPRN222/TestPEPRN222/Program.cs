using Microsoft.EntityFrameworkCore;
using TestPEPRN222.Components;
using TestPEPRN222.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyStockContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyStockDB"),
    sqlOptions => sqlOptions.EnableRetryOnFailure())
);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
