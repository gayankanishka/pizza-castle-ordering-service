using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using PizzaCastle.OrderingService.Application;
using PizzaCastle.OrderingService.Domain.Options;
using PizzaCastle.OrderingService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var auth0Options = builder.Configuration
    .GetSection(Auth0Options.Auth0)
    .Get<Auth0Options>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = auth0Options.Authority;
    options.Audience = auth0Options.Audience;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// TODO: GW | Add token support to swagger ui
// builder.Services.AddSwaggerGen(x =>
// {
//     x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//     {
//         Type = SecuritySchemeType.OAuth2,
//         Flows = new OpenApiOAuthFlows
//         {
//             Implicit = new OpenApiOAuthFlow
//             {
//                 AuthorizationUrl = new Uri(""),
//             }
//         },
//         In = ParameterLocation.Header,
//         Scheme = JwtBearerDefaults.AuthenticationScheme,
//     });
//
//     x.AddSecurityRequirement(new OpenApiSecurityRequirement
//     {
//         {
//             new OpenApiSecurityScheme
//             {
//                 Reference = new OpenApiReference
//                 {
//                     Type = ReferenceType.SecurityScheme,
//                     Id = JwtBearerDefaults.AuthenticationScheme
//                 }
//             },
//             new string[] {}
//         }
//     });
// });
builder.Services.AddHealthChecks();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services
    .AddCors(o =>
        o.AddDefaultPolicy(b =>
            b.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI(x =>
    // {
    //     x.OAuthClientId("");
    //     x.OAuthClientSecret("");
    // });

    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseCors();

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();