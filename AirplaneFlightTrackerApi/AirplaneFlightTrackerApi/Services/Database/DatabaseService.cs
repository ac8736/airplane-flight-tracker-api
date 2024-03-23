using MySql.Data.MySqlClient;
using AirplaneFlightTrackerApi.Enums;

namespace AirplaneFlightTrackerApi.Services.Database;

public class DatabaseService : IDatabaseService
{
    private readonly MySqlConnection Connection;

    public DatabaseService()
    {
        Connection = new("Server=127.0.0.1; database=airline_ticket_reservation; UID=root; password=password;");
    }

    public void Connect()
    {
        Connection.Open();
    }

    public void Disconnect()
    {
        Connection.Close();
    }

    public void CreateItem(string query)
    {
        var cmd = new MySqlCommand(query, Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void DeleteItem(string query)
    {
        var cmd = new MySqlCommand(query, Connection);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public MySqlDataReader GetItem(string query)
    {
        var cmd = new MySqlCommand(query, Connection);
        MySqlDataReader reader = cmd.ExecuteReader();
        cmd.Dispose();
        return reader;
    }
}
