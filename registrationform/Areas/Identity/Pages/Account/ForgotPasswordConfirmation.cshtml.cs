using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace registrationform.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        // Property to hold the password reset code
        public string Code { get; set; }

        // This method is called when the page is requested via GET
        public IActionResult OnGet(string code = null)
        {
            // Populate the Code property with the provided code
            Code = code;
            return Page();
        }
    }
}
