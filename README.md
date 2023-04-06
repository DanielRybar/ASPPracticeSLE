# ASP.NET - maturitní příklady
## Instalace balíků pro práci s databází
Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools (pro scaffold)

* definice modelu (Model-First)
* vytvoření DbContextu
* connection string do appsettings.json (jak zjistit? přidat nový appsettings.json a zkopírovat)
* připojení DbContextu do IoC kontejneru v Program.cs
* migrace - ***add-migration 01init***
* vytvoření databáze - ***update-database***
* zobrazení dat v UI + CRUD - cesta nejmenšího odporu je scaffold stránek      

(ruční cesta - injektáž db contextu do stránky, kolekce jako vlastnost kterou chci zobrazit a její naplnění v OnGet metodě pomocí LINQ, následně procházení v Razor view pomocí cyklu a vypisování)

## Ruční připojení identity
### Balíky pro práci s identitou
Microsoft.AspNetCore.Identity

Microsoft.AspNetCore.Identity.EntityFrameworkCore

Microsoft.AspNetCore.Identity.UI

### Postup

1) Models
```csharp
ApplicationUser : IdentityUser
```

2) Data
```csharp
AppDbContext : IdentityDbContext<ApplicationUser>

 public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
```

Seed identity
```csharp
          // identity seed
          // uzivatel
          var hasher = new PasswordHasher<ApplicationUser>();
          mb.Entity<ApplicationUser>().HasData(new ApplicationUser
          {
              Id = "caa3e5b9-5e96-4ce9-aa16-2a0b0520e815",
              Email = "danryba@pslib.cz",
              NormalizedEmail = "DANRYBA@PSLIB.CZ",
              EmailConfirmed = true,
              UserName = "danryba@pslib.cz",
              NormalizedUserName = "DANRYBA@PSLIB.CZ",
              //Firstname = "Daniel",
              //Lastname = "Rybář",
              LockoutEnabled = false,
              SecurityStamp = string.Empty,
              PasswordHash = hasher.HashPassword(null, "beruska")

          });

          // role
          mb.Entity<IdentityRole>().HasData(new IdentityRole
          {
              Id = "5c9c1e5f-401c-4cc2-a395-eb1f3c927998",
              Name = "Administrator",
              NormalizedName = "ADMINISTRATOR"
          });

          // prirazeni role uzivateli
          mb.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
          {
              RoleId = "5c9c1e5f-401c-4cc2-a395-eb1f3c927998",
              UserId = "caa3e5b9-5e96-4ce9-aa16-2a0b0520e815"
          });

          // claim a jeho prirazeni uzivateli
          mb.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
          {
              Id = 1,
              UserId = "caa3e5b9-5e96-4ce9-aa16-2a0b0520e815",
              ClaimType = "admin",
              ClaimValue = "1"
          });
```

3) Připojení do IoC kontejneru
```csharp
// Identita
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
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


// ---

// spusteni autorizace a autentizace v TOMTO PORADI!
app.UseAuthentication();
app.UseAuthorization();
```

4) Nové migrace
- add-migration 02Identity
- update-database

5) Scaffold stránek s identitou

6) Přidat LoginPartial do navbaru v **Layout.cshtml**
```csharp
<partial name="_LoginPartial" />
```

7) Autorizace stránky pomocí anotací
```csharp
[Authorize] // přihlášení uživatele
[Authorize(Policy = "IsAdministrator")] // admin
```

Autorizace celé složky
```csharp
//autorizace celé složky
builder.Services.AddRazorPages(options =>
         {
             options.Conventions.AuthorizeAreaFolder("Admin", "/", "IsAdministrator"); // bez IsAdministrator vstup pouze pro prihlasene uzivatele
         });
```
Získaní ID aktuálně přihlášeného uživatele
```csharp
var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
```

## Tag helpery
* https://learn.microsoft.com/cs-cz/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-5.0

## Relační proměnná
* ...