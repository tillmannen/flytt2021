namespace flytt2021.Data.Entities;

public class MoveProgress
{
    public int EstimatedBoxCount { get; set; }
    public int PackedBoxes { get; set; }
    public int UnpackedBoxes { get; set; }
    public int TotalBoxes { get; set; }
    public int PackedPercentage => EstimatedBoxCount > 0 ? Math.Min((int)Math.Floor((decimal)PackedBoxes / EstimatedBoxCount * 100), 100) : 0;
    public int UnpackedPercentage => TotalBoxes > 0 ? Math.Min((int)Math.Floor((decimal)UnpackedBoxes / TotalBoxes * 100), 100) : 0;
    public int LeftToUnpack => TotalBoxes - UnpackedBoxes;
}

