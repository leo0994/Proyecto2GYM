using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using BL.Policies;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
       {
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            };
        });
    
builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Administrator", policy =>
            policy.Requirements.Add(new AdminPolicyRequirement()));
    });

// Register custom handlers
builder.Services.AddSingleton<IAuthorizationHandler, AdminPolicyHandler>();

builder.Services.AddControllers();

var  MyAllowSpecificOrigins = "NocheCorsPolicy";

builder.Services.AddCors(options => {
    options.AddPolicy(name: "NocheCorsPolicy",
        policy => {
            policy.WithOrigins("*")
                .AllowAnyHeader() //application/json  application/xml application/text
                .AllowAnyMethod(); //GET, POST, PUT, DELETE
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();



app.Run();
