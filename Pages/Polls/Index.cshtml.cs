using Microsoft.EntityFrameworkCore;
using gcsharpRPC.Models;
using gcsharpRPC.Services;
using gcsharpRPC.Helpers    ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gcsharpRPC.Pages.Polls
{
    public class GetPollPageModel : PageModel
    {
        private readonly ILogger<GetPollPageModel> _logger;

        private readonly PollService _service;
        
        public Poll Poll { get; set; }

        public GetPollPageModel(PollService service, ILogger<GetPollPageModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task OnGetAsync(int id)
        {
            _logger.LogInformation($"Call OnGetAsync IndexModel with ID: {id}");
            Poll = await _service.GetPollAsync(id);
        }

        public async Task<IActionResult> OnPostCloseAsync(int id)
        {
            _logger.LogInformation($"Call OnPostCloseAsync with ID {id}");
            int idClosed = await _service.ClosePollAsync(id);
            return RedirectToPage("/Polls/Index", new { id = idClosed.ToString() });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            _logger.LogInformation($"Call OnDeleteAsync with ID {id}");
            int idDeleted = await _service.DeletePollAsync(id);
            return RedirectToPage("/Polls/Index", new { id = idDeleted.ToString() });;
        }
    }
}
