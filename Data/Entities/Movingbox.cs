using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flytt2021.Data.Entities
{
    public class Movingbox
    {
        
        public int MovingboxId { get; set; }
        public string Marking { get; set; }
        [Required]
        [Display(Name = "Innehåll")]
        public string Contents { get; set; }

        [Display(Name = "Våning")]
        public FloorEnum DestinationFloorEnum { get; set; }
        public string Destination { get; set; }
        public bool IsUnpacked { get; set; } = false;

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

    public class Move
    {
        public int MoveId { get; set; }
        public string FromFriendlyName { get; set; }
        public string ToFriendlyName { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime MoveDate { get; set; }

        public string CreatedByUserName { get; set; }

        public ICollection<Movingbox> MovingBoxes { get; set; }
        public ICollection<Packer> Packers { get; set; }
        public ICollection<BoxOwner> BoxOwners { get; set; }
        public ICollection<DestinationFloor> DestinationFloors { get; set; }

        // For the future
        //public string FromAddressRow1 { get; set; }
        //public string FromAddressRow2 { get; set; }
        //public string FromPostalCode { get; set; }
        //public string FromCity { get; set; }
        //public string FromCountry { get; set; }
        //public string ToAddressRow1 { get; set; }
        //public string ToAddressRow2 { get; set; }
        //public string ToPostalCode { get; set; }
        //public string ToCity { get; set; }
        //public string ToCountry { get; set; }
    }

    public class DestinationFloor
    {
        public int DestinationFloorId { get; set; }
        public string Name { get; set; }
        public string BackgroundColorcode { get; set; }
        public string Colorcode { get; set; }
    }
}
