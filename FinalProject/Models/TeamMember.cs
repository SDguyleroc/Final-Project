using Microsoft.EntityFrameworkCore;
using static FinalProject.Models.TeamMeberHobby;

namespace FinalProject.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CollegeProgram { get; set; }
        public string YearInProgram { get; set; }
        // Navigation properties
        
        public ICollection<FavoriteBreakFast> FavoriteBreakFasts { get; set; }
        public ICollection<TeamMemberHobby> TeamMemberHobbies { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
