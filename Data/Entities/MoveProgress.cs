using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flytt2021.Data.Entities
{
    public class MoveProgress
    {
        public int EstimatedBoxCount { get; set; }
        public int PackedBoxes { get; set; }
        public int PackedPercentage => EstimatedBoxCount > 0 ? Math.Min((int)Math.Floor((decimal)PackedBoxes / EstimatedBoxCount * 100), 100) : 0;
    }
}
