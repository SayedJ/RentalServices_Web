
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Context;

using RentalServicesWebApi.Repository;
using RentalServicesWebApi;
using RentalServicesWebApi.Configuratioins;

using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("RentalServicesDB");
builder.Services.AddDbContext<RentalContext>(options => options.UseSqlServer(connectionString));


builder.Services.ConfigureIdentity();

builder.Services.AddAutoMapper(typeof(MappperInitializer));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = opt =>
    {
        opt.HttpContext.Response.Redirect("Account/login");
        return Task.FromResult(0);
    };
});
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
});


builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddCors();
builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                ("BasicAuthentication", null);
builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseRouting();




app.UseAuthentication();
app.UseAuthorization();


app.UseCors(configurePolicy: options =>
{
    options.WithMethods("GET", "POST", "PUT", "DELETE");
    options.WithOrigins(
        "http://localhost:7163");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
