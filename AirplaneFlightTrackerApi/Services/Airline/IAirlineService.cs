using AirplaneFlightTrackerApi.Models;

namespace AirplaneFlightTrackerApi.Services.Airlines;

public interface IAirlineService
{
    bool CreateAirline(Airline airline);
    void RemoveAirline(string name);
    Airline? GetAirline(string name);
}
