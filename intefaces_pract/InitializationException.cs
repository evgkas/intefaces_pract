namespace Intefaces_Pract
{
    public class InitializationException : Exception
    {
        public InitializationException(string message) : base()
        {
            Console.WriteLine("Error:" + message);
        }
    }
}
