using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using PaySkyTaskAPI.Middlewares;
using PaySkyTaskAPI.Models.Payment;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<PaymentGatewayService>();

builder.Services.AddAuthorization().AddSingleton<IAuthorizationMiddlewareResultHandler, PaySkyTaskAuthorizationMiddlewareResultHandler>();

// Enable firebase
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(builder.Configuration["FirebasePrivateKey"])
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features?
        .Get<IExceptionHandlerPathFeature>()?
        .Error;

        context.Response.StatusCode = (int)HttpStatusCode.OK;
        await context.Response.WriteAsJsonAsync(new PayResponse(ResponseMessage.Fail + ": " + exception?.Message, ResponseCode.Fail));
    });
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
