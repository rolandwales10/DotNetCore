/*
 *  Synopsis: Logs errors.  This is most relevant for database detected errors, where the error
 *      message is in the exception, but not always in the same place within it.
 *  
 *  October 2016  Roland Wales
 *  
 *  Change log:
 */

namespace FarmshareAdmin.Data
{
    public class ErrorService
    {
        private readonly ILogger _logger;
        public ErrorService(ILogger logger)
        {
            _logger = logger;
        }
        public void logError(string referenceLocation, Exception exParm)
        {
            /*
             *  Write the database error message to the log
             */

            string msg = referenceLocation + "  ";
            try
            {
                if (exParm.Message != null)
                    msg += exParm.Message;
                else
                    msg += "undetermined error message";
                _logger.LogError(msg);
                if (exParm.StackTrace != null)
                    _logger.LogError(exParm.StackTrace);
                if (exParm.InnerException != null)
                    getInnerExceptions(exParm.InnerException);
            }
            catch (Exception)
            {
                string st = exParm.Message;   /* no where to log this error, use this for debugging */
            }
        }

        public void getInnerExceptions(object comServer)
        {
            string? exception = "";

            exception = ((Exception)comServer).Message;
            _logger.LogError(exception);
            if (((Exception)comServer).InnerException != null)
            {
                getInnerExceptions(((Exception)comServer).InnerException);
            }
        }
    }
}
