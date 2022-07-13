using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FarmshareAdmin.Models;
using FarmshareAdmin.Data;

namespace FarmshareAdmin.Pages.SeniorLivingFacilities
{
    public class DeleteModel : BasePage
    {
        private readonly FarmshareAdmin.Models.ACF_FarmshareContext _context;
        private ErrorService error;

        public DeleteModel(FarmshareAdmin.Models.ACF_FarmshareContext context, ILogger logger)
        {
            _context = context;
            error = new Data.ErrorService(logger);
        }

        [BindProperty]
      public SENIOR_LIVING_FACILITIES SENIOR_LIVING_FACILITIES { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (isAdmin())
            {
                try
                {
                    if (id == null)
                    {
                        ModelState.AddModelError("id", "Senior Living Facility id missing");
                    }

                    var senior_living_facilities = await _context.SENIOR_LIVING_FACILITIES.FirstOrDefaultAsync(m => m.FACILITY_ID == id);

                    if (senior_living_facilities == null)
                    {
                        ModelState.AddModelError("id", "Senior Living Facility id not found");
                    }
                    else
                    {
                        SENIOR_LIVING_FACILITIES = senior_living_facilities;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (isAdmin())
            {
                try
                {
                    if (id == null)
                    {
                        ModelState.AddModelError("id", "Senior Living Facility id missing");
                    }
                    var senior_living_facilities = await _context.SENIOR_LIVING_FACILITIES.FindAsync(id);

                    if (senior_living_facilities != null)
                    {
                        SENIOR_LIVING_FACILITIES = senior_living_facilities;
                        _context.SENIOR_LIVING_FACILITIES.Remove(SENIOR_LIVING_FACILITIES);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    error.logError("Error detected in " + this.GetType().Name, ex);
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else ModelState.AddModelError("", Globals.notAuthorized);

            return RedirectToPage("./Index");
        }
    }
}
