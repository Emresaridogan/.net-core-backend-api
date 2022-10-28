using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Northwind.Business.DependencyResolvers.Autofac;
using Northwind.Core.Utilities.Security.Encyption;
using Northwind.Core.Utilities.Security.Jwt;
using Northwind.DataAccess.Concrete.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<NorthwindContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddCors(options => options.AddPolicy("AllowOrigin",
    builder => builder.WithOrigins("http://localhost:3000"))); // http://localhost:3000 gelen taleplere izin verir



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
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),

        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader()); // tüm taleplere izin verir.

app.UseHttpsRedirection();

app.UseAuthentication(); // eklendi 

app.UseAuthorization();

app.MapControllers();

app.Run();