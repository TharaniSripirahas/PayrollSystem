using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PayrollSystem.src.microservices.AuthenticationService.Configurations;
using PayrollSystem.src.microservices.AuthenticationService.Services.AuthService;
using PayrollSystem.src.microservices.AuthenticationService.Services.PasswordService;
using PayrollSystem.src.microservices.Employee.Interfaces;
using PayrollSystem.src.microservices.Employee.Services;
using PayrollSystem.src.microservices.Shared.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Use Npgsql for PostgreSQL
builder.Services.AddDbContext<PayrollDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserDatabase")));

//  JWT Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

//  Dependency Injection
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//  JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

//  Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
