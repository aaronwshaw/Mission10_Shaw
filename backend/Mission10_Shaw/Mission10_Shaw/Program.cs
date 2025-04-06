using Microsoft.EntityFrameworkCore;
using Mission10_Shaw.Data;

var builder = WebApplication.CreateBuilder(args);

// Set up EF Core to use the correct SQLite database file in the project root
builder.Services.AddDbContext<BowlingLeagueContext>(options =>
    options.UseSqlite("Data Source=./RecommendationDB.sqlite"));

// CORS config so your React frontend can call the API
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply the CORS policy
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Ensure the DB exists and optionally run your data seeder
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BowlingLeagueContext>();
    db.Database.EnsureCreated(); // optional, but safe
    DataSeeder.Seed(db);         // ← this line must be here and NOT commented
}


app.Run();
