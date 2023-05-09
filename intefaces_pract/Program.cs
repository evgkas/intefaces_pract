using Intefaces_Pract;
class Program
{
    static void Main(string[] args)
    {
        Coordinate testCoordinate = new(1500, 0, 5);
        Coordinate zeroCoordinate = new();
        Coordinate negativeCoordinate = new(-1, 0, 0);
        negativeCoordinate.Print();

        Console.WriteLine("Airplane:");
        Airplane plane = new(zeroCoordinate);
        plane.FlyTo(new(20, 0, 1));
        Console.WriteLine(plane.speed);    //speed have to increase by 20km/h
        Console.WriteLine($"FlyTime to {testCoordinate.ToString()} = {plane.GetFlyTime(testCoordinate)}");
        plane.FlyTo(testCoordinate);
        plane.Print();
        Console.WriteLine($"FlyTime on 10500km = {plane.GetFlyTime(new(12000, 0, 0))}. Initial speed = {plane.speed}");

        Console.WriteLine("\nDrone");
        Drone drone = new(zeroCoordinate);
        drone.FlyTo(testCoordinate);
        drone.Print();
        Console.WriteLine($"{drone.GetFlyTime(new(19, 0, 0)) * 60}  {drone.GetFlyTime(new(20, 0, 0)) * 60}");
        //9.5min to fly 19km and 11 to fly on 21km (without stops should be 10min)
        drone.FlyTo(new(500, 0, 0));
        drone.Print();

        Console.WriteLine("\nBirds:");
        Bird bird1 = new(zeroCoordinate);
        Bird bird2 = new(zeroCoordinate);
        Console.WriteLine($"birds speed is {bird1.speed} and {bird2.speed} km/h");
        bird1.FlyTo(testCoordinate);
        bird1.FlyTo(new Coordinate(20, 0, 1));
        bird2.FlyTo(new Coordinate(7, 7, 6));
        Console.WriteLine(bird1.GetFlyTime(zeroCoordinate));
    }
}










