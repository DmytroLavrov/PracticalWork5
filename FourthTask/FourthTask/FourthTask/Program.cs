using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace FourthTask
{
    class Program
    {
        static int[,] matrixA = {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9}
    };

        static int[,] matrixB = {
        {10, 11, 12},
        {13, 14, 15},
        {16, 17, 18}
    };

        static int[,] resultMatrix;
        static int matrixSize = matrixA.GetLength(0);
        static int threadsCompleted = 0;
        static object lockObject = new object();
        static Semaphore semaphore = new Semaphore(2, 2);

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            resultMatrix = new int[matrixSize, matrixSize];

            // Створення та запуск потоків
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    int row = i;
                    int column = j;
                    Thread thread = new Thread(() => MultiplyElements(row, column));
                    thread.Start();
                }
            }

            // Очікування завершення всіх потоків
            while (threadsCompleted < matrixSize * matrixSize)
            {
                Thread.Sleep(100);
            }

            // Друк результату
            Console.WriteLine("Результат множення матриць:");
            PrintMatrix(resultMatrix);

            Console.WriteLine("Щоб вийти з програми, нажміть ENTER!");
            Console.ReadLine();
        }

        static void MultiplyElements(int row, int column)
        {
            semaphore.WaitOne();

            int sum = 0;
            for (int k = 0; k < matrixSize; k++)
            {
                sum += matrixA[row, k] * matrixB[k, column];
            }

            lock (lockObject)
            {
                resultMatrix[row, column] = sum;
                threadsCompleted++;
            }

            semaphore.Release();
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}