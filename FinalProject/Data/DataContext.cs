using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using static FinalProject.Models.TeamMeberHobby;

namespace FinalProject.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<FavoriteBreakFast> FavoriteBreakFasts { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamMeberHobby> TeamMeberHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMemberHobby>()
         .HasKey(pc => new { pc.TeamMemberId, pc.HobbyId });

            modelBuilder.Entity<TeamMemberHobby>()
                .HasOne(pc => pc.TeamMember)
                .WithMany(pc => pc.TeamMemberHobbies)
                .HasForeignKey(p => p.TeamMemberId);

            modelBuilder.Entity<TeamMemberHobby>()
               .HasOne(pc => pc.Hobby)
               .WithMany(pc => pc.TeamMemberHobbies)
               .HasForeignKey(c => c.HobbyId);
        }

    }
}
