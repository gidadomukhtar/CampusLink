using CampusLink.Components;
using CampusLink.Data;
using CampusLink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Gidado - I created this- DATABASE
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services
    .AddIdentityCore<ApplicationUser>(options =>
    {
        options.User.RequireUniqueEmail = true;

        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(
    IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    await RoleInitializer.InitializeAsync(scope.ServiceProvider);
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapPost("/account/register", async (
    [FromForm] RegisterInputModel input,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) =>
{
    var validationResults = new List<ValidationResult>();

    var validationContext = new ValidationContext(input);

    if (!Validator.TryValidateObject(
        input,
        validationContext,
        validationResults,
        validateAllProperties: true))
    {
        return Results.Redirect("/register?error=invalid");
    }

    var user = new ApplicationUser
    {
        UserName = input.Email.Trim(),
        Email = input.Email.Trim(),
        FullName = input.FullName.Trim(),
        University = input.University.Trim(),
        Faculty = input.Faculty.Trim(),
        Department = input.Department.Trim(),
        Level = input.Level
    };

    var result = await userManager.CreateAsync(
        user,
        input.Password);

    if (!result.Succeeded)
    {
        return Results.Redirect("/register?error=account");
    }

    var roleResult = await userManager.AddToRoleAsync(user, "Student");

    if (!roleResult.Succeeded)
    {
        await userManager.DeleteAsync(user);

        return Results.Redirect("/register?error=role");
    }

    await signInManager.SignInAsync(user, isPersistent: false);

    return Results.Redirect("/");
})
.AllowAnonymous();

app.MapPost("/account/login", async (
    [FromForm] LoginInputModel input,
    SignInManager<ApplicationUser> signInManager) =>
{
    var validationResults = new List<ValidationResult>();
    var validationContext = new ValidationContext(input);

    if (!Validator.TryValidateObject(
        input,
        validationContext,
        validationResults,
        validateAllProperties: true))
    {
        return Results.Redirect("/login?error=invalid");
    }

    var result = await signInManager.PasswordSignInAsync(
        input.Email.Trim(),
        input.Password,
        isPersistent: false,
        lockoutOnFailure: false);

    if (!result.Succeeded)
    {
        return Results.Redirect("/login?error=invalid");
    }

    return Results.Redirect("/dashboard");
})
.AllowAnonymous();

app.Run();

