using BuinyaModel;
using BuinyaModel.Attributes;
using BuinyaService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuinyaService
{
    public static class DbWork
    {
        private static string ConnectionString = $@"Data Source={
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["dbName"])
            };New=False;Version=3";

        public async static Task<List<T>> SelectTable<T>(string table) where T : new()
        {
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString))
            {
                string selectCommand = $"SELECT * FROM {table}";
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(selectCommand, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            return await MapDataToBusinessEntityCollection<T>(rdr);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Не удалось загрузить данные");
                }
            }

        }

        public static Task<List<T>> MapDataToBusinessEntityCollection<T>(IDataReader dr)
   where T : new()
        {
            Type type = typeof(T);
            List<T> result = new List<T>();
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                hashtable[info.Name.ToUpper()] = info;
            }
            while (dr.Read())
            {
                T newObject = new T();
                for (int index = 0; index < dr.FieldCount; index++)
                {
                    PropertyInfo info = (PropertyInfo)
                                        hashtable[dr.GetName(index).ToUpper()];
                    if ((info != null) && info.CanWrite)
                    {
                        info.SetValue(newObject, (dr.GetValue(index).GetType() == typeof(long)) ? Convert.ToInt32(dr.GetValue(index)) : dr.GetValue(index));
                    }
                }
                result.Add(newObject);
            }
            dr.Close();
            return Task.Run(()=>result);
        }
    }
}
