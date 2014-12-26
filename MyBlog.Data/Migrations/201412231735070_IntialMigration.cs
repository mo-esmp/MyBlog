namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        ParentId = c.Int(),
                        IsEnabled = c.Boolean(nullable: false),
                        CreateDate = c.Boolean(nullable: false),
                        Content = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.ParentId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsEnabled = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 400),
                        Slug = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDte = c.DateTime(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Slug = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PostEntityTagEntity",
                c => new
                    {
                        PostEntity_Id = c.Int(nullable: false),
                        TagEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostEntity_Id, t.TagEntity_Id })
                .ForeignKey("dbo.Post", t => t.PostEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagEntity_Id, cascadeDelete: true)
                .Index(t => t.PostEntity_Id)
                .Index(t => t.TagEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PostEntityTagEntity", "TagEntity_Id", "dbo.Tag");
            DropForeignKey("dbo.PostEntityTagEntity", "PostEntity_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "ParentId", "dbo.Comment");
            DropIndex("dbo.PostEntityTagEntity", new[] { "TagEntity_Id" });
            DropIndex("dbo.PostEntityTagEntity", new[] { "PostEntity_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Comment", new[] { "ParentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropTable("dbo.PostEntityTagEntity");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tag");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
