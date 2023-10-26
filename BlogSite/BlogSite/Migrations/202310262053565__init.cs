namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Yayindami", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "Icerik", c => c.String());
            AddColumn("dbo.Articles", "Yazar", c => c.String());
            AddColumn("dbo.Articles", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "RegisterDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Articles", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Description", c => c.String());
            DropColumn("dbo.Categories", "RegisterDate");
            DropColumn("dbo.Categories", "Deleted");
            DropColumn("dbo.Categories", "Active");
            DropColumn("dbo.Articles", "RegisterDate");
            DropColumn("dbo.Articles", "Deleted");
            DropColumn("dbo.Articles", "Active");
            DropColumn("dbo.Articles", "Yazar");
            DropColumn("dbo.Articles", "Icerik");
            DropColumn("dbo.Articles", "Yayindami");
        }
    }
}
