using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace home14_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase(@"Data Source=C:\Users\Надія\Desktop\Sigma c#\dataBases\Products.db;");
            try
            {
                foreach (Product product in dataBase.GetProducts())
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine(dataBase.GetProductByNameDB("Cheese"));
                Console.WriteLine(dataBase.GetProductByNameLinq("Cheese"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
