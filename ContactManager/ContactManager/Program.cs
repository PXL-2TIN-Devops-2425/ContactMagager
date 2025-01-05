using ContactManager.AppLogic.Contracts;
using ContactManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICompanyRepository, CompanyDbRepository>();
builder.Services.AddScoped<IContactRepository, ContactDbRepository>();

// Add services to the container.
builder.Services.AddDbContext<ContactManagerDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ContactManagerDbContextConnection"]);
});

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
app.MapRazorPages();

app.Run();

/* For Integration tests, you can ignore this: */
namespace ContactManager
{
    public partial class Program { }
}