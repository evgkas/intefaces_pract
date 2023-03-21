namespace Intefaces_Pract
{
    public class Bird : IFlyable
    {

        public int speed = new Random().Next(20); //horizontal speed !!!!!!!!!!!
        public double x0 = 0;
        public double y0 = 0;
        public double z0 = 0;


        public Bird()
        {
            //speed = new Random().Next(20);
            Console.WriteLine($"Bird created in 0, 0, 0. Flying speed = {speed} km/h");
        }


        public Bird(double x0, double y0, double z0)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.z0 = z0;
            Console.WriteLine($"Bird created in {x0}, {y0}, {z0}. Flying speed is {speed} km/h");
            if (z0 > 5)
            {
                z0 = 5;
                Console.WriteLine("Bird cant fly on that height. z0 set to 5");
            }
        }


        public void FlyTo(double x, double y, double z)
        {
            double distance = Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2));
            if (distance > 50 || z > 5)
            {
                Console.WriteLine("Distance > 50km or height > 5km");
            }
            else
            {
                x0 = x;
                y0 = y;
                z0 = z;
                Console.WriteLine($"Bird is flying to {x}, {y}, {z}");
            }
        }


        public double GetFlyTime(double x, double y)
        {
            //In this metod bird flight from x0,y0 to x,y like bird flying on one low height 
            double distance = Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2)); //km
            double time = distance / speed; //hrs
            return time;
        }


        public double GetFlyTime(double x, double y, double z)
        {
            /*bird flying up with speed 20 m/min and down 60m/min (1200 and 3600 m/hr) and at same time bird flying
            horizontal {speed} km/h. So we calclulating horizontal time and vertical time and take bigger number*/
            double distance = Math.Sqrt(Math.Pow((x - x0), 2) + Math.Pow((y - y0), 2));
            double up_speed = 1.2; double down_speed = 3.6;
            double xtime = distance / speed; double ytime = 0;
            if (z > z0) ytime = (z - z0) * up_speed;
            else ytime = (z0 - z) * down_speed;

            if (xtime > ytime) return xtime;
            else return ytime;
        }
    }
}
