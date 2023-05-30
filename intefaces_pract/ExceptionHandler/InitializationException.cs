namespace intefaces_pract.ExceptionHandler
{
    public class InitializationException : Exception
    {
        public InitializationException(string message) : base()
        {
            Console.WriteLine("Error:" + message);
        }
    }
}