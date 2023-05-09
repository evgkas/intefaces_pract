namespace Intefaces_Pract
{
    public struct Coordinate
    {
        public double x = 0;
        public double y = 0;
        public double z = 0;
        public Coordinate() { }
        public Coordinate(double x, double y)
        {
            try
            {
                this.x = x;
                this.y = y;
                if ((x < 0) || (y < 0))
                {
                    throw new InitializationException("Coordinates must be positive. Coordinates set 0, 0, 0");
                }
            }
            catch (InitializationException) { }
        }
        public Coordinate(double x, double y, double z)
        {
            try
            {
                if ((x < 0) || (y < 0) || (z < 0))
                {
                    throw new InitializationException("Coordinates must be positive. Coordinates set 0, 0, 0");
                }
                this.x = x;
                this.y = y;
                this.z = z;
            }
            catch (InitializationException) { }
        }

        public void Print()
        {
            Console.WriteLine($"Object coordinates: x = {x}, y = {y}, z = {z}");
        }

        public override string ToString()
        {
            string coordinates = $"{x}, {y}, {z}";
            return coordinates;
        }
    }
}
