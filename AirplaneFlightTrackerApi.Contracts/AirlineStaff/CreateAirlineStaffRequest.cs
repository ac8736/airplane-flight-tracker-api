namespace AirplaneFlightTrackerApi.Contracts.AirlineStaffs;

public record CreateAirlineStaffRequest(
    string Username,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Airline
);
