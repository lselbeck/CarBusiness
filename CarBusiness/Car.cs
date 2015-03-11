// Author: Luke Selbeck
// Date: 3/11/2015
// Description:
//
// Car contains all car related classes i.e. the Car parent class, and all
// the car types that inherit from Car.
//
// Car is an abstract class which cannot be instantiated.  It is used so that
// you can treat the different types as one object.
// e.g. Car myCar = new Audi();

using System;

namespace CarBusiness
{
    public abstract class Car
    {
        public abstract Car create();

        public virtual String message()
        {
            return "Vroom vroom, I'm a(n) ";
        }
    }

    public class Audi : Car
    {
        public override Car create()
        {
            return new Audi();
        }

        public override String message()
        {
            return base.message() + "Audi";
        }
    }

    public class Bently : Car
    {
        public override Car create()
        {
            return new Bently();
        }

        public override String message()
        {
            return base.message() + "Bently";
        }
    }

    public class Cadillac : Car
    {
        public override Car create()
        {
            return new Cadillac();
        }

        public override String message()
        {
            return base.message() + "Cadillac";
        }
    }

    public class Dodge : Car
    {
        public override Car create()
        {
            return new Dodge();
        }

        public override String message()
        {
            return base.message() + "Dodge";
        }
    }

    public class Elio : Car
    {
        public override Car create()
        {
            return new Elio();
        }

        public override String message()
        {
            return base.message() + "Elio";
        }
    }

    public class Ford : Car
    {
        public override Car create()
        {
            return new Ford();
        }

        public override String message()
        {
            return base.message() + "Ford";
        }
    }
}