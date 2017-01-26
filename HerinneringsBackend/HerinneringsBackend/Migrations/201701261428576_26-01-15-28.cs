namespace RememberMeBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26011528 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.albums",
                c => new
                    {
                        AlbumUuid = c.String(nullable: false, maxLength: 128),
                        AlbumName = c.String(),
                        AlbumThumbnail = c.String(),
                        AlbumCreator = c.String(nullable: false, maxLength: 128),
                        AlbumTarget = c.String(nullable: false, maxLength: 128),
                        AlbumLastModified = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumUuid)
                .ForeignKey("dbo.IdentityUsers", t => t.AlbumCreator)
                .ForeignKey("dbo.IdentityUsers", t => t.AlbumTarget)
                .Index(t => t.AlbumCreator)
                .Index(t => t.AlbumTarget);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        UserFirstName = c.String(),
                        UserLastName = c.String(),
                        UserQuestion1 = c.String(),
                        UserQuestion2 = c.String(),
                        UserAnswer1 = c.String(),
                        UserAnswer2 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.memories",
                c => new
                    {
                        MemoryUuid = c.String(nullable: false, maxLength: 128),
                        MemoryDescription = c.String(),
                        MemoryDate = c.String(),
                        MemoryRating = c.Int(nullable: false),
                        MemoryLocationLat = c.Single(nullable: false),
                        MemoryLocationLong = c.Single(nullable: false),
                        MemoryLocationName = c.String(),
                        MemoryPath = c.String(),
                        MemoryType = c.String(),
                        MemoryCreator = c.String(nullable: false, maxLength: 128),
                        MemoryTarget = c.String(nullable: false, maxLength: 128),
                        MemoryLastModified = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MemoryUuid)
                .ForeignKey("dbo.IdentityUsers", t => t.MemoryCreator)
                .ForeignKey("dbo.IdentityUsers", t => t.MemoryTarget)
                .Index(t => t.MemoryCreator)
                .Index(t => t.MemoryTarget);
            
            CreateTable(
                "dbo.timelines",
                c => new
                    {
                        TimelineUuid = c.String(nullable: false, maxLength: 128),
                        TimelineMemory = c.String(),
                        TimelineUser = c.String(nullable: false, maxLength: 128),
                        TimelineLastModified = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TimelineUuid)
                .ForeignKey("dbo.IdentityUsers", t => t.TimelineUser, cascadeDelete: true)
                .Index(t => t.TimelineUser);
            
            CreateTable(
                "dbo.sessions",
                c => new
                    {
                        SessionUuid = c.String(nullable: false, maxLength: 128),
                        SessionName = c.String(),
                        SessionDate = c.String(),
                        SessionNotes = c.String(),
                        SessionDuration = c.String(),
                        SessionCount = c.Int(nullable: false),
                        SessionIsFinished = c.Boolean(nullable: false),
                        SessionCreator = c.String(nullable: false, maxLength: 128),
                        SessionTarget = c.String(nullable: false, maxLength: 128),
                        SessionLastModified = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.SessionUuid)
                .ForeignKey("dbo.IdentityUsers", t => t.SessionCreator)
                .ForeignKey("dbo.IdentityUsers", t => t.SessionTarget)
                .Index(t => t.SessionCreator)
                .Index(t => t.SessionTarget);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.trustees",
                c => new
                    {
                        TrusteeSource = c.String(nullable: false, maxLength: 128),
                        TrusteeDestination = c.String(nullable: false, maxLength: 128),
                        TrusteeConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrusteeSource, t.TrusteeDestination });
            
            CreateTable(
                "dbo.timelinesmemories",
                c => new
                    {
                        TMTimeline = c.String(nullable: false, maxLength: 128),
                        TMMemory = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TMTimeline, t.TMMemory })
                .ForeignKey("dbo.timelines", t => t.TMTimeline, cascadeDelete: true)
                .ForeignKey("dbo.memories", t => t.TMMemory, cascadeDelete: true)
                .Index(t => t.TMTimeline)
                .Index(t => t.TMMemory);
            
            CreateTable(
                "dbo.sessionsalbums",
                c => new
                    {
                        SASession = c.String(nullable: false, maxLength: 128),
                        SAAlbum = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SASession, t.SAAlbum })
                .ForeignKey("dbo.sessions", t => t.SASession, cascadeDelete: true)
                .ForeignKey("dbo.albums", t => t.SAAlbum, cascadeDelete: true)
                .Index(t => t.SASession)
                .Index(t => t.SAAlbum);
            
            CreateTable(
                "dbo.albumsmemories",
                c => new
                    {
                        AMAlbum = c.String(nullable: false, maxLength: 128),
                        AMMemory = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AMAlbum, t.AMMemory })
                .ForeignKey("dbo.albums", t => t.AMAlbum, cascadeDelete: true)
                .ForeignKey("dbo.memories", t => t.AMMemory, cascadeDelete: true)
                .Index(t => t.AMAlbum)
                .Index(t => t.AMMemory);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.albums", "AlbumTarget", "dbo.IdentityUsers");
            DropForeignKey("dbo.albumsmemories", "AMMemory", "dbo.memories");
            DropForeignKey("dbo.albumsmemories", "AMAlbum", "dbo.albums");
            DropForeignKey("dbo.albums", "AlbumCreator", "dbo.IdentityUsers");
            DropForeignKey("dbo.sessions", "SessionTarget", "dbo.IdentityUsers");
            DropForeignKey("dbo.sessions", "SessionCreator", "dbo.IdentityUsers");
            DropForeignKey("dbo.sessionsalbums", "SAAlbum", "dbo.albums");
            DropForeignKey("dbo.sessionsalbums", "SASession", "dbo.sessions");
            DropForeignKey("dbo.timelines", "TimelineUser", "dbo.IdentityUsers");
            DropForeignKey("dbo.timelinesmemories", "TMMemory", "dbo.memories");
            DropForeignKey("dbo.timelinesmemories", "TMTimeline", "dbo.timelines");
            DropForeignKey("dbo.memories", "MemoryTarget", "dbo.IdentityUsers");
            DropForeignKey("dbo.memories", "MemoryCreator", "dbo.IdentityUsers");
            DropIndex("dbo.albumsmemories", new[] { "AMMemory" });
            DropIndex("dbo.albumsmemories", new[] { "AMAlbum" });
            DropIndex("dbo.sessionsalbums", new[] { "SAAlbum" });
            DropIndex("dbo.sessionsalbums", new[] { "SASession" });
            DropIndex("dbo.timelinesmemories", new[] { "TMMemory" });
            DropIndex("dbo.timelinesmemories", new[] { "TMTimeline" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.sessions", new[] { "SessionTarget" });
            DropIndex("dbo.sessions", new[] { "SessionCreator" });
            DropIndex("dbo.timelines", new[] { "TimelineUser" });
            DropIndex("dbo.memories", new[] { "MemoryTarget" });
            DropIndex("dbo.memories", new[] { "MemoryCreator" });
            DropIndex("dbo.IdentityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.albums", new[] { "AlbumTarget" });
            DropIndex("dbo.albums", new[] { "AlbumCreator" });
            DropTable("dbo.albumsmemories");
            DropTable("dbo.sessionsalbums");
            DropTable("dbo.timelinesmemories");
            DropTable("dbo.trustees");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.sessions");
            DropTable("dbo.timelines");
            DropTable("dbo.memories");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.albums");
        }
    }
}
