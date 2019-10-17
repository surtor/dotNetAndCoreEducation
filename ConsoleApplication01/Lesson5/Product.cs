using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class Product
    {
        private string name;
        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return name;
            }
        }

        private string type;
        private double price;
        private double weight; //we can delete this becouse we have set and get 
        public double Weight
        {
            set
            {
                this.weight = value;
            }
            get
            {
                return weight;
            }
        }
        private int count;

        public Product(string name = "Default", string type = "Default", double price = 0.0, double weight = 0.0, int count = 0)
        {
            Name = name;
            this.type = type;
            SetPrice(price); 
            Weight = weight;
            this.count = count;
        }

        public void SetPrice(double price)
        {
            this.price = price / Currency.USD;
        }

        public double GetPrice()
        {
            return this.price * 1.25;
        }

        public void PrintProduct()
        {
            Console.WriteLine("NAME: " + this.Name);
            Console.WriteLine("TYPE: " + this.type);
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine("PRICE: " + GetPrice());
            Console.WriteLine("Count: " + this.count);
            Console.WriteLine("=============");
        }

        public override string ToString()
        {
            return $"{Name}, {type}, {Weight}, {this.GetPrice()}";
        }

    }
}
