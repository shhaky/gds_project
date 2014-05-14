using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _Exchange_ServerSide
{
    class DataHelper
    {
        private MySqlConnection connection;

        public DataHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +//server address
                                     "database=dbi258748;" + // your database name
                                     "user id=dbi258748;" + // your user id
                                     "password=Y8oBfxSO73;" + // your password
                                     "connect timeout=30;";
            connection = new MySqlConnection(connectionInfo);
        }

        public long getLastestExistedUserId()
        {
            string sql = "SELECT max(UserId) FROM user";
            MySqlCommand command = new MySqlCommand(sql, connection);
            long temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempUserId;
                while (reader.Read())
                {
                    tempUserId = Convert.ToString(reader["max(UserId)"]);
                    temp = Convert.ToInt64(tempUserId);
                    return temp;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }

        public bool checkIfExistedUserName(string userName)
        {
            string sql = "SELECT UserName FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempUserName;
                while (reader.Read())
                {
                    tempUserName = Convert.ToString(reader["UserName"]);
                    if (tempUserName == userName)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool addNewUser(long userId, string userName, string passWord, string firstName, string lastName, string email, string joinDate)
        {
            string sql = "INSERT INTO user (UserId,UserName, PassWord, FirstName, LastName, Email, JoinDate) VALUES('" + userId + "','" + userName + "','" + passWord + "','" + firstName + "','" + lastName + "','" + email + "','" + joinDate + "')";
            MySqlCommand com = new MySqlCommand(sql, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool checkPassword(string userName, string passWord)
        {
            string sql = "SELECT PassWord FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempPassword;
                while (reader.Read())
                {
                    tempPassword = Convert.ToString(reader["PassWord"]);
                    if (tempPassword == passWord)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
