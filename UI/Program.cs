using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using BL.Policies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // options.LoginPath = "/home/";
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.Redirect("/home/#join");
            //context.Response.StatusCode = 403;
            return Task.CompletedTask;
        };
        // options.Events.OnRedirectToAccessDenied = context =>
        // {
        //     context.Response.StatusCode = 403;
        //     return Task.CompletedTask;
        // };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", policy =>
        policy.Requirements.Add(new AdminPolicyRequirement()));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Employee", policy =>
        policy.Requirements.Add(new EmployeePolicyRequirement()));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdministrator", policy =>
        policy.Requirements.Add(new SuperAdminPolicyRequirement()));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Subscribers", policy =>
        policy.Requirements.Add(new SubscribersPolicyRequirement()));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Goers", policy =>
        policy.Requirements.Add(new GoersPolicyRequirement()));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Coach", policy =>
        policy.Requirements.Add(new CoachPolicyRequirement()));
});

// Register custom handlers
builder.Services.AddSingleton<IAuthorizationHandler, AdminPolicyHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, EmployeePolicyHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, SuperAdminPolicyHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, SubscribersPolicyHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, GoersPolicyHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, CoachPolicyHandler>();

// Configuración CORS // Maria
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
}); // línea nueva agregada por Maria

var  MyAllowSpecificOrigins = "NocheCorsPolicy";

builder.Services.AddCors(options => {
    options.AddPolicy(name: "NocheCorsPolicy",
        policy => {
            policy.WithOrigins("*");
            policy.AllowAnyHeader(); //application/json  application/xml application/text
            policy.AllowAnyMethod(); //GET, POST, PUT, DELETE
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAllOrigins"); // línea nueva agregada por Maria

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
