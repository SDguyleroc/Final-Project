using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class TeamMeberHobby
    {
        
            [Key]
            public int Id { get; set; } 

            public int TeamMemberId { get; set; }
            public TeamMember TeamMember { get; set; }

            public int HobbyId { get; set; }
            public Hobby Hobby { get; set; }
    }
}
