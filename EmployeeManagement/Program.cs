using EmployeeManagement.Models;
using EmployeeManagement.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication("GuestScheme")
    .AddCookie("GuestScheme", options =>
    {
        options.LoginPath = "/auth/guest-login";
        options.AccessDeniedPath = "/auth/denied";
    });

builder.Services.AddAuthorization();

builder.Services.AddMvcCore(
    //config => {
    //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    //    config.Filters.Add(new AuthorizeFilter(policy));
    //}
);
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("local"));
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("viewRole", policy => policy.RequireClaim("viewRole"));
    options.AddPolicy("createRole", policy => policy.RequireClaim("createRole"));
    options.AddPolicy("DeleteRole", policy => policy.RequireClaim("DeleteRole"));
    options.AddPolicy("EditRole", policy => policy.RequireClaim("EditRole"));
    options.AddPolicy("SuperAdmin", policy => policy.RequireAssertion(
            context => (
                context.User.IsInRole("Admin") && context.User.HasClaim(c => c.Type == "createRole")
            ) || context.User.IsInRole("Super Admin")
        ));
    options.AddPolicy("policyCustom", policy => policy.RequireAssertion(
            context => (
                context.User.IsInRole("systemAdminsitrator") && context.User.HasClaim(c => c.Type == "EditRole")
            )
        ));
    options.AddPolicy("CustomEditRole", policy => policy.AddRequirements(new ManageRoleAndClaimRequirement()));
});


//builder.Services.AddSingleton<AuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimHandler>();
builder.Services.ConfigureApplicationCookie(options => {
    options.AccessDeniedPath = new PathString("/404");
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    ;
builder.Services.ConfigureApplicationCookie(o => {
    o.LoginPath = "/login";
});
builder.Services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimHandler>();
//builder.Services.AddSingleton<IAuthorizationHandler, IssuperAdmin>();

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

app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();







