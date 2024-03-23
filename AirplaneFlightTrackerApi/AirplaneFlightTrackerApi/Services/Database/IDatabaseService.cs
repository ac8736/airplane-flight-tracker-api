using MySql.Data.MySqlClient;
using AirplaneFlightTrackerApi.Enums;

namespace AirplaneFlightTrackerApi.Services.Database;

public interface IDatabaseService
{
    void Connect();
    void Disconnect();

    void CreateItem(string query);
    void DeleteItem(string query);
    MySqlDataReader GetItem(string query);
}