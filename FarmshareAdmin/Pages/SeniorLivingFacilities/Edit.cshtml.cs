
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bal = FarmshareAdmin.BusinessAreaLayer;
using mdl = FarmshareAdmin.Models;
using utl = FarmshareAdmin.Utilities;
using vm = FarmshareAdmin.ViewModels;

namespace FarmshareAdmin.Pages.SeniorLivingFacilities
{
    public class EditModel : BasePage
    {
        private readonly mdl.ACF_FarmshareContext _context;
        private utl.Error error;
        utl.icLogging _appLog;

        public EditModel(mdl.ACF_FarmshareContext context, utl.icLogging appLog)
        {
            _context = context;
            _appLog = appLog;
            error = new utl.Error(appLog);
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
            else ModelState.AddModelError("", utl.Globals.notAuthorized);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            List<vm.VmMessage> messages = new();
            if (isAdmin())
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Page();
                    }

                    var gr = new bal.GenericRepository<mdl.SENIOR_LIVING_FACILITIES>(_context);
                    if (SENIOR_LIVING_FACILITIES.FACILITY_ID == 0)
                        gr.Insert(SENIOR_LIVING_FACILITIES);
                    else gr.Update(SENIOR_LIVING_FACILITIES);

                    var uw = new bal.UnitOfWork(_context, _appLog);
                    messages = await uw.SaveAsync("Senior Living Facilities");
                }
                catch (Exception ex)
                {
                    error.logError("Error detected in " + this.GetType().Name, ex);
                    vm.VmMessage.AddErrorMessage(messages, ex.Message);
                }
            }
            else ModelState.AddModelError("", utl.Globals.notAuthorized);
            if (messages.Count > 0 || !ModelState.IsValid)
            {
                utl.ModelErrors.toModel(messages, ModelState);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
