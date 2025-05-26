using Microsoft.EntityFrameworkCore;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Data;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Extensions;
using Projet6_ModelisezEtcreezUneBaseDeDonnee.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<NexaWorksContext>(options =>
    options.UseSqlServer(connectionString));

// Enregistrer le service de sélection de requêtes
builder.Services.AddScoped<IQuerySelectionService, QuerySelectionService>();

var app = builder.Build();

// Initialize the database
app.InitializeDatabase();

// Display database statistics in development
if (app.Environment.IsDevelopment())
{
    app.DisplayDatabaseStats();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();