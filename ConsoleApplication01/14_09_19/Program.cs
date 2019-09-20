using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_09_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            int x = 1;
            int y = 1;
            double z = (double)x / y;
            Console.WriteLine("z = " + z);
            bool isEqual = x == y;

            Console.WriteLine("res = " + isEqual);
            double x1 = 1;
            double y1 = 1;
            const double EPS = 0.001;
            bool isEqual2 = Math.Abs(x1-y1)< EPS;

        }
    }
}
