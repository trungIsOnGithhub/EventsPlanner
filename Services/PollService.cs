using gcsharpRPC.Models;
using gcsharpRPC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gcsharpRPC.Services
{
    public class PollService
    {
        private readonly TrungContext dbContext;

        public PollService(TrungContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Poll> GetPollAsync(int id)
        {
            return await dbContext.Polls
                .Where(poll => poll.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreatePollAsync(Poll poll, DateTime[] pollDateOptions)
        {
            foreach (var date in pollDateOptions) {
                poll.Options.Add(
                    new PollOption { Date = date }
                );
            }

            await dbContext.Polls.AddAsync(poll);

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePollAsync(int id)
        {
            var pollToDelete = await GetPollAsync(id);

            if (pollToDelete is null)
            {
                return id;
            }

            if (pollToDelete?.Options is not null)
            {
                foreach (var option in pollToDelete.Options)
                {
                    dbContext.PollOptions.Remove(option);
                }
            }

            dbContext.Polls.Remove(pollToDelete);

            await dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<int> ClosePollAsync(int id)
        {
            var poll = dbContext.Polls.Single(poll => poll.Id == id);

            poll.CloseDate = poll.CloseDate.HasValue ? null : DateTime.Now;
            
            await dbContext.SaveChangesAsync();

            return id;
        }
    }
}