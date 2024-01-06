using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace gcsharpRPC.Pages;

public class LoginModel : PageModel
{
    [Required]
    [BindProperty]
    public String Username { get; set; }

    [Required]
    [BindProperty]
    [DataType(DataType.Password)]
    public String Password { get; set; }

    public String Message { get; set; }

    private readonly IConfiguration _config;

    public LoginModel(IConfiguration config)
    {
        _config = config;
    }

    public IActionResult OnGet()  
    {
        return Page();
    }

    public async Task<IActionResult> OnPostLogIn()  
    {
        if (Username.Equals("trungdeptrai") && Password.Equals("trungdeptrai"))
        {
            HttpContext.Session.SetString("username", Username);
            return Redirect("/Events/List");
        }

        Message = "Invalid Username Or Password";
        // try  
        // {   
        //     if (ModelState.IsValid)  
        //     {    
        //         var loginInfo = await this.databaseManager.LoginByUsernamePasswordMethodAsync(this.LoginModel.Username, this.LoginModel.Password);  
     
        //         if (loginInfo != null && loginInfo.Count() > 0)  
        //         {   
        //             var logindetails = loginInfo.First();  
    
        //             await this.SignInUser(logindetails.Username, false);  
    
        //             return this.RedirectToPage("/Home/Index");  
        //         }  
        //         else  
        //         {  
        //             // Setting.  
        //             ModelState.AddModelError(string.Empty, "Invalid username or password.");  
        //         }  
        //     }  
        // }  
        // catch (Exception ex)  
        // {  
        //     Console.Write(ex);  
        // }  

        return Page();  
    }
}