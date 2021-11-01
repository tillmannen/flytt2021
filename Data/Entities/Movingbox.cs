using System.ComponentModel.DataAnnotations;

namespace flytt2021.Data.Entities
{
    public class Movingbox
    {
        public int MovingboxId { get; set; }
        public int Number { get; set; }
        public string Marking { get; set; }
        [Required]
        [Display(Name = "Innehåll")]
        public string Contents { get; set; }

        [Display(Name = "Våning")]
        public FloorEnum DestinationFloorEnum { get; set; }
        public string Destination { get; set; }
        public bool IsUnpacked { get; set; } = false;
        [Display(Name = "Packa upp tidigt")]
        public bool PrioritizedUnpacking { get; set; } = false;

        public int? DestinationFloorId { get; set; }
        public DestinationFloor? DestinationFloor { get; set; }

        public int? PackerId { get; set; }
        public Packer? Packer { get; set; }

        public int? BoxOwnerId { get; set; }
        public BoxOwner? BoxOwner { get; set; }

        public int MoveId { get; set; }
        public Move Move { get; set; }
    }


    public enum FloorEnum
    {
        Basement = 1,
        Middle,
        Upper
    }
}
