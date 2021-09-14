using System.ComponentModel.DataAnnotations.Schema;

namespace flytt2021.Data.Entities
{
    [Table("DestinationFloor")]
    public class DestinationFloor
    {
        public int DestinationFloorId { get; set; }
        public string Name { get; set; }
        public string BackgroundColorcode { get; set; }
        public string Colorcode { get; set; }

        public int MoveId { get; set; }
        public Move Move { get; set; }
    }
}
