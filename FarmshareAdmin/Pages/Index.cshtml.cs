using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mdl = FarmshareAdmin.Models;

namespace FarmshareAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger _logger;
        private readonly mdl.ACF_FarmshareContext _context;
        private readonly IConfiguration _config;

        public IndexModel(ILoggerFactory logger, mdl.ACF_FarmshareContext context,
            IConfiguration config)
        {
            _logger = logger.CreateLogger("logger");
            _context = context;
            _logger.LogWarning("hello farmshareAdmin!");
            _config = config;
        }

        [BindProperty]
        public string env { get; set; } = default!;
        public void OnGet()
        {
            if (HttpContext?.User?.Identity?.Name != null)
                _logger.LogInformation(HttpContext.User.Identity.Name + " at home page");

            //  Display the working environment on the home page
            env = _config.GetValue<string>("Environment");
            ViewData["env"] = env;
        }
    }
}