using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Web;

namespace gcsharpRPC.Pages;

public class LogoutModel : PageModel
{
    private readonly IConfiguration _config;

    public LogoutModel(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IActionResult> OnGet()
    {
        var idToken = await HttpContext.GetTokenAsync("id_token");
    }
}