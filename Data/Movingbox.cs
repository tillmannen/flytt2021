using System;
using System.ComponentModel.DataAnnotations;

namespace flytt2021.Data
{
    public class Movingbox
    {
        
        public int Id { get; set; }
        public string Marking { get; set; }
        [Required]
        [Display(Name = "Innehåll")]
        public string Contents { get; set; }
        [Required]
        [Display(Name = "Våning")]
        public Floor DestinationFloor { get; set; }
        public string Destination { get; set; }
        public Packer Packer { get; set; }
        public BoxOwner BoxOwner { get; set; }
        public bool IsUnpacked { get; set; } = false;
    }

    public enum Floor
    {
        Basement,
        Middle,
        Upper
    }
}
