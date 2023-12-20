using gcsharpRPC.Models;
using gcsharpRPC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gcsharpRPC.Pages.Polls
{
    public class CreatePollPageModel : PageModel
    {
        PollService _pollServ;

        public Poll Poll { get; set; }

        // public DateTime[] PollOptionDates { get; set; }
        
        public CreatePollPageModel(PollService pollService)
        {
            _pollServ = pollService;
        }
        
        public Task<IActionResult> OnPostAsync() {
            if (ModelState.IsValid && Poll != null) {
                await _pollService.CreatePollAsync(Poll, PollOptionDates);

                return RedirectToPage("Index", new { id = Poll.Id });
            }
            return Page();
        }
    }
}