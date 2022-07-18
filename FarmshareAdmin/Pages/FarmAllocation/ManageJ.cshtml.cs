using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarmshareAdmin.Pages.FarmAllocation
{
    public class ManageJModel : PageModel
    {
        public JsonResult OnGet()
        {
            List<Data.Message> msgs = new();
            msgs.Add(new Data.Message { status = "warning", content = "msg" });
            return new JsonResult(msgs);
        }
    }
}
