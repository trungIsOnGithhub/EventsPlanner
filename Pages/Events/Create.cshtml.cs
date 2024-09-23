using gcsharpRPC.Models;
using gcsharpRPC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Globalization;

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

        public IActionResult OnGet() {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            // if (HttpContext.Session.GetString("username") is null)
            // {
            //     return Redirect("/Login");
            // }
            if (Request.Form.Count < 4)
            {
                ViewData["PollOptionErrors"] = "Poll Option Cannot Be Empty!";
                return Page();
            }

             _logger.LogInformation("11111111");

            if (!ModelState.IsValid) {
                ViewData["PollOptionErrors"] = "Invalid Input Data!";
                return Page();
            }

                         _logger.LogInformation("22222222");

            IList<PollOption> pollOptions = new List<PollOption>();
            foreach (var item in Request.Form) {
                // _logger.LogInformation($"Key = {item.Key}, Value = {item.Value}");
                if (!item.Key.Contains("starttime") && !item.Key.Contains("endtime"))
                { continue; }

                var anotherPartialTimeKey = item.Key.IndexOf("starttime") == 0
                                        ?  item.Key.Replace("starttime", "endtime")
                                        : item.Key.Replace("endtime", "starttime") ;
                var dateKey = item.Key.IndexOf("starttime") == 0
                            ?  item.Key.Replace("starttime", "date")
                            : item.Key.Replace("endtime", "date");

                if (!Request.Form.ContainsKey(anotherPartialTimeKey)
                    || !Request.Form.ContainsKey(dateKey))
                {
                    ViewData["PollOptionErrors"] = "Invalid Input Data!";
                    return Page();
                }

                DateTime date = new DateTime();
                _logger.LogInformation($"----{Request.Form[dateKey]}");
                try
                {
                    date = DateTime.ParseExact(Request.Form[dateKey], "yyyy-MM-dd", null);
                } catch
                {
                    continue;
                }
 
                var startTime = item.Key.IndexOf("starttime") == 0
                            ?  Request.Form[item.Key]
                            : Request.Form[anotherPartialTimeKey];
                var endTime = item.Key.IndexOf("endtime") == 0
                            ?  Request.Form[item.Key]
                            : Request.Form[anotherPartialTimeKey];
                
                var startTimeFloat = float.Parse(startTime, CultureInfo.InvariantCulture.NumberFormat);
                var endTimeFloat = float.Parse(endTime, CultureInfo.InvariantCulture.NumberFormat);

                var pollOption = new PollOption {
                    Date = date,
                    StartTime = startTimeFloat,
                    EndTime = endTimeFloat
                };

                pollOptions.Add(pollOption);
            }

            _logger.LogInformation("5555555");
            await _service.CreatePollAsync(Poll, pollOptions);
            foreach (var option in pollOptions)
            {
                _logger.LogInformation(option.ToString());
            }

            return Page();
        }
    }
}