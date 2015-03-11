// Author: Luke Selbeck
// Date: 3/11/2015
// Description:
// 
// CarFactory uses a hash table to store types of cars, and returns a
// new instance of the requested car.  This eliminates the need for a
// switch statement to check for which car is being requested.
//
// Car types can be requested by index or by their first character.
// e.g. create('f') returns a Ford object
// e.g. create('a') returns an Audi object

namespace CarBusiness
{
    public class CarFactory
    {
        private const int childStoreSize = 5;
        private Car[] childStore;

        public CarFactory()
        {
            childStore = new Car[childStoreSize];
            childStore[0] = new Audi();
            childStore[1] = new Bently();
            childStore[2] = new Cadillac();
            childStore[3] = new Elio();
            childStore[4] = new Ford();
        }
        
        public Car create(int index)
        {
            return childStore[index % childStoreSize].create();
        }

        public Car create(char carChar)
        {
            int index = hash(carChar);
            return childStore[index % childStoreSize].create();
        }

        private int hash(char car) //only supports lowercase letters
        {
            return (car - 'a') % childStoreSize;
        }
    }
}