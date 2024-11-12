using EstudoRBMQ.Controllers;
using EstudoRBMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and Swagger for API documentation
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add RabbitMQ services
builder.Services.AddRabbitMQService();

var app = builder.Build();

app.AddApiEndpoints();

// Setup Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
