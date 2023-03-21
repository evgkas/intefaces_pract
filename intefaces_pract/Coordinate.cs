namespace Intefaces_Pract
{
    public struct Coordinate
    {
        public double x { get; set; } = 0;
        public double y { get; set; } = 0;
        public double z { get; set; } = 0;
        public string name = "Undefined";


        public Coordinate()
        {

        }


        public Coordinate(string name, double x, double y)
        {
            this.x = x;
            this.y = y;
            if (String.IsNullOrEmpty(name)) this.name = "Undefined";
            else this.name = name;
        }


        public Coordinate(string name, double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            if (String.IsNullOrEmpty(name)) this.name = "Undefined";
            else this.name = name;
        }


        public Coordinate(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        public void Print()
        {
            Console.WriteLine($"Object {name}  x: {x}, y: {y}, z: {z}");
        }

    }
}
