// This is going to build the api. It's is a server that's going to run and listening for request 
var builder = WebApplication.CreateBuilder(args);

// The AddControllers method is going to do something very similar to our AddEndpointsApiExplorer() and AddSwaggerGen()
// And It's going to add those endpoints to our controller reference
builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Swagger is only available in development mode
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// redirect from http to https route
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// MapControllers() have access to that controller mapping which was created the AddControllers() method
// And will be able to set our routes up for us
app.MapControllers();

// app.MapGet("/weatherforecast", () =>
// {
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();



