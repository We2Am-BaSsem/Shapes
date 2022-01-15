using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
public class DBManager : MonoBehaviour
{
    public static DBManager s_dbManager;
    private string _dbName = "URI=file:database/Shapes.db";
    void Awake()
    {
        s_dbManager = this;
    }
    void Update()
    {
        if (s_dbManager == null)
            s_dbManager = this;
    }
    public (string, string, float, float, float, float) Load()
    {
        using (var connection = new SqliteConnection(_dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Shape;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (reader["type"].ToString(), reader["color"].ToString(), float.Parse(reader["rotX"].ToString()), float.Parse(reader["rotY"].ToString()), float.Parse(reader["rotZ"].ToString()), float.Parse(reader["rotW"].ToString()));
                    }
                }
            }
            connection.Close();
        }
        return ("Cube", "#FF0000", 0.0f, 0.0f, 0.0f, 0.0f);
    }
    public void Save(string type, string color, float rotX, float rotY, float rotZ, float rotW)
    {
        using (var connection = new SqliteConnection(_dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Shape SET type=\"" + type + "\" ,color=\"#" + color + "\" ,rotX=" + rotX + " ,rotY=" + rotY + " ,rotZ=" + rotZ + " ,rotW=" + rotW + " WHERE id=" + 1 + ";";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
