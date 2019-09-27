using System;

namespace HW2
{
    class HW2tasks
    {
        public static void Task1(int length = 99)
        {
            Console.WriteLine("\nTask1:");
            for (int i = 0; i < length; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static long Task2(int length = 5)
        {
            Console.WriteLine("\nTask2:");
            long n = 1;
            for (int i = 1; i <= length; i++)
            {
                n = n * i;
            }
            return n;
        }

        public static long Task3and4(int x = 2, int n = 2)
        {
            Console.WriteLine("\nTask3and4:");
            int i = 1;
            long result = x;
            while (i != n)
            {
                result = result * x;
                i++;
            }
            return result;
        }

        public static void Task5()
        {
            Console.WriteLine("\nTask5:");
            for (int i = 0, result = 0; i < 10; i++)
            {
                Console.Write('\n');
                Console.Write(result);
                result = result - 5;
            }
        }


        public static void Task6Triangle()
        {
            int lines = 6;
            Console.WriteLine("\nTask5:");

            for (int i = 0; i <= lines; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }
                Console.Write('\n');
            }
        }

        public static void Task6Triangle2(int lines = 7)
        {

            int space;

            for (int i = 1, k = 0; i <= lines; ++i, k = 0)
            {
                for (space = 1; space <= lines - i; ++space)
                {
                    Console.Write(' ');
                }
                while (k != 2 * i - 1)
                {
                    Console.Write('*');
                    ++k;
                }
                Console.Write('\n');
            }
        }

        public static void InvertTask6Triangle2(int lines = 7)
        {
            for (int i = lines; i >= 1; --i)
            {
                for (int space = 0; space < lines - i; ++space)
                {
                    Console.Write(' ');
                }
                    
                for (int j = i; j <= 2 * i - 1; ++j)
                {
                    Console.Write('*');
                }
                for (int j = 0; j < i - 1; ++j)
                {
                    Console.Write('*');
                }
                Console.Write('\n');
            }
        }
        public static void DrawRhombus(int lines = 7)
        {
            Task6Triangle2(lines);
            InvertTask6Triangle2(lines);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HW2tasks.Task1();
            Console.Write(HW2tasks.Task2(5));
            Console.Write(HW2tasks.Task3and4(5,6));
            HW2tasks.Task5();
            HW2tasks.Task6Triangle();
            Console.Write('\n');
            HW2tasks.Task6Triangle2();
            Console.Write('\n');
            HW2tasks.InvertTask6Triangle2();
            Console.Write('\n');
            HW2tasks.DrawRhombus();
            Console.Write('\n');
        }
    }
}
