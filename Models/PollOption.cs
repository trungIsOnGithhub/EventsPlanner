namespace gcsharpRPC.Models
{
    public class PollOption
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<UserVote> UserVotes { get; set; }  = new List<UserVote>();
    }
}