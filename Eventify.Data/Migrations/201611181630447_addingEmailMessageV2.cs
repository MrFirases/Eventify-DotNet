namespace Eventify.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingEmailMessageV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.message", "email", c => c.String(maxLength: 255, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.message", "email", c => c.String(unicode: false));
        }
    }
}
