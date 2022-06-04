using System;

namespace HelmetShop.Api
{
    public class ExceptionLogger
    {
        public void LogException(Exception e, Guid errorId)
        {
            var message = "Time: " + DateTime.UtcNow.ToLongDateString() + " Message: " + e.Message;
            message += "\n";
            message += "Stack trace: " + e.StackTrace;
            message += "\n";
            message += "Inner ex message: " + e.InnerException?.Message;
            message += "Error ID: " + errorId.ToString();
            Console.WriteLine(message);
        }
    }
}
