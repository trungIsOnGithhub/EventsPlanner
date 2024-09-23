namespace gcsharpRPC.Models
{
    public class PollOption
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public float StartTime { get; set; }

        public float EndTime { get; set; }

        public ICollection<UserVote> UserVotes { get; set; }  = new List<UserVote>();

        public override string ToString()
        {
            return $"On {Date}: from {StartTime} to {EndTime}";
        }
    }
}