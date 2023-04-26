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
        public DbSet<TeamMemberHobby> TeamMemberHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMemberHobby>()
                .HasKey(pc => new { pc.TeamMemberId, pc.HobbyId });

            modelBuilder.Entity<TeamMemberHobby>()
                .Property(pc => pc.TeamMemberId)
                .ValueGeneratedNever();

            modelBuilder.Entity<TeamMemberHobby>()
                .Property(pc => pc.HobbyId)
                .ValueGeneratedNever();

            modelBuilder.Entity<TeamMemberHobby>()
                .HasOne(pc => pc.TeamMember)
                .WithMany(pc => pc.TeamMemberHobbies)
                .HasForeignKey(p => p.TeamMemberId);

            modelBuilder.Entity<TeamMemberHobby>()
                .HasOne(pc => pc.Hobby)
                .WithMany(pc => pc.TeamMemberHobbies)
                .HasForeignKey(c => c.HobbyId);

            modelBuilder.Entity<FavoriteBreakFast>()
        .Property(p => p.Price)
        .HasPrecision(18, 2);

            modelBuilder.Entity<TeamMember>().HasData(
        new TeamMember
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateTime(1990, 1, 1),
            CollegeProgram = "Computer Science",
            YearInProgram = "Junior"
        },
        new TeamMember
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Doe",
            BirthDate = new DateTime(1995, 1, 1),
            CollegeProgram = "Engineering",
            YearInProgram = "Sophomore"
        }
    );
            modelBuilder.Entity<FavoriteBreakFast>().HasData(
            new FavoriteBreakFast
            {
                Id = 1,
                Name = "Blueberry Pancakes",
                Description = "Fluffy pancakes loaded with fresh blueberries",
                Category = "Breakfast",
                Price = 6.99m,
                TeamMemberId = 1
            },
        new FavoriteBreakFast
        {
            Id = 2,
            Name = "Avocado Toast",
            Description = "Toasted bread topped with mashed avocado and seasoning",
            Category = "Breakfast",
            Price = 8.99m,
            TeamMemberId = 2
        }
    );
            modelBuilder.Entity<Hobby>().HasData(
            new Hobby
            {
                Id = 1,
                Name = "Reading",
                Description = "Enjoying a good book",
                Category = "Leisure",
                Frequency = "Daily"
            },
            new Hobby
            {
                Id = 2,
                Name = "Running",
                Description = "Jogging outdoors",
                Category = "Fitness",
                Frequency = "Weekly"
            },
            new Hobby
            {
                Id = 3,
                Name = "Gardening",
                Description = "Growing plants and flowers",
                Category = "Hobby",
                Frequency = "Monthly"
            }
        );

            modelBuilder.Entity<TeamMemberHobby>().HasData(
                new TeamMemberHobby
                {
                    TeamMemberId = 1,
                    HobbyId = 1
                },
                new TeamMemberHobby
                {
                    TeamMemberId = 2,
                    HobbyId = 2
                },
                new TeamMemberHobby
                {
                    TeamMemberId = 3,
                    HobbyId = 3
                }
            );

            modelBuilder.Entity<Address>().HasData(
           new Address
           {
               Id = 1,
               Street = "123 Main St",
               City = "Anytown",
               State = "CA",
               PostalCode = "12345",
               Country = "USA",
               TeamMemberId = 1
           },
           new Address
           {
               Id = 2,
               Street = "456 Elm St",
               City = "Anytown",
               State = "CA",
               PostalCode = "12345",
               Country = "USA",
               TeamMemberId = 2
           },
           new Address
           {
               Id = 3,
               Street = "789 Oak St",
               City = "Anytown",
               State = "CA",
               PostalCode = "12345",
               Country = "USA",
               TeamMemberId = 3
           }
       );

        }
    }
}

