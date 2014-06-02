using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GdsServerSide
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

        //=====================================add new user to database====================================
        public bool addNewUser(long userId, string userName, string passWord, string firstName, string lastName, string email, string joinDate)
        {
            string sql = "INSERT INTO user (UserId,UserName, PassWord, FirstName, LastName, Email, JoinDate) VALUES('" + userId + "','" + userName + "','" + passWord + "','" + firstName + "','" + lastName + "','" + email + "','" + joinDate + ","  + "')";
            MySqlCommand com = new MySqlCommand(sql, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        //===============================check if the password is matched to the username===================
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

        //=============================get user infomation====================================
        public long getUserId(string userName)
        {
            string sql = "SELECT UserId FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            long temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempId;
                while (reader.Read())
                {
                    tempId = Convert.ToString(reader["UserId"]);
                    temp = Convert.ToInt64(tempId);
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

        public string getPassWord(string userName)
        {
            string sql = "SELECT PassWord FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempPassword;
                while (reader.Read())
                {
                    tempPassword = Convert.ToString(reader["PassWord"]);
                    temp = tempPassword;
                    return temp;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public string getFirstName(string userName)
        {
            string sql = "SELECT FirstName FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempFN;
                while (reader.Read())
                {
                    tempFN = Convert.ToString(reader["FirstName"]);
                    temp = tempFN;
                    return temp;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public string getLastName(string userName)
        {
            string sql = "SELECT LastName FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempLN;
                while (reader.Read())
                {
                    tempLN = Convert.ToString(reader["LastName"]);
                    temp = tempLN;
                    return temp;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public string getEmail(string userName)
        {
            string sql = "SELECT Email FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempEmail;
                while (reader.Read())
                {
                    tempEmail = Convert.ToString(reader["Email"]);
                    temp = tempEmail;
                    return temp;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public string getJoinDate(string userName)
        {
            string sql = "SELECT JoinDate FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempJoinDate;
                while (reader.Read())
                {
                    tempJoinDate = Convert.ToString(reader["JoinDate"]);
                    temp = tempJoinDate;
                    return temp;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public string getLastLoginTime(string userName)
        {
            string sql = "SELECT LastLoginTime FROM user WHERE UserName ='" + userName + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempJoinDate;
                while (reader.Read())
                {
                    tempJoinDate = Convert.ToString(reader["LastLoginTime"]);
                    temp = tempJoinDate;
                    return temp;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public bool changePassword(string userName, string passWord)
        {
            string sql = "UPDATE user SET PassWord = '" + passWord + "' WHERE UserName = '" + userName + "'";
            MySqlCommand com = new MySqlCommand(sql, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        //=================================update last login time======================
        public void updateLoginTime(string userName, string time)
        {
            string sql = "UPDATE user SET LastLoginTime = '" + time + "' WHERE UserName = '" + userName + "'";
            MySqlCommand com = new MySqlCommand(sql, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
        }

        //=======================add new transaction=================================
        public bool addNewTransaction(long transId, long userId, string transTime, string transType, string coinType, decimal amount, long add)
        {
            string sql = "INSERT INTO transaction (TransId, UserId, TransTime, TransType, CoinType, Amount, Address) VALUES('" + transId + "','" + userId + "','" + transTime + "','" + transType + "','" + coinType + "','" + amount + "','" + add + "')";
            MySqlCommand com = new MySqlCommand(sql, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        //===================get the lastest existed transId in database===================
        public long getLastestExistedTransId()
        {
            string sql = "SELECT max(TransId) FROM transaction";
            MySqlCommand command = new MySqlCommand(sql, connection);
            long temp;
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string tempTransId;
                while (reader.Read())
                {
                    tempTransId = Convert.ToString(reader["max(TransId)"]);
                    temp = Convert.ToInt64(tempTransId);
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

        //===================get transaction history=======================================
        public List<string> getTransInfo(long userId)
        {
            string sql = "SELECT TransId,UserId,TransTime,TransType,CoinType,Amount,Address FROM transaction WHERE UserId ='" + userId + "';";
            List<string> infoList = new List<string>();
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            long tempId = userId;
            while (reader.Read())
            {
                if (tempId == Convert.ToInt64(reader["UserId"]))
                {
                    string info = "at " + Convert.ToString(reader["TransTime"]) +
                           " you " + Convert.ToString(reader["TransType"]) +
                           " " + Convert.ToString(reader["Amount"]) +
                           " " + Convert.ToString(reader["CoinType"]) +
                           "with " + Convert.ToString(reader["Address"]);
                    infoList.Add(info);
                }
            }
            connection.Close();

            return infoList;
        }

        //=====================balance=========================================================
        public decimal getBalance(long userId, string coinType)
        {
            string sql = "SELECT Balance FROM coins WHERE UserId ='" + userId + "AND CoinType=" + coinType + "';";
            MySqlCommand command = new MySqlCommand(sql, connection);
            decimal tempBalance = 0;
            try
            {
                connection.Open();
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
                connection.Close();
            }
            return tempBalance;
        }
    }
}
