using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebAPI_Test.Models;

namespace WebAPI_Test.Services
{
    public class SqlDataAccess
    {
        private string _connectionString = "";

        public SqlDataAccess()
        {
            _connectionString = "Server=" + @"10.14.162.74" + "; " +
                    "DataBase=" + "TechAppLauncher_Testing" + "; " +
                    "user id=" + "techapplauncher" + ";" +
                    "password=" + "SZ@ADout05042021";
        }

        public List<UserDownloadSession> GetUserDownloadSessions()
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM UserDownloadSession ORDER BY InstallTimeStamp DESC";

            List<UserDownloadSession> userDownloadSessions = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                //_qrycmd.ExecuteNonQuery();

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    userDownloadSessions = new List<UserDownloadSession>();

                    while (Reader.Read())
                    {
                        userDownloadSessions.Add(new UserDownloadSession
                        {
                            Id = Reader.GetInt64(0),
                            AppId = Reader.IsDBNull(1) ? 0 : Reader.GetInt64(1),
                            AppUID = Reader.GetString(2),
                            Title = Reader.IsDBNull(3) ? "" : Reader.GetString(3),
                            Status = Reader.IsDBNull(4) ? "" : Reader.GetString(4),
                            UserName = Reader.GetString(5),
                            InstallTimeStamp = Reader.GetDateTime(6),
                            Remark = Reader.IsDBNull(7) ? "" : Reader.GetString(7)
                        });
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return userDownloadSessions;
        }

        public List<UserDownloadSession> AddUserDownloadSession(UserDownloadSession userDownloadSession)
        {
            int _ret = 0;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "INSERT INTO UserDownloadSession VALUES (@AppId, @AppUID, @Title, @Status, @UserName, @InstallTimeStamp, @Remark)";

            List<UserDownloadSession> userDownloadSessions = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppId", userDownloadSession.AppId);
                _qrycmd.Parameters.AddWithValue("@AppUID", userDownloadSession.AppUID);
                _qrycmd.Parameters.AddWithValue("@Title", userDownloadSession.Title);
                _qrycmd.Parameters.AddWithValue("@Status", userDownloadSession.Status);
                _qrycmd.Parameters.AddWithValue("@UserName", userDownloadSession.UserName);
                _qrycmd.Parameters.AddWithValue("@InstallTimeStamp", userDownloadSession.InstallTimeStamp);
                _qrycmd.Parameters.AddWithValue("@Remark", userDownloadSession.Remark);
                //_qrycmd.ExecuteNonQuery();

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    userDownloadSessions = GetUserDownloadSessions();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return userDownloadSessions;
        }

    }
}