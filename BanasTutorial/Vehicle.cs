using System;
using System.Collections.Generic;
using System.Text;

namespace BanasTutorial
{
    class Vehicle : IDrivable
    {
        public int Wheels { get; set; }
        public int Speed { get; set; }
        public string Brand;

        public Vehicle(string brand = "no brand", int wheels = 0, int speed = 0)
        {
            Brand = brand;
            Wheels = wheels;
            Speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"The {Brand} moves forward at {Speed} mph on {Wheels} wheel(s)");
        }

        public void Stop()
        {
            Console.WriteLine($"The {Brand} stops");
            Speed = 0;
        }
    }
}
