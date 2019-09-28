using System;
using _14_09_19_part2;


namespace Lesson3
{
    class Program
    {
        public static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;

        }
        public static void PrintIntArray(int[] a)
        {
            //int[] a = new int[6] { 5, 7, 3, 7, 8, 3 };

            foreach (int x in a)
            {
                Console.Write(x + ", ");// x is a element value not index
            }
            Console.Write('\n');
        }

        public static int sumArrayElements(int[] collection)
        {
            int sum = 0;
            foreach (var item in collection)
            {
                sum = sum + item;
            }
            return sum;
        }

        public static int[] GenerateArray(int l)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int count = 0;
            int value = 0;
            int[] a = new int[l];

            while (count < l)
            {
                value = r.Next(1, 100);
                a[count] = value;
                count++;
            }

            Array.Sort(a);

            return a;    
        }

        public static int[] swapThePlace(int[] collection)
        {
            int length = collection.Length;
            int min = collection[0];
            int max = collection[0];
            int maxIndex = 0, minIndex = 0;
            for (int i = 0; i < length; i++)
            {
                if (collection[i] > max)
                {
                    max = collection[i];
                    maxIndex = i;
                }

                if (collection[i] < min)
                {
                    max = collection[i];
                    minIndex = i;
                }
            }
            Console.WriteLine("MIN is " + min + " and index IS " + minIndex); //task 6  
            Console.WriteLine("MAX is " + max + " and index IS " + maxIndex);
            collection[maxIndex] = min;
            collection[minIndex] = max;

            return collection;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- LESSON3 ---");
            int size = 10;
            int[] myArray1 = GenerateArray(size);
            Console.WriteLine("SOURCE:");
            PrintIntArray(myArray1);

            int evenCount = 0;
            int oddCount = 0;

            foreach (var item in myArray1)
            {
                if (item % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            int[] even = new int[evenCount];
            int[] odd = new int[oddCount];
            int x = 0;
            int y = 0;
            foreach (var item in myArray1)
            {
                if (item % 2 == 0)
                {
                    even[x] = item;
                    x++;
                }
                else
                {
                    odd[y] = item;
                    y++;
                }
            }
            Console.WriteLine("\nEVEN count: " + evenCount);
            Console.WriteLine("EVEN SUM: " + sumArrayElements(even));
            PrintIntArray(even);

            Console.WriteLine("\nODD count: " + oddCount);
            Console.WriteLine("ODD SUM: " + sumArrayElements(odd));
            PrintIntArray(odd);

            Console.WriteLine("\nAFTER TASK7:");
            PrintIntArray(swapThePlace(even));

            Console.WriteLine("\nAFTER TASK5:");

            if (even.Length > odd.Length)
            {
                int maxLength = even.Length;
            }
            else
            {
                int maxLength = odd.Length;
            }



        }
    }
}
