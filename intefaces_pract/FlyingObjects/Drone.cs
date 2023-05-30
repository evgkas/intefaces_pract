using Intefaces_Pract;

namespace intefaces_pract.FlyingObjects
{
    internal class Drone : IFlyable
    {
        public Coordinate currentCoordinate;
        public static double speed = 120;   //km/h
        public static double maxDistance = 1000;  //km
        public static double maxHeight = 2;

        public Drone(Coordinate initialCoordinate)
        {
            currentCoordinate = initialCoordinate;
            Console.WriteLine($"Drone created at {currentCoordinate.x}, {currentCoordinate.y}, {currentCoordinate.z}");
        }

        public Coordinate FlyTo(Coordinate newCoordinate)   //added restriction: drone can't fly above 2km
        {
            double distance = GetDistanceTo(newCoordinate);

            if (distance > maxDistance || newCoordinate.z > maxHeight)
            {
                Console.WriteLine($"Error: drone can't fly on distance > {maxDistance} km and on height > {maxHeight} km");
            }
            else
            {
                currentCoordinate = newCoordinate;
                Console.WriteLine($"Drone flying to {currentCoordinate.x}, {currentCoordinate.y}, {currentCoordinate.z}");
            }

            return currentCoordinate;
        }

        public double GetFlyTime(Coordinate newCoordinate)
        {
            double distance = GetDistanceTo(newCoordinate);

            if (distance > maxDistance)
            {
                Console.WriteLine($"Error: Maximum distance = {maxDistance} km (now {distance})");
                return 0;
            }
            else if (newCoordinate.z > maxHeight)
            {
                Console.WriteLine($"Error: Maximim height = {maxHeight} km (now {newCoordinate.z}");
                return 0;
            }
            else
            {
                double flyTime = 60 * (distance / speed);   //min
                int holdTime = (int)flyTime / 10;    //min
                double totalTime = (flyTime + holdTime) / 60;   //hours
                return totalTime;
            }
        }

        private double GetDistanceTo(Coordinate newCoordinate)     //calculating distance from initialCoordinate
        {
            double distance = Math.Sqrt(Math.Pow(newCoordinate.x - currentCoordinate.x, 2) +
                Math.Pow(newCoordinate.y - currentCoordinate.y, 2));  //km
            return distance;
        }

        public void Print()
        {
            Console.WriteLine($"Drone current coordinate: {currentCoordinate.x}, {currentCoordinate.y}, " +
                $"{currentCoordinate.z}");
        }
    }
}
