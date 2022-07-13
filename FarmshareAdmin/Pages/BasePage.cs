using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmshareAdmin.Pages
{
    public class BasePage : PageModel
    {
        public bool isAdmin()
        {
            return User.IsInRole("AGR-FarmShare-DataEntry") || User.IsInRole("DCN-Programmers")
                || User.IsInRole("OIT-CTS-ALL");  //  oit-cts-all is for security and accessibility testing only.
        }
    }
}
