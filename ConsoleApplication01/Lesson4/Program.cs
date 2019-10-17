using System;
using Lesson3;

namespace Lesson4
{
    public class MatrixHelpers
    {
        public static void PrintIntMatrix(int[][] sourceMatrix)
        {
            foreach (var line in sourceMatrix)
            {
                foreach (var col in line)
                {
                    Console.Write("{0} ", col);
                }
                Console.Write('\n');
            }
        }

        public static void PrintOddIntMatrix(int[][] sourceMatrix)
        {
            foreach (var line in sourceMatrix)
            {
                foreach (var col in line)
                {
                    if (col % 2 == 0)
                    {
                        Console.Write("{0} ", col);
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }
                Console.Write('\n');
            }
        }

        public static int[] GetLineScore(int[][] sourceMatrix)
        {

            int[] LineScore = new int[sourceMatrix.GetLength(0)];
            int x = 0;
            foreach (var line in sourceMatrix)
            {
                int sum = 0;
                foreach (var col in line)
                {
                    sum = sum + col;
                }
                LineScore[x] = sum;
                x++;
            }
            return LineScore;
        }

        //public static int[][] OrderByScore(int[][] sourceMatrix, int[] ScoreArray)
        //{
        //    int[][] reorderedMatrix = new int[sourceMatrix.GetLength(0)][];
        //    int max = 0;
        //    for (int i = 0; i < ScoreArray.GetLength(0); i++)
        //    {
        //        if (max> ScoreArray[i])
        //            {
        //                reorderedMatrix[i] = sourceMatrix
        //            }
        //    }


        //}

    }
    class Program
    {
        static void Main(string[] args)
        {
            int lineSize = 4;
            int colSize = 4;
            int[][] matrix = new int[lineSize][];
            for (int i = 0; i < colSize; i++)
            {
                int[] tempArray = LibArray.GenerateArray(colSize);
                matrix[i] = tempArray;
            }

            MatrixHelpers.PrintIntMatrix(matrix);
            MatrixHelpers.PrintOddIntMatrix(matrix);

            foreach (var item in MatrixHelpers.GetLineScore(matrix))
            {
                Console.WriteLine(item);
            }

            int var1 = 22;
            string var2 = "heeheh";
            Console.WriteLine($"This is text {var1} , {var2}");

        }
    }
}
