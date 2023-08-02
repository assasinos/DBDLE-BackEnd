using DBDLE_BackEnd.Services.DailyCharacter;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));


//Maybe change this in the future
builder.Services.Configure<DailyCharacterConfigruation>(builder.Configuration.GetSection("DailyCharacter"));
builder.Services.AddSingleton<IDailyCharacter, DailyCharacter>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();