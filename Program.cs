<<<<<<< HEAD

using WebApiApp.WebApiClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVehicle, WebApiApp.WebApiClasses.Lorry>();
builder.Services.AddScoped<IVehicle, WebApiApp.WebApiClasses.Car>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    var vehicleServices = context.RequestServices.GetServices<IVehicle>();
    foreach (var vehicle in vehicleServices)
    {
        // You can perform any initialization or logging here if needed
        Console.WriteLine($"Registered Vehicle Service: {vehicle.GetType().Name}");
    }
    await next.Invoke();

    //Console.WriteLine($"Request processing completed.{context.Request.Path}");

    //await next(context);

    //Console.WriteLine($"Response processing completed.{context.Response.StatusCode}");

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<WebApiApp.Middleware.CustomHeaderMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
=======
using WebApiApp.Interfaces;
using WebApiApp.WebApiClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVehicle, Lorry>();
builder.Services.AddScoped<IVehicle, Car>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    var vehicleServices = context.RequestServices.GetServices<IVehicle>();
    foreach (var vehicle in vehicleServices)
    {
        // You can perform any initialization or logging here if needed
        Console.WriteLine($"Registered Vehicle Service: {vehicle.GetType().Name}");
    }
    await next.Invoke();

    //Console.WriteLine($"Request processing completed.{context.Request.Path}");

    //await next(context);

    //Console.WriteLine($"Response processing completed.{context.Response.StatusCode}");

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<WebApiApp.Middleware.CustomHeaderMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
>>>>>>> 96e120a7f7ac2315dad22899e2bf9aa903b802ce
