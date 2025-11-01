using Auth;
using Infrastructure.Configuration;
using Infrastructure.Data;
using Infrastructure.Data.Persistence.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseContext()
                .AddDatabaseUserContext();

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




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;

        var errorDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server Error",
            Instance = context.Request.Path,

        };
        var options = new JsonSerializerOptions
        {

            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        var json = JsonSerializer.Serialize(errorDetails, options);
        await context.Response.WriteAsync(json);
    }
});

app.Run();
