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
* ...
### Rozšíření o jméno a příjmení
* ...

## Tag helpery
* https://learn.microsoft.com/cs-cz/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-5.0

## Relační proměnná
* ...