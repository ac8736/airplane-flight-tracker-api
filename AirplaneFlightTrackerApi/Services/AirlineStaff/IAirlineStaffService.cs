using AirplaneFlightTrackerApi.Models;
using MySql.Data.MySqlClient;

namespace AirplaneFlightTrackerApi.Services.AirlineStaffs;

public interface IAirlineStaffService
{
    AirlineStaff? GetAirlineStaff(string email);
    bool CreateAirlineStaff(AirlineStaff airlineStaff);
    void UpdateAirlineStaff();
    void RemoveAirlineStaff(string email);
}