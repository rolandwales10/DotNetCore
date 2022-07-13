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

namespace FarmshareAdmin.Data
{
    public interface icRawSql
    {
        public void executeCommandNoParms(string sql);
        //public void dispose();
    }
    public class RawSqlServices : icRawSql
    {
        mdl.ACF_FarmshareContext _context;
        DbConnection? conn;
        private readonly ILogger<RawSqlServices> _logger;
        public RawSqlServices(mdl.ACF_FarmshareContext context, ILogger<RawSqlServices> logger)
        {
            _context = context;
            _logger = logger;
            /*
             * This constructor is called every time a class is instantiated.  Only open it the first time.
             */
            if (conn == null)
            {
                conn = _context.Database.GetDbConnection();
                conn.Open();
            }
        }

        /*
         * Sample code that uses a command.  To make this generic, inject a dependency method to create the parameters.
         */
        //public void writeLog(string logMsg)
        //{
        //    using (var cmd = conn?.CreateCommand())
        //    {
        //        cmd.CommandText =
        //            "insert into farmshare.message_log (userid, create_time, log_message)  values ('', @create_time, @log_message)";
        //        cmd.Parameters.Add(new SqlParameter("@create_time", DateTime.Now.ToString()));
        //        cmd.Parameters.Add(new SqlParameter("@log_message", logMsg));
        //        using (var result = cmd.ExecuteReader())
        //        {
        //            /*
        //             * Insert returns result.rowsAffected.  I can see this with the debugger, but not with intellesense.
        //             */
        //            //while (result.Read())
        //        }
        //    }
        //}

        public void executeCommandNoParms(string sql)
        {
            try
            {
                using (var cmd = conn?.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in executeCommandNoParms: " + ex.ToString());
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
