using System.Collections.Generic;

namespace flytt2021.Data.Entities
{
    public class BoxOwner
    {
        public int BoxOwnerId { get; set; }
        public string Name { get; set; }

        public int MoveId { get; set; }
        public Move Move { get; set; }

        public List<Movingbox> OwnedBoxes { get; set; }
    }
}
