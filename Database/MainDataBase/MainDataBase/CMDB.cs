using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;

namespace MainDataBase
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CMDB : IMDB
    {
        private MySqlConnection connectionInMDB;
        public CMDB()
        {
            String connectionInfoInMDB = "server=athena01.fhict.local;" +//server address
                                         "database=dbi258748;" + // your database name
                                         "user id=dbi258748;" + // your user id
                                         "password=Y8oBfxSO73;" + // your password
                                         "connect timeout=30;";
            connectionInMDB = new MySqlConnection(connectionInfoInMDB);
        }

        //---useful method---
        public long getLastestExistedUserId()
        {
            string sql = "SELECT max(UserId) FROM users";
            MySqlCommand command = new MySqlCommand(sql, connectionInMDB);
            long tempUserId;
            try
            {
                connectionInMDB.Open();
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
                connectionInMDB.Close();
            }
            return 0;
        }
        public bool checkUserName(string userName)
        {
            string sql = "SELECT UserName FROM users WHERE UserName ='" + userName + "';";
            MySqlCommand com = new MySqlCommand(sql, connectionInMDB);
            string tempUserName;
            try
            {
                connectionInMDB.Open();
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
                connectionInMDB.Close();
            }
            return false;
        }
        
        //---register part---
        public void registerAsUser(long userId, string userName, string firstName, string lastName, string joinDate, string passWord, string eMail, string lastLoginTime)
        {
            string sql = "INSERT INTO users (UserId, UserName, FirstName, LastName, JoinDate, PassWord, Email, LastLoginTime) VALUES('" + userId + "','" + userName + "','" + firstName + "','" + lastName + "','" + joinDate + "','" + passWord + "','" + eMail + "','" + lastLoginTime + "')";
            MySqlCommand com = new MySqlCommand(sql, connectionInMDB);
            connectionInMDB.Open();
            com.ExecuteNonQuery();
            connectionInMDB.Close();
        }
        //---login part---
        public bool login(string userName, string passWord)
        {
            string sql = "SELECT PassWord FROM users WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInMDB);
            try
            {
                connectionInMDB.Open();
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
                connectionInMDB.Close();
            }
            return false;
        }

        //---account management---
        public long showUserId(string userName)
        {
            string sql = "SELECT UserId FROM users WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInMDB);
            long tempUserId;
            try
            {
                connectionInMDB.Open();
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
                connectionInMDB.Close();
            }
            return 0;
        }
        public string showUserName(long userId)
        {
            string sql = "SELECT UserName FROM users WHERE UserId ='" + userId + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInMDB);
            string tempUserName;
            try
            {
                connectionInMDB.Open();
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
                connectionInMDB.Close();
            }
            return null;
        }

        public string showEmail(long userId)
        {
            string sql = "SELECT Email FROM users WHERE UserId ='" + userId + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInMDB);
            string tempUserEmail;
            try
            {
                connectionInMDB.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempEmail;
                while (reader.Read())
                {
                    tempEmail = Convert.ToString(reader["Email"]);
                    tempUserEmail = tempEmail;
                    return tempUserEmail;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connectionInMDB.Close();
            }
            return null;
        }
        public bool changePass(long userId, string newPass)
        {
            string sql = "UPDATE users SET PassWord = '" + newPass + "' WHERE UserId = '" + userId + "'";
            MySqlCommand com = new MySqlCommand(sql, connectionInMDB);
            connectionInMDB.Open();
            com.ExecuteNonQuery();
            connectionInMDB.Close();
            return true;
        }

        public void updateLoginTime(long userId, string loginTime)
        {
            string sql = "UPDATE users SET LastLoginTime = '" + loginTime + "' WHERE UserId = '" + userId + "'";
            MySqlCommand com = new MySqlCommand(sql, connectionInMDB);
            connectionInMDB.Open();
            com.ExecuteNonQuery();
            connectionInMDB.Close();
        }

        public decimal showBalance(long userId, string coinType)
        {
            string sql = "SELECT Balance FROM coins WHERE UserId ='" + userId + "AND CoinType=" + coinType + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInMDB);
            decimal tempBalance = 0;
            try
            {
                connectionInMDB.Open();
                MySqlDataReader reader = command.ExecuteReader();
                decimal temp;
                while (reader.Read())
                {
                    temp = Convert.ToDecimal(reader["Balance"]);
                    tempBalance = tempBalance + temp;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                connectionInMDB.Close();
            }
            return tempBalance;
        }


        //---transaction part---

        //---trade part---
        
    }
}
