using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FarmshareAdmin.Models;

namespace FarmshareAdmin.Pages.SeniorLivingFacilities
{
    public class IndexModel : PageModel
    {
        private readonly FarmshareAdmin.Models.ACF_FarmshareContext _context;

        public IndexModel(FarmshareAdmin.Models.ACF_FarmshareContext context)
        {
            _context = context;
        }

        public IList<SENIOR_LIVING_FACILITIES> SENIOR_LIVING_FACILITIES { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SENIOR_LIVING_FACILITIES != null)
            {
                SENIOR_LIVING_FACILITIES = await _context.SENIOR_LIVING_FACILITIES.ToListAsync();
            }
        }
    }
}
