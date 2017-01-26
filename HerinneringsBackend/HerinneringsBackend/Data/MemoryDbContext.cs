using Microsoft.AspNet.Identity.EntityFramework;
using RememberMeBackend.Models;
using RememberMeBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RememberMeBackend.Data {
    public class MemoryDbContext : IdentityDbContext {
        //ctor
        public MemoryDbContext() : base("MemoryDbConnection") {
        }
        public static MemoryDbContext Create() {
            return new MemoryDbContext();
        }
        //props
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<Trustee> Trustees { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //Identity setup
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            //M2M : Album-Memory
            modelBuilder.Entity<Album>()
                .HasMany(a => a.Memories)
                .WithMany(set => set.Albums)
                .Map(mapper => {
                    mapper.ToTable("albumsmemories", "dbo");
                    mapper.MapLeftKey("AMAlbum");
                    mapper.MapRightKey("AMMemory");
                });
            //M2M : Session-Album
            modelBuilder.Entity<Session>()
                .HasMany(s => s.Albums)
                .WithMany(set => set.Sessions)
                .Map(mapper => {
                    mapper.ToTable("sessionsalbums", "dbo");
                    mapper.MapLeftKey("SASession");
                    mapper.MapRightKey("SAAlbum");
                });
            //M2M : Timeline-Memory
            modelBuilder.Entity<Timeline>()
                .HasMany(t => t.Memories)
                .WithMany(set => set.Timelines)
                .Map(mapper => {
                    mapper.ToTable("timelinesmemories", "dbo");
                    mapper.MapLeftKey("TMTimeline");
                    mapper.MapRightKey("TMMemory");
                });
            //2xFK : Memory-User
            modelBuilder.Entity<Memory>()
                .HasRequired(m => m.Creator)
                .WithMany(u => u.CreatedMemories)
                .HasForeignKey(m => m.MemoryCreator)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Memory>()
                .HasRequired(m => m.Target)
                .WithMany(u => u.SharedMemories)
                .HasForeignKey(m => m.MemoryTarget)
                .WillCascadeOnDelete(false);
            //2xFK : Album-User
            modelBuilder.Entity<Album>()
                .HasRequired(a => a.Creator)
                .WithMany(u => u.CreatedAlbums)
                .HasForeignKey(a => a.AlbumCreator)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Album>()
                .HasRequired(a => a.Target)
                .WithMany(u => u.SharedAlbums)
                .HasForeignKey(a => a.AlbumTarget)
                .WillCascadeOnDelete(false);
            //2xFK : Session-User
            modelBuilder.Entity<Session>()
                .HasRequired(s => s.Creator)
                .WithMany(u => u.CreatedSessions)
                .HasForeignKey(s => s.SessionCreator)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Session>()
                .HasRequired(s => s.Target)
                .WithMany(u => u.SharedSessions)
                .HasForeignKey(a => a.SessionTarget)
                .WillCascadeOnDelete(false);
            //M2M : Timeline-User
            modelBuilder.Entity<Timeline>()
                .HasRequired(t => t.User)
                .WithMany(u => u.CreatedTimelines)
                .HasForeignKey(t => t.TimelineUser);
        }
    }
}