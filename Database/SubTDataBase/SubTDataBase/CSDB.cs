using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;

namespace SubTDataBase
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CSDB : ISDB
    {
        private MySqlConnection connectionInSDB;
        public CSDB()
        {
            String connectionInfoInSDB = "server=athena01.fhict.local;" +//server address
                                             "database=dbi251752;" + // your database name
                                             "user id=dbi251752;" + // your user id
                                             "password=RLsjlayMSe;" + // your password
                                             "connect timeout=30;";
            connectionInSDB = new MySqlConnection(connectionInfoInSDB);
        }

        //---useful method---
        public long getLastestExistedUserId()
        {
            string sql = "SELECT max(UserId) FROM users";
            MySqlCommand command = new MySqlCommand(sql, connectionInSDB);
            long tempUserId;
            try
            {
                connectionInSDB.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempId;
                while (reader.Read())
                {
                    tempId = Convert.ToString(reader["max(UserId)"]);
                    tempUserId = Convert.ToInt64(tempId);
                    return tempUserId;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                connectionInSDB.Close();
            }
            return 0;
        }
        public bool checkUserName(string userName)
        {
            string sql = "SELECT UserName FROM users WHERE UserName ='" + userName + "';";
            MySqlCommand com = new MySqlCommand(sql, connectionInSDB);
            string tempUserName;
            try
            {
                connectionInSDB.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    tempUserName = Convert.ToString(reader["UserName"]);
                    if (tempUserName == userName)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connectionInSDB.Close();
            }
            return false;
        }

        //---register part---
        public void registerAsUser(long userId, string userName, string firstName, string lastName, string joinDate)
        {
            string sql = "INSERT INTO users (UserId, UserName, FirstName, LastName, JoinDate) VALUES('" + userId + "','" + userName + "','" + firstName + "','" + lastName + "','" + joinDate + "')";
            MySqlCommand com = new MySqlCommand(sql, connectionInSDB);
            connectionInSDB.Open();
            com.ExecuteNonQuery();
            connectionInSDB.Close();
        }
        //---login part---
        public long showUserId(string userName)
        {
            string sql = "SELECT UserId FROM users WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInSDB);
            long tempUserId;
            try
            {
                connectionInSDB.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempId;
                while (reader.Read())
                {
                    tempId = Convert.ToString(reader["UserId"]);
                    tempUserId = Convert.ToInt64(tempId);
                    return tempUserId;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                connectionInSDB.Close();
            }
            return 0;
        }

        //---account management---
        public string showUserName(long userId)
        {
            string sql = "SELECT UserName FROM users WHERE UserId ='" + userId + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInSDB);
            string tempUserName;
            try
            {
                connectionInSDB.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempName;
                while (reader.Read())
                {
                    tempName = Convert.ToString(reader["UserName"]);
                    tempUserName = tempName;
                    return tempUserName;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connectionInSDB.Close();
            }
            return null;
        }
 
        //---transaction part---

        //---trade part---
    }
}
