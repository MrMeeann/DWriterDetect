﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWriterDetect
{
    internal class Database
    {
        private SQLiteConnection conn()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source = DWriter.db; Version = 3; New = True; Compress = True;");
            try
            {
                sqlite_conn.Open();
                return sqlite_conn;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public SQLiteDataReader readData(string tbName, string search = "1 = 1")
        {
			try
			{
				SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {tbName} WHERE {search}", conn());
				SQLiteDataReader reader = cmd.ExecuteReader();

				return reader;
			}
			catch (Exception)
			{
				return null;
			}
        }

		public bool addData(string tbName, string fields, string values)
		{
            try
            {
                SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO {tbName} ({fields}) VALUES ({values})", conn());
                cmd.ExecuteReader();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
