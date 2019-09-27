using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_09_19_part2
{
    static class Constants
    {
        public const double Pi = 3.14;
    }

    public static class Helpers
    {
        public static void Print(string msg, int errorlevel=1)
        {
            switch (errorlevel)
            {
                case 1: //INFO
                    Console.WriteLine('\n' + msg);
                    break;
                case 2: //WARNING
                    Console.WriteLine("\n[WARNING] " + msg);
                    break;
                case 3: //ERROR
                    Console.WriteLine("\n[ERROR] " + msg);
                    break;
                default:
                    Console.WriteLine("\n[ERROR] INCORECT PRINTERROR LEVEL");
                    break;
            }
            
        }
        public static void Print(string msg)
        {
            Console.WriteLine('\n' + msg);
        }

        public static int EnterValue(string hiMsg)
        {
            Helpers.Print(hiMsg);
            return int.Parse(Console.ReadLine());
        }
    }

    class DoSomeMath
    {
        //Math block
        public static int GetPerimeter(int value)
        {
            return value * 4; // 4 -> because ancient Greece said it
        }

        public static int GetSquare(int value)
        {
            return value * value; // Math.Pow(value, 2) - slide 25 
        }

        public static int GetRectangleSquare(int sideA, int sideB)
        {
            return sideA * sideB;
        }

        public static double GetRadius(int diameter)
        {
            //R = D / 2
            return diameter / 2;
        }

        public static double GetLength(int diameter)
        {
            //C = Pi * D
            return Constants.Pi * diameter;
        }

        public static int GetCubeVolume(int side)
        {
            //V = side^3
            return side * side * side;
        }

        public static int GetCubeSquare(int side) //Begin6
        {
            //S = 6 * side^2
            return 6 * (side * side);
        }

        public static double GetCircleSquare(int ridius) //Begin7
        {
            //S = Pi * R^2
            return Constants.Pi * (ridius * ridius);
        }

        public static double GetHypotenuse(int sideA, int sideB) //Begin12
        {
            //double c = ;
            return Math.Sqrt((double)(sideA * sideA) + (double)(sideB * sideB));
        }

        public static double GetTrianglePerimeter(int sideA, int sideB, double hypotenuse) //Begin12
        {
            return sideA + sideB + hypotenuse;
        }

        //Begin28
        public static void GetPow15(ulong value)
        {
            ulong pow2 = value * value; //pow2
            Console.WriteLine("Pow 2 = " + pow2);
            ulong cube = pow2 * value; //cube
            Console.WriteLine("Pow 3 = " + cube);
            value = pow2 * cube; //pow5
            Console.WriteLine("Pow 5 = " + value);
            pow2 = value * value;
            Console.WriteLine("Pow 10 = " + (pow2));
            Console.WriteLine("Pow 15 = " + (pow2 * value));
        }

        public static bool EvenOrOdd(int number)
        {
            double dres = (double)number / 2;
            int ires = (int)dres;
            if (dres == ires)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool Boolean34(int x, int y)
        {
            //true = withe
            //false = black
            if (!EvenOrOdd(y))
            {
                if (!EvenOrOdd(x))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (EvenOrOdd(x))
                {
                    return true;
                }
                return false;
            }
        }

        public static bool Boolean40(int x1, int y1, int x2, int y2)
        {

            if (Math.Abs(x1 - x2) == 2 && Math.Abs(y1 - y2) == 1)
            {
                return true;
            }
            if (Math.Abs(x1 - x2) == 1 && Math.Abs(y1 - y2) == 2)
            {
                return true;
            }
            return false;
        }
    }
}
