namespace AirplaneFlightTrackerApi.Contracts.Airports;

public record CreateAirportRequest(
    string Name,
    string Code,
    string City,
    string Country
);