
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddDbContext<IdentityAppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"))
    );

//builder.Services.AddIdentity<User, IdentityRole<long>>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = true;
//    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
//    options.Lockout.AllowedForNewUsers = true;
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
//    options.Lockout.MaxFailedAccessAttempts = 5;
//    options.Password.RequiredLength = 6;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireDigit = true;
//    options.Password.RequireNonAlphanumeric = true;
//})
//.AddEntityFrameworkStores<IdentityAppDbContext>()
//.AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
