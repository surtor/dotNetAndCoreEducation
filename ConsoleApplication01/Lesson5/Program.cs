using System;

namespace Lesson5
{
    class Program
    {
        static void GetMax(Product[] store)
        {
            Product temp = store[0];
            foreach (var item in store)
            {
                if (item.Weight > temp.Weight)
                {
                    temp = item;
                }
            }
            Console.WriteLine("MAX");
            temp.PrintProduct();
        }

        static void GetMin(Product[] store)
        {
            Product temp = store[0];
            foreach (var item in store)
            {
                if (item.Weight < temp.Weight)
                {
                    temp = item;
                }
            }
            Console.WriteLine("MIN");
            temp.PrintProduct();
        }

        static double GetSum(Product[] store)
        {
            double sumPrice = 0;
            foreach (var item in store)
            {
                sumPrice = sumPrice + item.GetPrice();
            }
            return sumPrice;
        }

        static void Main(string[] args)
        {
            Currency.USD = 24.6;
            int length = 4;
            string[] Names = new string[]{ "Banana", "Coco", "Apple", "Orange" };

            Product Banana = new Product("Banana", "Fruits", 30.0, 1.0, 20);
            Product[] store = new Product[length];

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < length; i++)
            {
                store[i] = new Product(Names[i], "Fruits", rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100));
                store[i].PrintProduct();
            }

            GetMax(store);
            GetMin(store);
            Console.WriteLine("SUM :" + GetSum(store));
            Console.WriteLine(store[0].ToString()); 
        }
    }
}
