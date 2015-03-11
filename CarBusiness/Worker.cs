// Author: Luke Selbeck
// Date: 3/11/2015
// Description:
// 
// The class that does things in the car business.  The worker uses the worker
// number it is assigned to request a car from the car factory, and then print
// out a confirmation message.  After each cycle, it checks to see if there has
// been a request to stop working.  If so, it stops.

using System;
using System.Threading;

namespace CarBusiness
{
    public class Worker
    {
        private volatile bool stop;
        private int workerNum;
        private Object myLock;
        private CarFactory plant;

        public Worker(int workerNum, CarFactory plant)
        {
            stop = false;
            this.workerNum = workerNum;
            myLock = new Object();
            this.plant = plant;
        }

        public void run() //apparently threads in c# don't like parameters
        {
            doJob(plant);
        }

        private void doJob(CarFactory plant)
        {
            Car newCar;
            Console.WriteLine("Worker " + workerNum + " signing in");
            Thread.Sleep(1000);
            while (!stop) //main loop for running
            {
                newCar = plant.create(workerNum); //make cars!
                Console.WriteLine(newCar.message());

                //to vary sleep times between threads
                Thread.Sleep(1000 + workerNum*500);
            }
            Console.WriteLine("Worker " + workerNum + " signing off");
        }

        public void stopWorker() //takes the thread out of the main while loop
        {
            lock (myLock) //locked to prevent possible threading conflicts
            {
                stop = true;
            }
        }
    }
}