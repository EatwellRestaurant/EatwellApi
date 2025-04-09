using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Middlewares;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });


//builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("SqlConnection")
//    ));


// Add services to the container.

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy.WithOrigins("https://localhost:7189", 
    "http://localhost:5189", "http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

ServiceTool.Create(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
