using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SecondTask
{
    using System;
    using System.Threading;

    class Program
    {
        private static object lockObject = new object();
        private static Semaphore semaphore = new Semaphore(2, 2);

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Thread trafficLight1Thread = new Thread(TrafficLight1);
            Thread trafficLight2Thread = new Thread(TrafficLight2);
            Thread trafficLight3Thread = new Thread(TrafficLight3);
            Thread trafficLight4Thread = new Thread(TrafficLight4);
            trafficLight1Thread.Start();
            trafficLight2Thread.Start();
            trafficLight3Thread.Start();
            trafficLight4Thread.Start();

            Console.ReadLine();

            trafficLight1Thread.Abort();
            trafficLight2Thread.Abort();
            trafficLight3Thread.Abort();
            trafficLight4Thread.Abort();

            Console.WriteLine("Щоб вийти з програми, нажміть ENTER!");
            Console.ReadLine();
        }

        static void TrafficLight1()
        {
            while (true)
            {
                lock (lockObject)
                {
                    Console.WriteLine("Світлофор 1: Зелене");
                    Thread.Sleep(5000);
                    Console.WriteLine("Світлофор 1: Жовте");
                    Thread.Sleep(2000);
                    Console.WriteLine("Світлофор 1: Червоне");
                }
                Thread.Sleep(1000);
            }
        }

        static void TrafficLight2()
        {
            while (true)
            {
                lock (lockObject)
                {
                    Console.WriteLine("Світлофор 2: Зелене");
                    Thread.Sleep(5000);
                    Console.WriteLine("Світлофор 2: Жовте");
                    Thread.Sleep(2000);
                    Console.WriteLine("Світлофор 2: Червоне");
                }
                Thread.Sleep(1000);
            }
        }

        static void TrafficLight3()
        {
            while (true)
            {
                lock (lockObject)
                {
                    Console.WriteLine("Світлофор 3: Зелене");
                    Thread.Sleep(5000);
                    Console.WriteLine("Світлофор 3: Жовте");
                    Thread.Sleep(2000);
                    Console.WriteLine("Світлофор 3: Червоне");
                }
                Thread.Sleep(1000);
            }
        }

        static void TrafficLight4()
        {
            while (true)
            {
                lock (lockObject)
                {
                    Console.WriteLine("Світлофор 4: Зелене");
                    Thread.Sleep(5000);
                    Console.WriteLine("Світлофор 4: Жовте");
                    Thread.Sleep(2000);
                    Console.WriteLine("Світлофор 4: Червоне");
                }
                Thread.Sleep(1000);
            }
        }
    }

}
