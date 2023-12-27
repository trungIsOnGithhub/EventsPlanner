using gcsharpRPC.Models;
using gcsharpRPC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gcsharpRPC.Pages.Polls
{
    public class CreatePollPageModel : PageModel
    {
        private readonly PollService _service;

        private readonly ILogger _logger;

        [BindProperty]
        public Poll Poll { get; set; }

        [BindProperty]
        public DateTime[] PollOptionDates { get; set; }
        
        public CreatePollPageModel(PollService pollService,
                            ILogger<CreatePollPageModel> logger)
        {
            _service = pollService;
            _logger = logger;
        }
        
        public async Task<IActionResult> OnPostAsync() {
            _logger.LogInformation("Called OnPostAsync!!");

            if (ModelState.IsValid) {
                _logger.LogInformation("Model Valid");
            }

            if (Poll is not null) {
                _logger.LogInformation("Poll is not null");
            }

            if (PollOptionDates is not null) {
                _logger.LogInformation("PollOptionDates is not null");
            }

            if (PollOptionDates.Length == 0)
            {
                _logger.LogInformation("PollOptionDates is zero");
            }
            else
            {
                _logger.LogInformation("PollOptionDates is not zero");
            }

            foreach (var p in PollOptionDates)
            {
                _logger.LogInformation("--> " + p.ToString());
            }

            if (ModelState.IsValid && Poll is not null) {
                await _service.CreatePollAsync(Poll, PollOptionDates);

                return RedirectToPage("Index", new { id = Poll.Id });
            }

            return Page();
        }
    }
}