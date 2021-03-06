﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Nancy.Caching;
using Dapper;
using Newtonsoft.Json;

namespace Nancy.Caching.SQLite
{
    class CachingRepository : ICachingRepository,IDisposable
    {
        private IDbConnection conn = null;

        private string databse = string.Empty;

        private int expireTime = 30;

        public CachingRepository(string fileName)
        {
            this.databse = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Database",
                fileName
            );

            var directory = Path.GetDirectoryName(databse);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            this.conn = new SQLiteConnection(string.Format("Data Source={0};Version=3;New=False;Compress=True;Journal Mode=Off;", this.databse),true);
            conn.Open();
            conn.Execute(@"CREATE TABLE IF NOT EXISTS [tbCaching]
                        (
                            [ID] INTEGER PRIMARY KEY Autoincrement,
                            [ItemKey] VARCHAR(50) NOT NULL,
                            [ItemValue] VARCHAR(500),
                            [CreateTime] TEXT
                        )"
            );
        }

        public void Dispose()
        {
            this.conn.Close();
            this.conn.Dispose();
        }

        public T GetKey<T>(string key) where T : class
        {
            if (!File.Exists(this.databse)) return null;
            var entry = conn.Query<CachingModel>(
                "SELECT [ID], [ItemKey], [ItemValue], [CreateTime] FROM [tbCaching] WHERE [ItemKey] = @key", new { key }
            ).FirstOrDefault();
            if (entry == null) return null;
            var expire = entry.CreateTime + TimeSpan.FromMinutes(expireTime);
            if (DateTime.Now > expire)
            {
                conn.Execute(@"DELETE FROM [tbCaching] WHERE [ItemKey] = @key", new { key });
                return null;
            }

            return entry.ItemValue as T;
        }

        public void SetKey<T>(string key, T value) where T : class
        {
            if (!File.Exists(this.databse)) return;
            var json = JsonConvert.SerializeObject(value);
            var time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            var entry = conn.QueryFirstOrDefault<CachingModel>(
                @"SELECT [ItemKey], [ItemValue], [CreateTime] 
                FROM [tbCaching] 
                WHERE [ItemKey] = @key", new { key }
            );

            if(entry == null)
            {
                conn.Execute(
                     @"Insert INTO TBCaching(ItemKey,ItemValue,CreateTime) Values(@key,@json,@time)",
                    new { key, json }
                );
            }
            else
            {
                var expire = entry.CreateTime + TimeSpan.FromMilliseconds(expireTime);
                if (DateTime.Now < expire) return;
                conn.Execute(@"UPDATE [tbCaching] SET [ItemValue] = @json, [CreateTime] = @time WHERE [ItemKey] = @key", new { json,time,key });
            }
        }
    }
}
