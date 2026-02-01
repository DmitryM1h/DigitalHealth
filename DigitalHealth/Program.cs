using Auth;
using DigitalHealth.Auth;
using DigitalHealth.Infrastructure.Redis;
using Infrastructure.Configuration;
using Infrastructure.Data;
using Infrastructure.Data.Persistence.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token in format: Bearer {your token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDatabaseContext(builder.Configuration)
                .AddDatabaseUserContext(builder.Configuration);
builder.Services.AddRedis(builder.Configuration);

builder.Services.AddDataSources();
builder.Services.AddMediatr();




var identityBuilder = builder.Services.AddIdentity<User, IdentityRole<Guid>>(opts =>
{
    opts.Password.RequiredLength = 5;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
})
    .AddEntityFrameworkStores<UserContext>();
//.AddDefaultTokenProviders();

identityBuilder.AddTokenProvider("DigitalHealth", typeof(DataProtectorTokenProvider<User>));


builder.Services.AddAuth(builder.Configuration);




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next();
//    }
//    catch (Exception ex)
//    {
//        context.Response.StatusCode = 500;

//        var errorDetails = new ProblemDetails
//        {
//            Status = StatusCodes.Status500InternalServerError,
//            Title = "Server Error",
//            Instance = context.Request.Path,

//        };
//        var options = new JsonSerializerOptions
//        {

//            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
//            WriteIndented = true,
//            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
//        };
//        var json = JsonSerializer.Serialize(errorDetails, options);
//        await context.Response.WriteAsync(json);
//    }
//});

app.Run();
