using System.ComponentModel.DataAnnotations;

namespace flytt2021.Data.Entities;

public class UserMoveInvite 
{
    [Key]    
    public string UserName { get; set; }
    [Key]
    public int MoveId { get; set; }
    public string InvitedByUserName { get; set; }
} 