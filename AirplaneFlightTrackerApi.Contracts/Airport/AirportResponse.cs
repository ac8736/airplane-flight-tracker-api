namespace AirplaneFlightTrackerApi.Contracts.Airports;

public record AirportResponse(
    string Name,
    string Code,
    string City,
    string Country,
    DateTime DateCreated
);