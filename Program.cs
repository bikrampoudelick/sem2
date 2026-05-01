using L3C1WebAPI.Data;
using L3C1WebAPI.Data.Entities;
using L3C1WebAPI.Models;
using L3C1WebAPI.Services;
using L3C1WebAPI.Services.Implementations;
using L3C1WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Student>(
    builder.Configuration.GetSection("Student")
    );


builder.Services.AddDbContext<AppDbContext>(
   (options) => { options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")); }
);

builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<IAuthService,  AuthService>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	}
	)
    .AddJwtBearer(
        options =>
        {
            var jwtOptions = builder.Configuration.GetSection("Jwt");

			options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOptions["Issuer"],

                ValidateAudience = true,
                ValidAudience = jwtOptions["Audience"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions["SecretKey"]!)),

                ValidateLifetime = true
			};

		}


	)
    ;


//identity framework registration
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    // Development - open to all origins
    options.AddPolicy("Production", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Production");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	db.Database.Migrate();
}



app.Run();
