using System.ComponentModel.DataAnnotations;

namespace WolfnetAPI.Models
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateOnly Date { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
