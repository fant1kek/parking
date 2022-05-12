using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Parking
{
    internal class DataBase
    {
        SqlConnection _connection = new SqlConnection(@"Data Source=LAPTOP-78EUHOP1;Initial Catalog=Parking;Integrated Security=True");
        public void openConnection()
        {
            if(_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void closeConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return _connection;
        }
        public List<string> GetFreePlaces()
        {
            return CommandExecuteReader($"SELECT Place FROM ParkingPlaces WHERE RentalTime = 0");
        }
        public List<string> GetOccupiedPlaces()
        {
            openConnection();
            SqlCommand command = new SqlCommand($"SELECT Place, CarName, CarNumber, RentalTime, CarType, RentalEnd FROM ParkingPlaces WHERE RentalTime != 0", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> places = new List<string>();
            while (reader.Read())
            {
                places.Add($"[{reader[0]}] - {reader[1]} | {reader[2]}({reader[4]}) - время аренды\\начало аренды\\конец аренды: {reader[3]}\\{Convert.ToDateTime(reader[5]).AddHours(-Convert.ToDouble(reader[3]))}\\{reader[5]}");
            }
            reader.Close();
            closeConnection();
            return places;
        }
        public void SetPlace(PassengerCar passengerCar, PassengerPlace passengerPlace, SetPlaces setPlaces)
        {
            DBUpdate(passengerCar.carName, passengerCar.carNumber, passengerPlace.RentalTime, "passenger", setPlaces.place, Convert.ToString(DateTime.Now.AddHours(passengerPlace.RentalTime)));
        }
        public void SetPlace(TruckCar truckCar, TruckPlace truckPlace, SetPlaces setPlaces)
        {
            DBUpdate(truckCar.carName, truckCar.carNumber, truckPlace.RentalTime, "truck", setPlaces.place, Convert.ToString(DateTime.Now.AddHours(truckPlace.RentalTime)));
        }
        public void CheckPlaces()
        {
            List<string> date = CommandExecuteReader($"SELECT RentalEnd FROM ParkingPlaces WHERE RentalEnd > 0");
            for (int i = 0; i < date.Count; i++)
            {
                if (DateTime.Now > Convert.ToDateTime(date[i]))
                {
                    CommandExecuteNonQuery($"UPDATE ParkingPlaces SET CarName = '', CarNumber = '', RentalTime = '', CarType = '', RentalEnd = '' WHERE RentalEnd = '{date[i]}'");
                }
            }
        }
        public void DBUpdate(string carName, string carNumber, double RentalTime, string carType, string place, string RentalEnd)
        {
            CommandExecuteNonQuery($"UPDATE ParkingPlaces SET CarName = '{carName}', CarNumber = '{carNumber}', RentalTime = '{RentalTime}', CarType = '{carType}', RentalEnd = '{RentalEnd}' WHERE Place = '{place}'");
        }
        public void AddPlace()
        {
            CommandExecuteNonQuery($"INSERT ParkingPlaces(CarName, CarNumber, RentalTime, CarType, RentalEnd) VALUES ('', '', '', '', '')");
        }
        public List<string> GetAdministrators()
        {
            openConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Administrators", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> Administrators = new List<string>();
            while (reader.Read())
            {
                Administrators.Add($"Логин: {reader[0]}, Пароль: {reader[1]}");
            }
            reader.Close();
            closeConnection();
            return Administrators;
        }
        public bool AddAdministrator(string login, string password)
        {
            List<string> AllLogin = CommandExecuteReader($"SELECT login FROM Administrators");
            for (int i = 0; i < AllLogin.Count; i++)
            {
                if (AllLogin[i] == login)
                {
                    closeConnection();
                    return false;
                }
                else
                {
                    CommandExecuteNonQuery($"INSERT Administrators(login, password) VALUES ('{login}', '{password}')");
                    closeConnection();
                    return true;
                }
            }
            return false;
        }
        public void DeleteAdministrator(string login, string password)
        {
            CommandExecuteNonQuery($"DELETE FROM Administrators WHERE login = '{login}' AND password = '{password}'");
        }
        public bool Authorization(string login, string password)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT login, password FROM Administrators WHERE login = '{login}' AND password = '{password}'", _connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }
        public void CommandExecuteNonQuery(string cmd)
        {
            openConnection();
            SqlCommand command = new SqlCommand(cmd, _connection);
            command.ExecuteNonQuery();
            closeConnection();
        }
        public List<string> CommandExecuteReader(string cmd)
        {
            openConnection();
            SqlCommand command = new SqlCommand(cmd, _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> data = new List<string>();
            while (reader.Read())
            {
                data.Add(reader[0].ToString());
            }
            reader.Close();
            closeConnection();
            return data;
        }
    }
}
