using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace LatihanXamarin.DAL
{
    public class DataAccess
    {
        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlConn;
            var dbName = "sampledb.db3";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
            sqlConn = new SQLiteConnection(dbPath);
            return sqlConn;
        } 
    }
}
