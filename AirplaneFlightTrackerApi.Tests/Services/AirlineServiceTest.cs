using AirplaneFlightTrackerApi.Models;
using AirplaneFlightTrackerApi.Services.Airlines;
using AirplaneFlightTrackerApi.Services.Database;

namespace AirplaneFlightTrackerApi.Tests;

public class AirlineServiceTest
{
    private readonly AirlineService _airlineService;
    private readonly IDatabaseService _databaseService;

    public AirlineServiceTest()
    {
        _databaseService = new DatabaseService();
        _airlineService = new AirlineService(_databaseService);
    }

    [SetUp]
    public void Setup()
    {

    }

    [Test, Order(1)]
    public void CreateAirlineTest()
    {
        Airline mockAirline = new("United-Airlines");

        bool created = _airlineService.CreateAirline(mockAirline);
        bool notCreated = _airlineService.CreateAirline(mockAirline);

        Assert.Multiple(() =>
        {
            Assert.That(created, Is.EqualTo(true));
            Assert.That(notCreated, Is.EqualTo(false));
        });
    }

    [Test, Order(2)]
    public void RemoveAirlineTest()
    {
        Airline mockAirline = new("United-Airlines");

        _airlineService.RemoveAirline(mockAirline.Name);
        Airline? mockResult = _airlineService.GetAirline(mockAirline.Name);

        Assert.That(mockResult, Is.EqualTo(null));
    }
}
