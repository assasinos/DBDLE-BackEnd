using DBDLE_BackEnd.Services.DailyCharacter;
using DBDLE_BackEnd.Services.DailyCharacterUpdate;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);


//CORS
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var cors = builder.Configuration.GetSection("CORS") ?? throw new Exception("CORS not found, check appsettings file");
var corsOrigins = cors.GetSection("AllowedOrigins").Get<string[]>() ?? throw new Exception("CORS origins not found, check appsettings file");
var corsMethods = cors.GetSection("AllowedMethods").Get<string[]>() ?? throw new Exception("CORS methods not found, check appsettings file");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy => { policy.WithOrigins(corsOrigins).WithMethods(corsMethods).AllowAnyHeader(); });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));


//Maybe change this in the future
builder.Services.Configure<DailyCharacterConfiguration>(builder.Configuration.GetSection("DailyCharacter"));
builder.Services.AddSingleton<IDailyCharacter, DailyCharacter>();

builder.Services.AddHostedService<DailyCharacterUpdateService>();


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
app.UseCors(myAllowSpecificOrigins);
app.Run();