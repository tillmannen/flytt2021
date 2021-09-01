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
        [Required]
        [Display(Name = "Våning")]
        public FloorEnum DestinationFloorEnum { get; set; }
        public string Destination { get; set; }
        public bool IsUnpacked { get; set; } = false;

        public int DestinationFloorId { get; set; }
        public DestinationFloor DestinationFloor { get; set; }

        public int PackerId { get; set; }
        public Packer Packer { get; set; }

        public int BoxOwnerId { get; set; }
        public BoxOwner BoxOwner { get; set; }

        public int MoveId { get; set; }
        public Move Move { get; set; }
    }


    public enum FloorEnum
    {
        Basement,
        Middle,
        Upper
    }

    public class Move
    {
        public int MoveId { get; set; }
        public string FromFriendlyName { get; set; }
        public string ToFriedlyName { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime MoveDate { get; set; }

        public string CreatedByUserName { get; set; }

        public List<Movingbox> MovingBoxes { get; set; }
        public List<Packer> Packers { get; set; }
        public List<BoxOwner> BoxOwners { get; set; }
        public List<DestinationFloor> DestinationFloors { get; set; }

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
        public string Colorcode { get; set; }
    }
}
