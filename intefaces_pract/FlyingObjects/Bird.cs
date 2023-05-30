using Intefaces_Pract;

namespace intefaces_pract.FlyingObjects
{
    public class Bird : IFlyable
    {
        public int speed = new Random().Next(20) + 1;   //+1 to avoid speed = 0. max speed = 19+1
        public Coordinate currentCoordinate;

        public Bird(Coordinate initialCoordinate)
        {
            currentCoordinate = initialCoordinate;
        }

        public Coordinate FlyTo(Coordinate newCoordinate)    //restriction added: max distance = 50, max height = 5
        {
            double distance = GetDistanceTo(newCoordinate);

            if (distance > 50 || newCoordinate.z > 5)
            {
                Console.WriteLine("Bird can't fly to new coordinate: distance > 50km or height > 5km");
            }
            else
            {
                currentCoordinate = newCoordinate;
                Console.WriteLine($"Bird is flying to {currentCoordinate.x}, {currentCoordinate.y}, {currentCoordinate.z}");
            }

            return currentCoordinate;
        }

        public double GetFlyTime(Coordinate newCoordinate)
        {
            double distance = GetDistanceTo(newCoordinate);

            if (distance > 50)
            {
                Console.WriteLine("Error: distance > 50km");
                return 0;
            }
            else
            {
                double time = distance / speed;
                return time;
            }
        }

        private double GetDistanceTo(Coordinate newCoordinate)     //calculating distance from initialCoordinate
        {
            double distance = Math.Sqrt(Math.Pow(newCoordinate.x - currentCoordinate.x, 2) +
                Math.Pow(newCoordinate.y - currentCoordinate.y, 2));    //km
            return distance;
        }

        public void Print()
        {
            Console.WriteLine($"Bird current coordinate: {currentCoordinate.x}, {currentCoordinate.y}, " +
                $"{currentCoordinate.z}");
        }
    }
}