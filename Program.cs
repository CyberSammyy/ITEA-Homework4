using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEA_Homework4
{
    class Program
    {
        //static int[,] MatrixMultiplier(int[,] matrix)
        //{
        //
        //}
        static void Show(int[,] matrix)
        {
            int size_i = matrix.GetLength(0);
            int size_j = matrix.GetLength(1);
            for (int k = 0; k < size_i; k++)
            {
                Console.WriteLine(new string('-', size_j * 8 + 1));
                Console.Write("|");
                for (int p = 0; p < size_j; p++)
                {
                    Console.Write("{0}\t|",matrix[k, p]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', size_j * 8 + 1));
        }
        static int[,] MatrixTransposing(int[,] matrix)
        {
            int[,] matrix_transposed = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix_transposed[i, j] = matrix[j, i];
                }
            }
            return matrix_transposed;
        }
        static int[,] MatrixToPower(int[,] matrix)
        {
            int power = 1;
            Console.WriteLine("Enter power:");
            while (!int.TryParse(Console.ReadLine(), out power))
            {
                Console.WriteLine("Incorrect input.");
            }
            matrix = MatrixByMatrixMultiplication(matrix, power);
            return matrix;
        }
        static int[,] MatrixAddition(int[,] matrix_1)
        {
            Console.WriteLine("Second matrix:");
            int[,] matrix_2 = MatrixFiller();
            if ((matrix_1.GetLength(0) != matrix_2.GetLength(0)) || (matrix_1.GetLength(1) != matrix_2.GetLength(1)))
            {
                Console.WriteLine("Can not add. Restart the program.");
                return new int[0, 0];
            }
            int[,] matrix_3 = new int[matrix_1.GetLength(0), matrix_1.GetLength(1)];
            for (int row = 0; row < matrix_1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix_1.GetLength(1); col++)
                {
                    matrix_3[row, col] = matrix_1[row, col] + matrix_2[row, col];
                }
            }
            return matrix_3;
        }
        static int[,] MatrixByNumberMultiplication(int[,] matrix)
        {
            int number = 0;
            Console.WriteLine("Enter number to multiply the matrix:");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Incorrect input.");
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= number;
                }
            }
            return matrix;
        }
        static int[,] MatrixByMatrixMultiplication(int[,] matrix_1, int power = 0)
        {
            int[,] matrix_2;
            if (power == 0)
            {
                Console.WriteLine("Second Matrix:");
                matrix_2 = MatrixFiller();
            }
            else
            {
                matrix_2 = matrix_1;
            }
            power++;
            if (matrix_1.GetLength(1) != matrix_2.GetLength(0))
            {
                Console.WriteLine("Can not multiply. Restart the program");
                return new int[0, 0];
            }

            var matrix_3 = new int[matrix_1.GetLength(0), matrix_2.GetLength(1)];
            for (int e = 0; e < power; e++)
            {
                for (var i = 0; i < matrix_1.GetLength(0); i++)
                {
                    for (var j = 0; j < matrix_2.GetLength(1); j++)
                    {
                        matrix_3[i, j] = 0;

                        for (var k = 0; k < matrix_1.GetLength(1); k++)
                        {
                            matrix_3[i, j] += matrix_1[i, k] * matrix_2[k, j];
                        }
                    }
                }
            }

            return matrix_3;
        }
        static int[,] MatrixFiller()
        {
            int size_i = 0;
            int size_j = 0;
            Console.WriteLine("Enter first size of matrix:");
            while (!int.TryParse(Console.ReadLine(), out size_i))
            {
                Console.WriteLine("Try again (1 size)");
            }
            Console.WriteLine("Enter second size of matrix:");
            while (!int.TryParse(Console.ReadLine(), out size_j))
            {
                Console.WriteLine("Try again (2 size)");
            }
            if(size_j == 0)
            {
                size_j = size_i;
            }
            int[,] matrix = new int[size_i, size_j];
            char[,] matrix_char = new char[size_i, size_j];
            for(int i = 0; i < size_i; i++)
            {
                for(int j = 0; j < size_j; j++)
                {
                    matrix_char[i, j] = '*';
                }
            }
            for (int i = 0; i < size_i; i++)
            {
                for (int j = 0; j < size_j; j++)
                {
                    while (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("Try again.");
                    }
                    Console.Clear();
                    for (int k = 0; k < size_i; k++)
                    {
                        Console.WriteLine(new string('-', size_j * 8 + 1));
                        Console.Write("|");
                        for (int p = 0; p < size_j; p++)
                        {
                            if (k <= i && p <= j)
                            {
                                Console.Write("{0}\t|", matrix[k, p]);
                            }
                            else
                            {
                                Console.Write("*\t|");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string('-', size_j * 8 + 1));
                }
            }
            Console.Clear();
            return matrix;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("First matrix:");
            int[,] matrix_1 = MatrixFiller();
            Show(MatrixByMatrixMultiplication(matrix_1));
            Show(MatrixByNumberMultiplication(matrix_1));
            Show(MatrixAddition(matrix_1));
            Show(MatrixToPower(matrix_1));
            Show(MatrixTransposing(matrix_1));
        }
    }
}
