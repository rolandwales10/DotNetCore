using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

using mdl = FarmshareAdmin.Models;
/*
 *  Synopsis: Writes log messages.
 *  October 2016  Roland Wales
 *  Change log:
 */

namespace FarmshareAdmin.Utilities
{
    public interface icLogging
    {
        public void writeLog(string logMsg);
        public void executeCommandNoParms(string sql);
        //public void dispose();
    }
    public class Logging : icLogging
    {
        mdl.ACF_FarmshareContext _context;
        System.Data.Common.DbConnection? conn;
        public Logging(mdl.ACF_FarmshareContext context)
        {
            _context = context;
            /*
             * Issue: this shouldn't be necessary, but the constructor is being called from seniorLivingFacilities.edit
             * for some reason.  Should only happend in program.cs when the dependency is created.
             */
            if (conn == null)
            {
                conn = _context.Database.GetDbConnection();
                conn.Open();
            }
        }
        public void writeLog(string logMsg)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText =
                    "insert into farmshare.message_log (userid, create_time, log_message)  values ('', @create_time, @log_message)";
                cmd.Parameters.Add(new SqlParameter("@create_time", DateTime.Now.ToString()));
                cmd.Parameters.Add(new SqlParameter("@log_message", logMsg));
                using (var result = cmd.ExecuteReader())
                {
                    /*
                     * Insert returns result.rowsAffected.  I can see this with the debugger, but not with intellesense.
                     */
                    //while (result.Read())
                }
            }
        }


        public void executeCommandNoParms(string sql)
        {
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                writeLog("Error in removeOldLogEntries: " + ex.ToString());
            }
        }

        /*
         * Not sure if this is needed.  Controllers would need a dispose method to use it.  None is being generated
         * with scaffolding.
         */
        //public void dispose()
        //{
        //    conn.Close();
        //}
    }
}
