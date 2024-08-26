using Craftify.Api.Hubs;
using Craftify.Application;
using Craftify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{

    // Configure CORS
    app.UseCors();

    // Enable HTTPS redirection
    app.UseHttpsRedirection();

    // Set up routing
    app.UseRouting();

    // Enable authentication and authorization
    app.UseAuthentication();
    app.UseAuthorization();

    // Configure Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Map controllers
    app.MapControllers();

    // Map SignalR Hub
    app.MapHub<ChatHub>("hubs/chat");
    app.MapHub<NotificationHub>("hubs/notification");

    app.Run();
}

//ready to publish :)
//testing : 
//try one
//try two
//try three
//try six
