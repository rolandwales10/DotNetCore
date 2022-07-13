using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mdl = FarmshareAdmin.Models;
using utl = FarmshareAdmin.Utilities;

namespace FarmshareAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly mdl.ACF_FarmshareContext _context;
        private readonly IConfiguration _config;
        private readonly utl.icLogging _appLog;

        public IndexModel(ILogger<IndexModel> logger, mdl.ACF_FarmshareContext context, utl.icLogging appLog,
            IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _appLog = appLog;
            _logger.LogWarning("hello farmshareAdmin!");
            _config = config;

            //  Delete entries over 14 days old
            var sql = "delete from farmshare.message_log where create_time < dateadd(day, -2, getdate())";
            //var cmd = _conn.CreateCommand()
            _appLog.executeCommandNoParms(sql);
        }

        [BindProperty]
        public string env { get; set; } = default!;
        public void OnGet()
        {
            // logger.removeOldLogEntries();
            if (HttpContext.User.Identity.Name != null)
                _appLog.writeLog(HttpContext.User.Identity.Name);
            _appLog.writeLog("second msg");
            env = _config.GetValue<string>("Environment");
            ViewData["env"] = env;
        }
    }
}