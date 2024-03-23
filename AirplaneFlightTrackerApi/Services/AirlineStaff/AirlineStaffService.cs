using AirplaneFlightTrackerApi.Models;
using AirplaneFlightTrackerApi.Services.Database;
using MySql.Data.MySqlClient;

namespace AirplaneFlightTrackerApi.Services.AirlineStaffs;

public class AirlineStaffService(IDatabaseService databaseService) : IAirlineStaffService
{
    private readonly IDatabaseService _databaseService = databaseService;

    public bool CreateAirlineStaff(AirlineStaff airlineStaff)
    {
        if (GetAirlineStaff(airlineStaff.Email) != null)
        {
            return false;
        }

        _databaseService.Connect();
        string dateCreated = airlineStaff.DateCreated.ToString("yyyy-MM-dd HH:mm:ss");
        string lastModified = airlineStaff.LastModified.ToString("yyyy-MM-dd HH:mm:ss");
        string query = $"INSERT INTO airline_staff VALUES('{airlineStaff.Username}', '{airlineStaff.Email}', '{airlineStaff.Password}', '{airlineStaff.FirstName}', '{airlineStaff.LastName}', '{airlineStaff.Airline.Replace(' ', '-')}', '{dateCreated}', '{lastModified}');";
        _databaseService.CreateItem(query);
        _databaseService.Disconnect();
        return true;
    }

    public AirlineStaff? GetAirlineStaff(string email)
    {
        _databaseService.Connect();
        string query = $"SELECT * FROM airline_staff WHERE email='{email}'";
        MySqlDataReader data = _databaseService.GetItem(query);
        while (data.Read())
        {
            AirlineStaff airlineStaff = new(data.GetString("username"), data.GetString("email"), data.GetString("acc_password"), data.GetString("firstName"), data.GetString("lastName"), data.GetString("airline").Replace('-', ' '), data.GetDateTime("dateCreated"), data.GetDateTime("lastModified"));

            _databaseService.Disconnect();
            return airlineStaff;
        }

        _databaseService.Disconnect();
        return null;
    }

    public void RemoveAirlineStaff(string email)
    {
        _databaseService.Connect();
        string query = $"DELETE FROM airline_staff WHERE email='{email}'";
        _databaseService.DeleteItem(query);
        _databaseService.Disconnect();
    }

    public void UpdateAirlineStaff()
    {
        throw new NotImplementedException();
    }
}