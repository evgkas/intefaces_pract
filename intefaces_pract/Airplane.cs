//самолет увеличивает скорость на 10 км/ч каждые 10 км полета от начальной скорости 200 км/ч.,
//need to make exceptions for negative coordinates

namespace Intefaces_Pract
{
    public class Airplane : IFlyable
    {
        static int speed0 = 200;    //initial speed
        static int maxspeed = 1000;
        public double x0 = 0;
        public double y0 = 0;
        public double z0 = 0;
        public string name = "Undefined";


        public Airplane() { }


        public Airplane(double x0, double y0)
        {
            if (x0 >= 0 && y0 >= 0)
            {
                this.x0 = x0;
                this.y0 = y0;
            }
            else Console.WriteLine("Coordinates must be positive. x, y set to 0, 0");
        }


        public Airplane(double x0, double y0, string name)
        {
            if (x0 > 0 && y0 > 0)
            {
                this.x0 = x0;
                this.y0 = y0;
            }
            else Console.WriteLine("Coordinates must be positive. x, y set to 0, 0");
            if (!String.IsNullOrEmpty(name)) this.name = name;
        }


        public void FlyTo(double x, double y)
        {
            //I dont think coordinate z is needed here
            if (x >= 0 && y >= 0)
            {
                Console.WriteLine($"Airplane is Flying from {x0}, {y0} to {x}, {y}");
                x0 = x;
                y0 = y;
                z0 = 0;
            }
            else Console.WriteLine("Point (x,y) should be positive");
        }


        public double GetFlyTime(double x, double y)
        {
            /*speed increasing linear (not dicret). after using this method coordinates will no be changed
            restrictions: plane flying up to 10 000 km in one flight and stops for 1hr to refuel every 10 000km */
            double S = Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2)); //distance in km
            double S2 = 0;
            double S1 = 0;
            double speed = speed0 + S;  //maximum speed during flight km/h

            if (speed > maxspeed)
            {
                speed = maxspeed;
                S1 = speed - speed0;    //1st part of way with increasing of speed !!!!!!!!!!!!!
                S2 = S - S1;    //flying on maxspeed
            }

            double time1 = S1 / ((speed0 + speed) / 2);
            double time2 = S2 / speed;  //flying on maxspeed 
            int refueltime = Convert.ToInt32(Math.Floor(S)) / 10000;    //time to refuel
            //math.floor for situation if distance for example 19 999.9km - only 1 stop to refuel needed
            double time = time1 + time2 + refueltime;   //hours
            Console.WriteLine($"Flying to new point in {time} hours");
            return time;
        }

                
        public double IGetHeight(double FlightTime, double CurrentTime) //time in minutes
        {
            /*in this method time calculating in minutes
            airplane flying from point A to point B in FlightTime minutes. Method return height (coordinate z) of 
            airplane in {CurrentTime} minutes after starting a flight.
            airplane flying up first 20 minutes to 10 km and flying down last 20 minutes
            cases when airplane have no time to get maximum height (FlightTime < 40) not calculated */
            double height = 0;
            double zspeed = 10 / 20;    //km/min
            switch (CurrentTime)
            {
                case (>0) when FlightTime < 40:
                    {
                        Console.WriteLine("Слишком маленькое расстояние для данного самолета");
                        break;
                    }
                case (< 20):
                    {
                        height = zspeed * CurrentTime;
                        break;
                    }
                case (> 20) when CurrentTime < (FlightTime - 20):
                    {
                        height = 10000;
                        break;
                    }
                case (> 20) when (FlightTime - CurrentTime) < 20:
                    {
                        height = zspeed * (FlightTime - CurrentTime);
                        break;
                    }
            }
            if (CurrentTime >= FlightTime) Console.WriteLine("Уже прилетели. Высота = 0");
            else Console.WriteLine($"Самолет сейчас на высоте {height} км");
            return height;
        }
    }
}
