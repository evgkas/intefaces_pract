namespace Intefaces_Pract
{
    internal class Drone : IFlyable
    {
        public double x0; public double y0; public double z0;
        public static double speed = 120; //km/h
        static double maxdistance = 1000; //km
        static double maxheight = 2;
        static double flytime = 9 / 10; //9 min out of 10 drone flying, 1 min hold in the air


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
            if (distance > maxdistance || z > maxheight)
            {
                Console.WriteLine($"Drone cant fly to this point: distance above {maxdistance}km or height above " +
                    $"{maxheight}km");
            }
            else
            {
                x0 = x;
                y0 = y;
                z0 = z;
                Console.WriteLine($"Drone flying to {x0}, {y0}, {z0}");
            }
        }


        public double GetFlyTime(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2));
            if (distance > maxdistance)
            {
                Console.WriteLine($"Maximum distance = {maxdistance} km (now {distance})");
                return 0;
            }
            else
            {
                double time = distance / speed;
                double holdtime = time / flytime;
                double wholetime = time + holdtime;
                return wholetime;
            }
        }
    }
}
