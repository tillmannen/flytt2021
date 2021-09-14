using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace flytt2021.Data.Entities
{
    [Table("Move")]
    public class Move
    {
        public int MoveId { get; set; }
        public string FromFriendlyName { get; set; }
        public string ToFriendlyName { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime MoveDate { get; set; }

        public string CreatedByUserName { get; set; }

        public int? FromArea { get; set; }

        public ICollection<Movingbox> MovingBoxes { get; set; }
        public ICollection<Packer> Packers { get; set; }
        public ICollection<BoxOwner> BoxOwners { get; set; }
        public ICollection<DestinationFloor> DestinationFloors { get; set; }

        // For the future maybe
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
}
