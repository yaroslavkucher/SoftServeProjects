using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaProject
{
    public class AppDbContext: DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<CinemaHall> Halls { get; set; }
        public DbSet<HallType> HallTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionStatus> SessionStatuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Cinema; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
                         .HasOne(f => f.Discount)
                         .WithOne(d => d.Film)
                         .HasForeignKey<Discount>(d => d.FilmID);

            modelBuilder.Entity<HallType>().HasData(
                new HallType { ID = 1, HallName = "Common" },
                new HallType { ID = 2, HallName = "VIP" }
            );

            modelBuilder.Entity<SessionStatus>().HasData(
                new SessionStatus { SessionStatusID = 1, SessionStatusName = "Active" },
                new SessionStatus { SessionStatusID = 2, SessionStatusName = "Canceled" }
            );

            modelBuilder.Entity<TicketStatus>().HasData(
                new TicketStatus { TicketStatusID = 1, TicketStatusName = "Bought" },
                new TicketStatus { TicketStatusID = 2, TicketStatusName = "Reserved" },
                new TicketStatus { TicketStatusID = 3, TicketStatusName = "Returned" }
            );

            modelBuilder.Entity<UserType>().HasData(
                new UserType { UserTypeID = 1, UserTypeName = "Common user" },
                new UserType { UserTypeID = 2, UserTypeName = "Administrator" }
            );
        }
    }
}
