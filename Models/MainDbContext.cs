using kolos.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace kolos.Models
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Membership>().HasKey(e => new { e.MemberID, e.TeamID });


            modelBuilder.Entity<Membership>().HasOne(e => e.Teams)
                .WithMany(m => m.Memberships)
                .HasForeignKey(m => m.TeamID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Membership>().HasOne(e => e.Members)
                .WithMany(m => m.Memberships)
                .HasForeignKey(m => m.MemberID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>().HasOne(e => e.Organization)
                .WithMany(m => m.Teams)
                .HasForeignKey(m => m.OrganizationID);

            modelBuilder.Entity<Member>().HasOne(e => e.Organization)
                .WithMany(m => m.Members)
                .HasForeignKey(m => m.OrganizationID);

            modelBuilder.Entity<File>().HasOne(e => e.Teams)
                .WithMany(m => m.Files)
                .HasForeignKey(m => m.TeamID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Member>().HasData(
                 new Member() { MemberID = 1, OrganizationID = 1, MemberName = "Kamil", MemberSurname = "P", MemberNickName = "Memberi" },
                 new Member() { MemberID = 2, OrganizationID = 2, MemberName = "Mati", MemberSurname = "P", MemberNickName = "Memberi2" }
                 );

            modelBuilder.Entity<Organization>().HasData(
                new Organization() { OrganizationID = 1, OrganizationName = "MyOrg1", OrganizationDomain = "MyOrg1.q.pl" },
                new Organization() { OrganizationID = 2, OrganizationName = "MyOrg2", OrganizationDomain = "MyOrg2.q.pl" }

                );
            modelBuilder.Entity<Membership>().HasData(
                new Membership() { MemberID = 1, TeamID = 1, MembershipDate = DateTime.Now },
                new Membership() { MemberID = 2, TeamID = 2, MembershipDate = DateTime.Now }

                );

            modelBuilder.Entity<Team>().HasData(
                new Team() { TeamID = 1, OrganizationID = 1, TeamName = "MyTeam1", TeamDescription = "dwadwadawdwa" },
                new Team() { TeamID = 2, OrganizationID = 2, TeamName = "MyTeam2", TeamDescription = "wwadwa" }

                );
        }
    }
}
