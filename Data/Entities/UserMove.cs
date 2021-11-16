using System.ComponentModel.DataAnnotations;

namespace flytt2021.Data.Entities;

public class UserMove
{
    [Key]
    public string UserName { get; set; }
    [Key]
    public int MoveId { get; set; }
}

