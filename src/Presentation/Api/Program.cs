using Api.Extensions;
using Api.Middlewares;
using Application;
using Common.Response;
using FluentValidation.AspNetCore;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .SuppressFluentValidationExceptionModel<ExceptionResponse>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddCors(cors =>
    {
        cors.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
    })
    .ApplicationRegister()
    .PersistanceRegister(builder.Configuration)
    .AddJwtBearerAuthentication(builder.Configuration)
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseCors();
app.UseHttpsRedirection();

// app.UseAuthorization();
// app.UseAuthentication();

app.MapControllers();

app.Run();
