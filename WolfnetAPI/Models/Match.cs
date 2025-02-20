using System.ComponentModel.DataAnnotations;

namespace WolfnetAPI.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public Competition? Competition { get; set; }

        public Team? RedOne { get; set; }

        public Team? RedTwo { get; set; }

        public Team? RedThree { get; set; }

        public Team? BlueOne { get; set; }

        public Team? BlueTwo { get; set; }

        public Team? BlueThree { get; set; }
    }
}
