using System;
using System.Collections.Generic;
using System.Threading;

namespace FirstTask
{
    class Program
    {
        private static Queue<int> buffer = new Queue<int>();
        private static object lockObject = new object();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Thread producerThread = new Thread(Producer);
            Thread consumerThread = new Thread(Consumer);
            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();

            Console.WriteLine("Головний потік завершив роботу.");
            Console.ReadLine();
        }

        static void Producer()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Random random = new Random();

            while (true)
            {
                int number = random.Next(100);
                lock (lockObject)
                {
                    buffer.Enqueue(number);
                    Console.WriteLine($"Вироблено: {number}");
                    Monitor.Pulse(lockObject);
                }
                
                Thread.Sleep(random.Next(1000));
            }
        }

        static void Consumer()
        {
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.Default;
                int number;

                lock (lockObject)
                {
                    while (buffer.Count == 0)
                    {
                        Console.WriteLine("Споживач очікує...");
                        Monitor.Wait(lockObject);
                    }

                    number = buffer.Dequeue();
                }

                Console.WriteLine($"Спожито: {number}");

                Thread.Sleep(1000);
            }
        }
    }
}
