namespace Eventify.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSocialNetworksToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.user", "fblink", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AddColumn("dbo.user", "twitterlink", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.user", "twitterlink");
            DropColumn("dbo.user", "fblink");
        }
    }
}
