using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intefaces_pract
{
    internal class Drone : IFlyable
    {
        public double x0; public double y0; public double z0;
        public static double speed = 20; //km/h
        static double maxdistance = 1000; //km
        public Drone(double x0, double y0, double z0) 
        {
            this.x0 = x0;
            this.y0 = y0;
            this.z0 = z0;
            Console.WriteLine($"Drone created at {x0}, {y0}, {z0}");
        }
        public void FlyTo(double x, double y, double z)
        {
            double distance = Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2));
            if (distance > maxdistance)
            {
                Console.WriteLine($"Drone cant fly to this point: distance above 1000km ({distance} km)");
            }
            else
            {
                x0 = x;
                y0 = y;
                z0 = z;
                Console.WriteLine($"Drone flying to {x0}, {y0}, {z0}");
            }
        }
    }
}
