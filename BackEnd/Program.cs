using ANU.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDB");
var mongoDatabaseName = builder.Configuration["DatabaseName"];

var mongoClient = new MongoClient(mongoConnectionString);
var database = mongoClient.GetDatabase(mongoDatabaseName);

builder.Services.AddSingleton<IMongoDatabase>(database);
builder.Services.AddSingleton<IMongoCollection<User>>(sp =>
    sp.GetRequiredService<IMongoDatabase>().GetCollection<User>("users"));
builder.Services.AddSingleton<IMongoCollection<Ocorrencias>>(sp =>
    sp.GetRequiredService<IMongoDatabase>().GetCollection<Ocorrencias>("ocorrencias"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();