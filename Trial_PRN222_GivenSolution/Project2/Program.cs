using Microsoft.EntityFrameworkCore;
using Project2;
using Project2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PePrn222TrialContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseRouting();

app.MapRazorPages();

app.MapGet("/", () => "Hello World!");
app.MapHub<MovieHub>("/movieHub");

app.Run();
