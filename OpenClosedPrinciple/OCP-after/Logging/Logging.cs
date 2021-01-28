namespace OCPAfter.Logger
{
    public class Logging : ILogging
    {
        public void Log(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}