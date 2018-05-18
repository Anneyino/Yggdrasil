﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Yggdrasil.Model
{
    class DatabaseUtility
    {

        private static string connDatabase = "yggdrasil";
        private static string connHost = "www.irran.top";
        private static string connUser = "yggdrasil";
        private static string connPassword = "admin";
        private static string connStr = string.Format("Database={0};Data Source={1};User Id={2};Password={3}", connDatabase, connHost, connUser, connPassword);

        private static MySqlConnection openConn()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            }catch(MySqlException exp)
            {
                // cannot access the database, which means a possible failure in network connection
                Console.WriteLine(exp.Message);
                return null;
            }
            return conn;
        }

        public static int getUser(ref User user,String userName)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM user WHERE user_name='{0}'", userName);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            if (!read.Read())
                user = null;
            else
            {
                user.User_id = read.GetInt32("user_id");
                user.User_name = read.GetString("user_name");
                user.Passwd = read.GetString("passwd");
                user.Privilege = read.GetInt32("privilege");
                user.Nick_name = read.GetString("nick_name");
                user.Register_date = read.GetDateTime("register_date");

            }
            read.Close();
            return 1;   // 1 means everything is right
        }
    }
}