// Author: Luke Selbeck
// Date: 3/11/2015
// Description:
// 
// Driver for the car business.  Executes a manager workday

namespace CarBusiness
{
    public class Driver
    {
        public static void Main()
        {
            int numWorkers = 5; //change as you like
            Manager luke = new Manager(numWorkers);
            luke.workday();
        }
    }
}