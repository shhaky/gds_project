using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;

namespace ChangeableDataBase
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CCDB : ICDB
    {
        private MySqlConnection connectionInCDB;
        public CCDB()
        {
            String connectionInfoInCDB = "server=athena01.fhict.local;" +//server address
                                                 "database=dbi258753;" + // your database name
                                                 "user id=dbi258753;" + // your user id
                                                 "password=0qt8pIMNMq;" + // your password
                                                 "connect timeout=30;";
            connectionInCDB = new MySqlConnection(connectionInfoInCDB);
        }

        //---useful method---
        public long getLastestExistedUserId()
        {
            string sql = "SELECT max(UserId) FROM users";
            MySqlCommand command = new MySqlCommand(sql, connectionInCDB);
            long tempUserId;
            try
            {
                connectionInCDB.Open();
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
                connectionInCDB.Close();
            }
            return 0;
        }

        //---register part---
        public void registerAsUser(long userId, string passWord, string eMail, string lastLoginTime)
        {
            string sql = "INSERT INTO users (UserId, PassWord, Email, LastLoginTime) VALUES('" + userId + "','" + passWord + "','" + eMail + "','" + lastLoginTime  + "')";
            MySqlCommand com = new MySqlCommand(sql, connectionInCDB);
            connectionInCDB.Open();
            com.ExecuteNonQuery();
            connectionInCDB.Close();
        }
        //---login part---
        public string showPassWord(long userId)
        {
            string sql = "SELECT PassWord FROM users WHERE UserId ='" + userId + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInCDB);
            string tempPassWord;
            try
            {
                connectionInCDB.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempPass;
                while (reader.Read())
                {
                    tempPass = Convert.ToString(reader["PassWord"]);
                    tempPassWord = tempPass;
                    return tempPassWord;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connectionInCDB.Close();
            }
            return null;
        }

        //---account management---
        public string showEmail(long userId)
        {
            string sql = "SELECT Email FROM users WHERE UserId ='" + userId + "';";
            MySqlCommand command = new MySqlCommand(sql, connectionInCDB);
            string tempUserEmail;
            try
            {
                connectionInCDB.Open();
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
                connectionInCDB.Close();
            }
            return null;
        }

        public bool changePass(long userId, string newPass)
        {
            string sql = "UPDATE users SET PassWord = '" + newPass + "' WHERE UserId = '" + userId + "'";
            MySqlCommand com = new MySqlCommand(sql, connectionInCDB);
            connectionInCDB.Open();
            com.ExecuteNonQuery();
            connectionInCDB.Close();
            return true;
        }
        public void updateLoginTime(long userId, string loginTime)
        {
            string sql = "UPDATE users SET LastLoginTime = '" + loginTime + "' WHERE UserId = '" + userId + "'";
            MySqlCommand com = new MySqlCommand(sql, connectionInCDB);
            connectionInCDB.Open();
            com.ExecuteNonQuery();
            connectionInCDB.Close();
        }

        public bool checkAddress(long add)
        {
            string sql = "SELECT Address FROM coins WHERE Address ='" + add + "';";
            MySqlCommand com = new MySqlCommand(sql, connectionInCDB);
            try
            {
                connectionInCDB.Open();
                MySqlDataReader reader = com.ExecuteReader();
                string tempAdd;
                while (reader.Read())
                {
                    tempAdd = Convert.ToString(reader["UserName"]);
                    if (tempAdd != null)
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
                connectionInCDB.Close();
            }
            return false;
        }
     //---transaction part---

        //---trade part---
    }
}
