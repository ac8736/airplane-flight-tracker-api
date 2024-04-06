using AirplaneFlightTrackerApi.Models;
using AirplaneFlightTrackerApi.Services.Database;
using AirplaneFlightTrackerApi.Services.Airports;

namespace AirplaneFlightTrackerApi.Tests;

public class AirportServiceTest
{
    private readonly IAirportService _airportService;
    private readonly IDatabaseService _databaseService;

    public AirportServiceTest()
    {
        _databaseService = new DatabaseService();
        _airportService = new AirportService(_databaseService);
    }

    [Test, Order(1)]
    public void GetAirportTest()
    {
        string mockAirport = "LGA";

        Airport? airport = _airportService.GetAirport(mockAirport);

        Assert.That(airport, Is.Not.EqualTo(null));
        Assert.That(airport.Code, Is.EqualTo(mockAirport));
    }

    [Test, Order(2)]
    public void CreateAirportTest()
    {
        Airport mockAirport = new("JFK Airport", "JFK", "NYC", "United States", DateTime.Now);

        bool created = _airportService.CreateAirport(mockAirport);
        bool notCreated = _airportService.CreateAirport(mockAirport);

        Assert.Multiple(() =>
        {
            Assert.That(created, Is.EqualTo(true));
            Assert.That(notCreated, Is.EqualTo(false));
        });
    }

    [Test, Order(3)]
    public void DeleteAirportTest()
    {
        string mockAirport = "JFK";

        _airportService.RemoveAirport(mockAirport);
        Airport? airport = _airportService.GetAirport(mockAirport);

        Assert.That(airport, Is.EqualTo(null));
    }
}