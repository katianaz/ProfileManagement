using CrossCutting.Error;
using CrossCutting.Extensions;
using CrossCutting.Middlewares;
using Domain.Helpers.Validation;
using Domain.Helpers.Validation.Interfaces;
using Domain.Services;
using Domain.Services.Interfaces;
using Repository.Repositories;
using Repository.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger();

builder.Services.AddSingleton<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProfileValidation, ProfileValidation>();
builder.Services.AddHostedService<ProfileBackgroundService>();
builder.Services.AddScoped<ErrorContext>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseSwaggerDevelopment();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
