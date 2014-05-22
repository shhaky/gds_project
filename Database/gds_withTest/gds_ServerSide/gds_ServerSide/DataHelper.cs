using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace gds_ServerSide
{
    class DataHelper
    {
        private MySqlConnection connection;

        //===================================connect to database======================================
        public DataHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +//server address
                                     "database=dbi258748;" + // your database name
                                     "user id=dbi258748;" + // your user id
                                     "password=Y8oBfxSO73;" + // your password
                                     "connect timeout=30;";
            connection = new MySqlConnection(connectionInfo);
        }

        //=================================get Lastest Existed UserId=================================
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

        //=======================================check If Existed UserName=================================
        public bool checkIsExistedUserName(string userName)
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

        //=====================================add new user to database====================================
        public bool addNewUser(long userId, string userName, string passWord, string firstName, string lastName, string email, string joinDate, string lastLoginTime)
        {
            string sql = "INSERT INTO user (UserId,UserName, PassWord, FirstName, LastName, Email, JoinDate, LastLoginTime) VALUES('" + userId + "','" + userName + "','" + passWord + "','" + firstName + "','" + lastName + "','" + email + "','" + joinDate + "," + lastLoginTime + "')";
            MySqlCommand com = new MySqlCommand(sql, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }
}
