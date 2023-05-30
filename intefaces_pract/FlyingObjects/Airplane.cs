using Intefaces_Pract;

namespace intefaces_pract.FlyingObjects
{
    public class Airplane : IFlyable
    {
        public double speed;    //current speed
        public static double initialSpeed = 200;
        public static double maxSpeed = 1000;
        public Coordinate currentCoordinate;

        public Airplane(Coordinate initialCoordinate)
        {
            currentCoordinate = initialCoordinate;
            speed = initialSpeed;
        }

        public Coordinate FlyTo(Coordinate newCoordinate)
        {
            if (newCoordinate.z <= 10)
            {
                double distance = GetDistanceTo(newCoordinate);
                speed += distance / 10 * 10;    //speed increasing linear

                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }

                currentCoordinate = newCoordinate;

                if (currentCoordinate.z == 0)
                {
                    speed = initialSpeed;   //if airplane landed (z == 0) next flyight will start from initialSpeed    
                }
            }
            else
            {
                Console.WriteLine("Error: Airplane can't fly above 10km");    //added restriction: max height for airplane = 10km
            }

            return currentCoordinate;
        }

        public double GetFlyTime(Coordinate newCoordinate)
        {
            /*speed increasing linear. after using this method coordinates will not be changed
            restrictions: airplane stops for 1hr to refuel every 10 000km */
            double distance = GetDistanceTo(newCoordinate);
            double distanceWithAcceleration = (maxSpeed - speed) / 10 * 10;    //speed increasing on 10km/h every 10km

            if (distance > distanceWithAcceleration)
            {
                double timeWithAcceleration = 0;

                if (maxSpeed != speed)   //to avoid error when airplane starts from maxSpped
                {
                    timeWithAcceleration = distanceWithAcceleration / ((maxSpeed - speed) / 2);
                }

                double distanceOnMaxSpeed = distance - distanceWithAcceleration;
                double timeOnMaxSpeed = distanceOnMaxSpeed / maxSpeed;
                double flyTime = timeWithAcceleration + timeOnMaxSpeed;

                if (distance > 10000)
                {
                    int refuelTime = (int)distance / 10000;
                    flyTime += refuelTime;
                    Console.WriteLine($"Extra {refuelTime} to refuel");
                }

                return flyTime;
            }
            else
            {
                double maxSpeedDuringFlight = distance / 10 * 10 + speed;
                double flyTime = distance / ((maxSpeedDuringFlight + speed) / 2);
                return flyTime;
            }
        }

        private double GetDistanceTo(Coordinate newCoordinate)    //calculating distance from initialCoordinate
        {
            double distance = Math.Sqrt(Math.Pow(newCoordinate.x - currentCoordinate.x, 2) +
                Math.Pow(newCoordinate.y - currentCoordinate.y, 2));    //km
            return distance;
        }

        public void Print()
        {
            Console.WriteLine($"Airplane current coordinate: {currentCoordinate.x}, {currentCoordinate.y}, " +
                $"{currentCoordinate.z}. Current speed = {speed}");
        }
    }
}
