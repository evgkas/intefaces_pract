using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//самолет увеличивает скорость на 10 км/ч каждые 10 км полета от начальной скорости 200 км/ч.,

namespace intefaces_pract
{
    public class Airplane : IFlyable
    {
        static int speed0 = 200; //starting speed
        static int maxspeed = 1000; 
        //current position
        public double x0;
        public double y0;
        public double z0;       
        public Airplane(double x0, double y0) 
        {
            this.x0 = x0;
            this.y0 = y0;
            z0 = 0;
        }
        
        public void FlyTo(double x, double y) 
        {
            Console.WriteLine($"Airplane is Flying from {x0}, {y0} to {x}, {y}");
            x0 = x;
            y0 = y;
            z0 = 0;
        }
        public double GetFlyTime (double x, double y) //calculating but not flying. speed increasing linear not discret
        {
            double S = Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y-y0), 2)); //distance in km
            double S2 = 0; double S1 = 0;
            double speed = speed0 + S; //maximum speed during flight km/h
            if (speed > maxspeed)
            {
                speed = maxspeed;
                S1 = speed - speed0; //1st part of way with increasing of speed
                S2 = S - S1; //flying on maxspeed
            }
            double time1 = S1 / ((speed0 + speed) / 2);
            double time2 = S2 / speed; //flying on maxspeed 
            double time = time1 + time2; //hours
            Console.WriteLine($"Flying to new point in {time} hours");
            return time;
        }
        //самолет набирает высоту 20 минут speed = 10*3 = 30 km/h or 0.5 km/min
        public double IGetHeight(double FlightTime, double CurrentTime) //time in minutes
        {
            //airplane flying from point A to point B in FlightTime minutes. Getting height (coordinate z) of airplane
            //in CurrentTime minutes after starting a flight
            //airplane flying up first 20 minutes to 10 km and flying down last 20 minutes
            double height = 0;
            double timedown = FlightTime - 20; //minutes
            switch (FlightTime)
            {
                case (< 20):
                {
                        height = 0.5 * CurrentTime;                        
                        break;
                }
                case (> 20) when CurrentTime < (FlightTime - 20):
                {
                        height = 10000;
                        break;
                }
                case (> 20) when (FlightTime - CurrentTime) < 20:
                    {
                        height = 0.5 * (FlightTime - CurrentTime);
                        break;
                    }
            }
            if (CurrentTime >= FlightTime) Console.WriteLine("Уже прилетели. Высота = 0");
            else Console.WriteLine($"Самолет сейчас на высоте {height} км");
            return height;
        }
    }
}
