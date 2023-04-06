using Microsoft.EntityFrameworkCore;
using StudentsWithIdentity.Data;
using StudentsWithIdentity.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Identita
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    //options.SignIn.RequireConfirmedAccount = true;
    //options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequireDigit = false;
    //options.Password.RequiredUniqueChars = 0;
    //options.Password.RequireUppercase = false;
    //options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<AppDbContext>();


// autorizace
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdministrator", policy =>
    {
        //policy.RequireRole("Administrator");
        policy.RequireClaim("admin", "1");
    });
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

// spusteni autorizace a autentizace v TOMTO PORADI!
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();