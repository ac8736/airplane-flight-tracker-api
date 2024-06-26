using AirplaneFlightTrackerApi.Services.Airlines;
using AirplaneFlightTrackerApi.Services.AirlineStaffs;
using AirplaneFlightTrackerApi.Services.Airports;
using AirplaneFlightTrackerApi.Services.Database;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<IAirportService, AirportService>();
    builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
    builder.Services.AddSingleton<IAirlineService, AirlineService>();
    builder.Services.AddSingleton<IAirlineStaffService, AirlineStaffService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
