
using FarmshareAdmin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mdl = FarmshareAdmin.Models;

namespace FarmshareAdmin.Pages.SeniorLivingFacilities
{
    public class EditModel : BasePage
    {
        private readonly mdl.ACF_FarmshareContext _context;
        private Error error;
        ILogger _logger;
        //utl.icLogging _appLog;

        public EditModel(mdl.ACF_FarmshareContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logger");
            //_appLog = appLog;
            error = new Data.Error(_logger);
        }

        [BindProperty]
        public mdl.SENIOR_LIVING_FACILITIES SENIOR_LIVING_FACILITIES { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (isAdmin())
            {
                try
                {
                    var slf = await _context.SENIOR_LIVING_FACILITIES.FirstOrDefaultAsync(m => m.FACILITY_ID == id);
                    if (slf != null)
                        SENIOR_LIVING_FACILITIES = slf;
                    else
                    {
                        SENIOR_LIVING_FACILITIES = new();
                        SENIOR_LIVING_FACILITIES.FACILITY_ID = 0;   // treat as new
                        SENIOR_LIVING_FACILITIES.STATE = "ME";
                    }
                }
                catch (Exception ex)
                {
                    error.logError("Error detected in " + this.GetType().Name, ex);
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else ModelState.AddModelError("", Globals.notAuthorized);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            List<Data.Message> messages = new();
            if (isAdmin())
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Page();
                    }

                    var gr = new Data.GenericRepositoryService<mdl.SENIOR_LIVING_FACILITIES>(_context);
                    if (SENIOR_LIVING_FACILITIES.FACILITY_ID == 0)
                        gr.Insert(SENIOR_LIVING_FACILITIES);
                    else gr.Update(SENIOR_LIVING_FACILITIES);

                    var uw = new Data.UnitOfWork(_context, _logger);
                    messages = await uw.SaveAsync("Senior Living Facilities");
                }
                catch (Exception ex)
                {
                    error.logError("Error detected in " + this.GetType().Name, ex);
                    Data.MessageService.AddErrorMessage(messages, ex.Message);
                }
            }
            else ModelState.AddModelError("", Globals.notAuthorized);
            if (messages.Count > 0 || !ModelState.IsValid)
            {
                ModelErrorService.toModel(messages, ModelState);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
