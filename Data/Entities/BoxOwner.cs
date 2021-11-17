﻿namespace flytt2021.Data.Entities;

public class BoxOwner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDefault { get; set; }


    public int MoveId { get; set; }
    public Move Move { get; set; }
}

