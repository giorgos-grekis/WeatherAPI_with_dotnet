// This is going to build the api. It's is a server that's going to run and listening for request 
var builder = WebApplication.CreateBuilder(args);

// The AddControllers method is going to do something very similar to our AddEndpointsApiExplorer() and AddSwaggerGen()
// And It's going to add those endpoints to our controller reference
builder.Services.AddControllers();

// CORS => cross origin resource sharing.
builder.Services.AddCors((options) =>
    {
        // Development CORS Policy
        options.AddPolicy("DevCors", (corsBuilder) =>
        {
            corsBuilder
                .WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });

        // Production CORS Policy
        options.AddPolicy("ProdCors", (corsBuilder) =>
        {
            corsBuilder
                .WithOrigins("https://myProductionsSite.com")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
    });



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Swagger is only available in development mode
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}

// redirect from http to https route
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
    app.UseCors("ProdCors");
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



