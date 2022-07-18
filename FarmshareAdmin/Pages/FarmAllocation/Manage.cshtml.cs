using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using mdl = FarmshareAdmin.Models;

namespace FarmshareAdmin.Pages.FarmAllocation
{
    public class ManageModel : BasePage
    {
        private readonly FarmshareAdmin.Models.ACF_FarmshareContext _context;
        private Data.ErrorService error;
        private ILogger _logger;

        public ManageModel(mdl.ACF_FarmshareContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logger");
            error = new Data.ErrorService(_logger);
        }

            [BindProperty]
        public Data.FarmAllocation fa { get; set; } = default!;
        public IActionResult OnGet()
        {
            try
            {
                if (isAdmin())
                {
//                    Redirect("/Msg/json");
                }
                else return Content(Data.Globals.notAuthorized);
            }
            catch (Exception ex)
            {
                error.logError("Error detected in " + this.GetType().Name, ex);
            }
            return Page();
        }

        public void OnPost()
        {

        }

        public JsonResult getJson()
        {
            List<Data.Message> msgs = new();
            msgs.Add(new Data.Message { status = "warning", content = "msg" });
            return new JsonResult(msgs);
        }
    }
}
