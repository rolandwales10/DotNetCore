using System;
using System.Collections.Generic;
using System.Linq;
using mdl = FarmshareAdmin.Models;


/*
 *  Synopsis: Logs errors.  This is most relevant for database detected errors, where the error
 *      message is in the exception, but not always in the same place within it.
 *  
 *  October 2016  Roland Wales
 *  
 *  Change log:
 */


namespace FarmshareAdmin.Utilities
{
    public class Error
    {
        //mdl.ACF_FarmshareContext _context;
        //Logging logger;
        icLogging logger;
        public Error(icLogging logging)
        {
            logger = logging;
        }
        public void logError(string referenceLocation, Exception exParm)
        {
            /*
             *  Write the database error message to the log
             */

            string msg = referenceLocation + "  ";
            try {
                /*
                 *  Look for database detected errors first
                 */
                //if (exParm.InnerException != null && exParm.InnerException.InnerException != null)
                //{
                //    msg += exParm.InnerException.InnerException.ToString();
                //}
                if (exParm.Message != null)
                    msg += exParm.Message;
                else
                    msg += "undetermined error message";
                logger.writeLog(msg);
                if (exParm.StackTrace != null)
                    logger.writeLog(exParm.StackTrace);
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

            exception = (((Exception)comServer).Message);
            logger.writeLog(exception);
            if (((Exception)comServer).InnerException != null)
            {
                getInnerExceptions(((Exception)comServer).InnerException);
            }
        }
    }
}
