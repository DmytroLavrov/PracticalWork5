using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdTask
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            int[] array = { 9, 5, 7, 2, 1, 8, 6, 3, 4 };

            Console.WriteLine("Масив до сортування:");
            PrintArray(array);

            QuickSort(array);

            Console.WriteLine("Масив після сортування:");
            PrintArray(array);

            Console.WriteLine("Щоб вийти з програми, нажміть ENTER!");
            Console.ReadLine();
        }

        static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                Thread leftThread = new Thread(() => QuickSort(array, left, pivotIndex - 1));
                Thread rightThread = new Thread(() => QuickSort(array, pivotIndex + 1, right));

                leftThread.Start();
                rightThread.Start();

                leftThread.Join();
                rightThread.Join();
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
