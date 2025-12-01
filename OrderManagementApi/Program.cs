using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;

using OrderManagementApi.Data;

using OrderManagementApi.Models;

using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


// DB Context

builder.Services.AddDbContext<ApplicationDbContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()

.AddEntityFrameworkStores<ApplicationDbContext>()

.AddDefaultTokenProviders();


// JWT Authentication

var jwt = builder.Configuration.GetSection("Jwt");

//Registers authentication middleware in the DI container.

builder.Services.AddAuthentication(options =>

{

    options.DefaultAuthenticateScheme = "JwtBearer";

    options.DefaultChallengeScheme = "JwtBearer"; //what happens when request is unauthorized (e.g., returns 401).

}).AddJwtBearer("JwtBearer", options =>

{

    options.TokenValidationParameters = new TokenValidationParameters

    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,


        ValidIssuer = jwt["Issuer"],

        ValidAudience = jwt["Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]))

    };

});


builder.Services.AddControllers();


var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}


app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();