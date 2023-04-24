namespace FinalProject.Models
{
    public class FavoriteBreakFast
    {
        // attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public int TeamMemberId { get; set; } // foreign key to TeamMember
        public virtual TeamMember TeamMember { get; set; } // navigation property to TeamMember
    }
}
