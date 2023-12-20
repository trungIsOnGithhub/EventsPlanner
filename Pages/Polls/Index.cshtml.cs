using Microsoft.EntityFrameworkCore;
using gcsharpRPC.Models;
using gcsharpRPC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gcsharpRPC.Pages.Polls
{
    public class GetPollPageModel : PageModel
    {
        private readonly PollService _service;

        public Poll Poll { get; set; }

        public GetPollPageModel(TrungContext dbContext)
        {
            _context = dbContext;
        }

        public async Task OnGetAsync(int id)
        {
            _logger.LogInformation($"OnGetAsync IndexModel with ID: {id}");
            Poll = await _pollService.GetPollAsync(id);
        }

        // public async Task<IActionResult> OnGetAsync(int? id)
        // {
        //     if (id == null)
        //     {
        //         System.Diagnostics.Debug.WriteLine("ID is NULL");
        //         return NotFound();
        //     }

        //     System.Diagnostics.Debug.WriteLine("ID is: " + id);

        //     Poll = await _context.Polls.FirstOrDefaultAsync(m => m.Id == id);

        //     System.Diagnostics.Debug.WriteLine("Poll is: " + (Poll is null));

        //     if (Poll == null)
        //     {
        //         return NotFound();
        //     }

        //     return Page();
        // }
        
        // public void OnGet(int id)
        // {
        //     // System.Console.WriteLine(id);
        //     // Poll = dbContext.Polls
        //     //             .Single(x => x.Id == id);
        //     Poll = new Poll{
        //         Id = 68,
        //         Title = "Cong Ty Axon Active Nhu CC",
        //         Description = "Cong Ty Axon Active Nhu CC",
        //         Location = "Hai Au Building"
        //     };
        // }
    }
}
