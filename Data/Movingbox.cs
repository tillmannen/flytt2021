using System;
using System.ComponentModel.DataAnnotations;

namespace flytt2021.Data
{
    public class Movingbox
    {
        
        public int Id { get; set; }
        public string Marking { get; set; }
        [Required]
        [Display(Name = "Inneh�ll")]
        public string Contents { get; set; }
        [Required]
        [Display(Name = "V�ning")]
        public Floor DestinationFloor { get; set; }
        public string Destination { get; set; }
        public string PackedBy { get; set; }
        public BoxOwner BoxOwner { get; set; }
        public bool IsUnpacked { get; set; } = false;
    }

    public class BoxOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum Floor
    {
        Basement,
        Middle,
        Upper
    }
}
