using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gcsharpRPC.Pages;

public class LoginModel : PageModel
{
    private readonly IConfiguration _config;

    public LoginModel(IConfiguration config)
    {
        _config = config;
    }

    public IActionResult OnGet()
    {
        // Auth by the razor page conventions.
        return RedirectToPage("Index");
    }
}