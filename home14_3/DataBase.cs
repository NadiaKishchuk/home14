using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data;


namespace home14_2
{
    class DataBase
    {
        public SqliteConnection connection;

        public DataBase(in string connectionString)
        {
            connection = new SqliteConnection(connectionString);
            connection.Open();
        }

        public void executeSQLite(string sqlCommand)
        {
            using (connection)
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlCommand, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        //------------------------

        public List<T> GetList<T>(string sqlCommand, Func<IDataRecord, T> creator)
        {
            connection.Open();
            var list = new List<T>();
            SqliteCommand command = new SqliteCommand(sqlCommand, connection);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(creator(reader));
                }
            }
            return list;
        }
    }

    static class DataBaseExtensions
    {
        public static List<Product> GetProducts(this DataBase dataBase)
        {
            return dataBase.GetList("SELECT * from Products", Product.Create);
        }
        public static Product GetProductByNameLinq(this DataBase dataBase,string name)
        {
            return dataBase.GetProducts().Where(x => x.name == name).FirstOrDefault();
        }
        public static Product GetProductByNameDB(this DataBase dataBase, string name)
        {
            return dataBase.GetList($"SELECT * from Products WHERE Name like '{name}'", Product.Create).FirstOrDefault();
        }

    }
     
}
