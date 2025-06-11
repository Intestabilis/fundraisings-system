using Fundraisings.Persistence.DataAccess;
using Fundraisings.Persistence.DataAccess.Repositories;
using Fundraisings.Application.Services;
using Fundraisings.Application.Services.UseCases;
using Fundraisings.Domain.Abstractions;
using Fundraisings.Persistence.ExternalData.Parsers;
using Microsoft.EntityFrameworkCore;
using WebApp.Contracts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddScoped<FundraisingsRepository, FundraisingsRepository>();
builder.Services.AddScoped<DirectionsRepository, DirectionsRepository>();
builder.Services.AddScoped<EquipmentsRepository, EquipmentsRepository>();
builder.Services.AddScoped<UsersRepository, UsersRepository>();
builder.Services.AddScoped<ReportsRepository, ReportsRepository>();
builder.Services.AddScoped<ComplaintsRepository, ComplaintsRepository>();
builder.Services.AddScoped<VerificationsRepository, VerificationsRepository>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IFundraisingsService, FundraisingsService>();
builder.Services.AddScoped<IDirectionsService, DirectionsService>();
builder.Services.AddScoped<IEquipmentsService, EquipmentsService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddControllers();
builder.Services.AddScoped<IDonationAmountParser, MonobankJarAmountParser>();
builder.Services.AddScoped<UpdateFundraisingAmountsUseCase>();
builder.Services.AddHostedService<FundraisingUpdateAmountBackgroundService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddDbContext<FundraisingDbContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(FundraisingDbContext)),  o => o.UseNetTopologySuite());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();
app.MapControllers();
app.Run(); 