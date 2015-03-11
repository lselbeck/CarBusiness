// Author: Luke Selbeck
// Date: 3/11/2015
// Description:
// 
// A manager class that starts and ends a specified
// number of worker threads

using System;
using System.Threading;

namespace CarBusiness
{
    public class Manager
    {
        private Worker[] workers;
        private Thread[] workerThreads;
        private CarFactory plant;
        private int numWorkers;

        public Manager(int numWorkers)
        {
            workers = new Worker[numWorkers];
            workerThreads = new Thread[numWorkers];
            plant = new CarFactory();
            this.numWorkers = numWorkers;
        }

        public void workday()
        {
            Console.WriteLine("All aboard!");
            startWorkers();
            Thread.Sleep(10000);
            Console.WriteLine("Work day is over!");
            endWorkers();
            Console.WriteLine("All workers have left");
            Thread.Sleep(3000); //to stop console from immediately closing
        }

        private void startWorkers()
        {
            for (int i = 0; i < numWorkers; i++)
            {
                workers[i] = new Worker(i, plant);
                workerThreads[i] = new Thread(workers[i].run);
                workerThreads[i].Start();
            }
        }

        private void endWorkers()
        {
            for (int i = 0; i < numWorkers; i++) //ask them to stop
            {
                workers[i].stopWorker();
            }

            for (int i = 0; i < numWorkers; i++) //before trying to join
            {
                workerThreads[i].Join();
            }
        }
    }
}
