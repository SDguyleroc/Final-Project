using static FinalProject.Models.TeamMeberHobby;

namespace FinalProject.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Frequency { get; set; }

        public ICollection<TeamMemberHobby> TeamMemberHobbies { get; set; }
        
    }
}
