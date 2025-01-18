using System.ComponentModel.DataAnnotations;

namespace WolfnetAPI.Models
{
    public class Team
    {
        public string Name { get; set; }

        [Key]
        public string Number { get; set; }

        public string Notes { get; set; }

        public ICollection<Competition> Competitions { get; set; }
    }
}
