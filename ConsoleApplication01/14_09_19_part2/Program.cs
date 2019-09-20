using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_09_19_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1;
            int val2;
            Helpers.Print("This is Home Work day1. \nEnter two positive int values");

            while(true)
            {
                val1 = Helpers.EnterValue("Value 1:");
                val2 = Helpers.EnterValue("Value 2:");

                if (Math.Abs(val1) != val1 || val2 < -1) //Boolean1
                {
                    Helpers.Print("One or more values less than 1. \n Try again.", 2);
                }
                else
                {
                    if (DoSomeMath.EvenOrOdd(val1)) //Boolean2 and Boolean3
                    {
                        Helpers.Print(val1 + " is Even");
                    }
                    else
                    {
                        Helpers.Print(val1 + " is Odd");
                    }
                    break;
                }
            }

            Helpers.Print("Begin1. Perimeter: ");
            Helpers.Print("Val1:" + DoSomeMath.GetPerimeter(val1));
            Helpers.Print("Val1:" + DoSomeMath.GetPerimeter(val2));

            Helpers.Print("Begin2. Square: ");
            Helpers.Print("Val1:" + DoSomeMath.GetSquare(val1));
            Helpers.Print("Val1:" + DoSomeMath.GetSquare(val2));

            Helpers.Print("Begin3. Rectangle Square: ");
            Helpers.Print("Val1 and Val2:" + DoSomeMath.GetRectangleSquare(val1, val2));
            
            Helpers.Print("Begin4. Circle Length: ");
            Helpers.Print("Val1:" + DoSomeMath.GetLength(val1));
            Helpers.Print("Val2:" + DoSomeMath.GetLength(val2));

            Helpers.Print("Begin5. Cube Volume: ");
            Helpers.Print("Val1:" + DoSomeMath.GetCubeVolume(val1));
            Helpers.Print("Val2:" + DoSomeMath.GetCubeVolume(val2));

            Helpers.Print("Begin5. Cube Square: ");
            Helpers.Print("Val1:" + DoSomeMath.GetCubeSquare(val1));
            Helpers.Print("Val2:" + DoSomeMath.GetCubeSquare(val2));

            Helpers.Print("Begin12. GetHypotenuse: ");
            Helpers.Print("Hypotenuse:" + DoSomeMath.GetHypotenuse(val1, val2));
            Helpers.Print("Triangle P:" + DoSomeMath.GetTrianglePerimeter(val1, val2, DoSomeMath.GetHypotenuse(val1, val2)));

            Helpers.Print("Begin28. pow15: ");
            DoSomeMath.GetPow15((ulong)val1);

            
            if (val1 < 9 && val2 < 8 && val1 != 0 && val2 != 0)
            {
                Helpers.Print("Boolean34. Withe or black: ");
                if (DoSomeMath.Boolean34(val1, val2))
                {
                    Helpers.Print("Coordinates X = " + val1 + " Y = " + val2 + " is WITHE");
                }
                else
                {
                    Helpers.Print("Coordinates X = " + val1 + " Y = " + val2 + " is BLACK");
                }
                Helpers.Print("Boolean40. Horse MOVE: ");
                if (DoSomeMath.Boolean40(val1, val2, Helpers.EnterValue("Value 3:"), Helpers.EnterValue("Value 4:")))
                {
                    Helpers.Print("Move is VALID");
                }
                else
                {
                    Helpers.Print("Move is InVALID");
                }
            }
            else
            {
                Helpers.Print("One or more the numbers is bigger than 8 or equal 0", 2);
            }
        }
    }
}
