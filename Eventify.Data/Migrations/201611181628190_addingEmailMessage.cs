namespace Eventify.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingEmailMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message", "email", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.message", "email");
        }
    }
}
