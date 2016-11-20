namespace Eventify.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNotificationStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.notification", "notificationStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.notification", "notificationStatus");
        }
    }
}
