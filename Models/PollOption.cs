namespace gcsharpRPC.Models
{
    public class PollOption
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public ICollection<UserVote> UserVotes { get; set; }

        public PollOption()
        {
            Date = DateTime.Now;
            UserVotes = new List<UserVote>();
        }
    }
}