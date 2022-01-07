using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace home14_2
{
    class Product
    {
        public Product(string name, double cost, double weight, DateTime dateExpire, int amount, int discount = 0)
           : this(name, cost, weight)
        {
            this.discount = discount;
            this.DataExpire = dateExpire;
            this.amount = amount;

        }
        public override string ToString()
        {
            return "class Product: name = " + name + ", cost = " + cost + ", weight= " + weight +
                ", discount = " + discount + ", DataExpire = " + DataExpire + ", amount = " + amount + "\n\n";
        }
        public Product(string name, double cost, double weight)
        {
            this.name = name;
            this.cost = cost;
            this.weight = weight;

        }
        int discount;
        public DateTime DataExpire;
        
        public string name;
        protected double cost;
        public int amount;
        public double weight;
        public static Product Create(IDataRecord data)
        {
            return new Product(data["Name"].ToString(), double.Parse(data["Cost"].ToString()),
              double.Parse(data["Weight"].ToString()), DateTime.Parse(data["DateExpire"].ToString()), int.Parse(data["Amount"].ToString()), int.Parse(data["Discount"].ToString()));
        }

    }
}
