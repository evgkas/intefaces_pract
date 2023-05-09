namespace Intefaces_Pract
{
    public interface IFlyable
    {
        public Coordinate FlyTo(Coordinate newCoordinate);

        public double GetFlyTime(Coordinate newCoordinate);
    }
}
