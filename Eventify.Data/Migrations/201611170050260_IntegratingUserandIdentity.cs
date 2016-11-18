namespace Eventify.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegratingUserandIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.answer",
                c => new
                    {
                        idAttribut = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        answer = c.String(maxLength: 255, storeType: "nvarchar"),
                        dateAnswer = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => new { t.idAttribut, t.idUser })
                .ForeignKey("dbo.attribut", t => t.idAttribut, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idAttribut)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.attribut",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        attributValue = c.String(maxLength: 255, storeType: "nvarchar"),
                        duplicated = c.Boolean(nullable: false),
                        questions_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.question", t => t.questions_id)
                .Index(t => t.questions_id);
            
            CreateTable(
                "dbo.question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        order = c.Int(),
                        questionCategory = c.String(maxLength: 255, storeType: "nvarchar"),
                        questionDate = c.DateTime(precision: 0),
                        questionDescription = c.String(maxLength: 255, storeType: "nvarchar"),
                        questionType = c.String(maxLength: 255, storeType: "nvarchar"),
                        status = c.Int(nullable: false),
                        event_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.myevent", t => t.event_id)
                .Index(t => t.event_id);
            
            CreateTable(
                "dbo.myevent",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        createdAt = c.DateTime(precision: 0),
                        endTime = c.DateTime(precision: 0),
                        eventState = c.String(maxLength: 255, storeType: "nvarchar"),
                        eventType = c.String(maxLength: 255, storeType: "nvarchar"),
                        facebookLink = c.String(maxLength: 255, storeType: "nvarchar"),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        nbViews = c.Int(nullable: false),
                        placeNumber = c.Int(nullable: false),
                        startTime = c.DateTime(precision: 0),
                        theme = c.String(maxLength: 255, storeType: "nvarchar"),
                        title = c.String(maxLength: 255, storeType: "nvarchar"),
                        twitterLink = c.String(maxLength: 255, storeType: "nvarchar"),
                        category_id = c.Int(),
                        organization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.category", t => t.category_id)
                .ForeignKey("dbo.organization", t => t.organization_id)
                .Index(t => t.category_id)
                .Index(t => t.organization_id);
            
            CreateTable(
                "dbo.category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.favorite",
                c => new
                    {
                        categoryId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.categoryId, t.userId })
                .ForeignKey("dbo.category", t => t.categoryId, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.userId, cascadeDelete: true)
                .Index(t => t.categoryId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        accountState = c.String(maxLength: 255, storeType: "nvarchar"),
                        confirmationToken = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        creationDate = c.DateTime(precision: 0),
                        email = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        firstName = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        lastName = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        loyaltyPoint = c.Int(nullable: false),
                        banState = c.Int(nullable: false),
                        numTel = c.String(maxLength: 255, storeType: "nvarchar"),
                        password = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        profileImage = c.String(maxLength: 255, storeType: "nvarchar"),
                        username = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        country = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        EmalIdentity = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Login = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.comment",
                c => new
                    {
                        idEvent = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        contain = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.idEvent, t.idUser })
                .ForeignKey("dbo.myevent", t => t.idEvent, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idEvent)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(unicode: false),
                        ProviderKey = c.String(unicode: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.message",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        claim = c.Boolean(nullable: false),
                        date = c.DateTime(precision: 0),
                        message = c.String(maxLength: 255, storeType: "nvarchar"),
                        sended = c.Boolean(nullable: false),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.notification",
                c => new
                    {
                        id = c.Int(nullable: false),
                        notificationDate = c.DateTime(precision: 0),
                        notificationDescription = c.String(maxLength: 255, storeType: "nvarchar"),
                        notificationTitle = c.String(maxLength: 255, storeType: "nvarchar"),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.organization",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        creationDate = c.DateTime(precision: 0),
                        organizationName = c.String(maxLength: 255, storeType: "nvarchar"),
                        organizationType = c.String(maxLength: 255, storeType: "nvarchar"),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.organizer",
                c => new
                    {
                        idOrganization = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        state = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.idOrganization, t.idUser })
                .ForeignKey("dbo.organization", t => t.idOrganization, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idOrganization)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.task",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        createdAt = c.DateTime(precision: 0),
                        taskDescription = c.String(maxLength: 255, storeType: "nvarchar"),
                        taskStatus = c.Int(nullable: false),
                        taskTitle = c.String(maxLength: 255, storeType: "nvarchar"),
                        event_id = c.Int(),
                        organizer_idOrganization = c.Int(),
                        organizer_idUser = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.myevent", t => t.event_id)
                .ForeignKey("dbo.organizer", t => new { t.organizer_idOrganization, t.organizer_idUser })
                .Index(t => t.event_id)
                .Index(t => new { t.organizer_idOrganization, t.organizer_idUser });
            
            CreateTable(
                "dbo.rate",
                c => new
                    {
                        idEvent = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        note = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.idEvent, t.idUser })
                .ForeignKey("dbo.myevent", t => t.idEvent, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idEvent)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.referreluser",
                c => new
                    {
                        idUserReferral = c.Int(nullable: false),
                        idUserReferred = c.Int(nullable: false),
                        dateInvitation = c.DateTime(precision: 0),
                        stateInvitation = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.idUserReferral, t.idUserReferred })
                .ForeignKey("dbo.user", t => t.idUserReferred, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.idUserReferral, cascadeDelete: true)
                .Index(t => t.idUserReferral)
                .Index(t => t.idUserReferred);
            
            CreateTable(
                "dbo.report",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(maxLength: 255, storeType: "nvarchar"),
                        reportDate = c.DateTime(precision: 0),
                        state = c.Int(nullable: false),
                        subject = c.String(maxLength: 255, storeType: "nvarchar"),
                        event_id = c.Int(),
                        user_id = c.Int(),
                        userWhoReport_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.myevent", t => t.event_id)
                .ForeignKey("dbo.user", t => t.userWhoReport_id)
                .ForeignKey("dbo.user", t => t.user_id)
                .Index(t => t.event_id)
                .Index(t => t.user_id)
                .Index(t => t.userWhoReport_id);
            
            CreateTable(
                "dbo.reservation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amount = c.Single(nullable: false),
                        paymentMethod = c.String(maxLength: 255, storeType: "nvarchar"),
                        reservationDate = c.DateTime(precision: 0),
                        reservationState = c.String(maxLength: 255, storeType: "nvarchar"),
                        timerState = c.String(maxLength: 255, storeType: "nvarchar"),
                        ticket_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ticket", t => t.ticket_id)
                .ForeignKey("dbo.user", t => t.user_id)
                .Index(t => t.ticket_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.ticket",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        backgroundImage = c.String(maxLength: 255, storeType: "nvarchar"),
                        nbTickets = c.Int(nullable: false),
                        priceTicket = c.Single(nullable: false),
                        typeTicket = c.String(maxLength: 255, storeType: "nvarchar"),
                        event_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.myevent", t => t.event_id)
                .Index(t => t.event_id);
            
            CreateTable(
                "dbo.transaction",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amount = c.Single(nullable: false),
                        token = c.String(maxLength: 255, storeType: "nvarchar"),
                        reservation_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.reservation", t => t.reservation_id)
                .Index(t => t.reservation_id);
            
            CreateTable(
                "dbo.MyUserRoles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        MyRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.MyRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.MyRole_Id);
            
            CreateTable(
                "dbo.wishlist",
                c => new
                    {
                        eventId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateAdding = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => new { t.eventId, t.userId })
                .ForeignKey("dbo.myevent", t => t.eventId, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.userId, cascadeDelete: true)
                .Index(t => t.eventId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.mymedia",
                c => new
                    {
                        id = c.Int(nullable: false),
                        mediaDate = c.DateTime(precision: 0),
                        pathMedia = c.String(maxLength: 255, storeType: "nvarchar"),
                        typeMedia = c.String(maxLength: 255, storeType: "nvarchar"),
                        event_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.myevent", t => t.event_id)
                .Index(t => t.event_id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyUserRoles", "MyRole_Id", "dbo.Role");
            DropForeignKey("dbo.answer", "idUser", "dbo.user");
            DropForeignKey("dbo.answer", "idAttribut", "dbo.attribut");
            DropForeignKey("dbo.attribut", "questions_id", "dbo.question");
            DropForeignKey("dbo.question", "event_id", "dbo.myevent");
            DropForeignKey("dbo.myevent", "organization_id", "dbo.organization");
            DropForeignKey("dbo.mymedia", "event_id", "dbo.myevent");
            DropForeignKey("dbo.myevent", "category_id", "dbo.category");
            DropForeignKey("dbo.favorite", "userId", "dbo.user");
            DropForeignKey("dbo.wishlist", "userId", "dbo.user");
            DropForeignKey("dbo.wishlist", "eventId", "dbo.myevent");
            DropForeignKey("dbo.MyUserRoles", "UserId", "dbo.user");
            DropForeignKey("dbo.reservation", "user_id", "dbo.user");
            DropForeignKey("dbo.transaction", "reservation_id", "dbo.reservation");
            DropForeignKey("dbo.reservation", "ticket_id", "dbo.ticket");
            DropForeignKey("dbo.ticket", "event_id", "dbo.myevent");
            DropForeignKey("dbo.report", "user_id", "dbo.user");
            DropForeignKey("dbo.report", "userWhoReport_id", "dbo.user");
            DropForeignKey("dbo.report", "event_id", "dbo.myevent");
            DropForeignKey("dbo.referreluser", "idUserReferral", "dbo.user");
            DropForeignKey("dbo.referreluser", "idUserReferred", "dbo.user");
            DropForeignKey("dbo.rate", "idUser", "dbo.user");
            DropForeignKey("dbo.rate", "idEvent", "dbo.myevent");
            DropForeignKey("dbo.organization", "user_id", "dbo.user");
            DropForeignKey("dbo.organizer", "idUser", "dbo.user");
            DropForeignKey("dbo.task", new[] { "organizer_idOrganization", "organizer_idUser" }, "dbo.organizer");
            DropForeignKey("dbo.task", "event_id", "dbo.myevent");
            DropForeignKey("dbo.organizer", "idOrganization", "dbo.organization");
            DropForeignKey("dbo.notification", "user_id", "dbo.user");
            DropForeignKey("dbo.message", "user_id", "dbo.user");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.user");
            DropForeignKey("dbo.comment", "idUser", "dbo.user");
            DropForeignKey("dbo.comment", "idEvent", "dbo.myevent");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.user");
            DropForeignKey("dbo.favorite", "categoryId", "dbo.category");
            DropIndex("dbo.mymedia", new[] { "event_id" });
            DropIndex("dbo.wishlist", new[] { "userId" });
            DropIndex("dbo.wishlist", new[] { "eventId" });
            DropIndex("dbo.MyUserRoles", new[] { "MyRole_Id" });
            DropIndex("dbo.MyUserRoles", new[] { "UserId" });
            DropIndex("dbo.transaction", new[] { "reservation_id" });
            DropIndex("dbo.ticket", new[] { "event_id" });
            DropIndex("dbo.reservation", new[] { "user_id" });
            DropIndex("dbo.reservation", new[] { "ticket_id" });
            DropIndex("dbo.report", new[] { "userWhoReport_id" });
            DropIndex("dbo.report", new[] { "user_id" });
            DropIndex("dbo.report", new[] { "event_id" });
            DropIndex("dbo.referreluser", new[] { "idUserReferred" });
            DropIndex("dbo.referreluser", new[] { "idUserReferral" });
            DropIndex("dbo.rate", new[] { "idUser" });
            DropIndex("dbo.rate", new[] { "idEvent" });
            DropIndex("dbo.task", new[] { "organizer_idOrganization", "organizer_idUser" });
            DropIndex("dbo.task", new[] { "event_id" });
            DropIndex("dbo.organizer", new[] { "idUser" });
            DropIndex("dbo.organizer", new[] { "idOrganization" });
            DropIndex("dbo.organization", new[] { "user_id" });
            DropIndex("dbo.notification", new[] { "user_id" });
            DropIndex("dbo.message", new[] { "user_id" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.comment", new[] { "idUser" });
            DropIndex("dbo.comment", new[] { "idEvent" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.favorite", new[] { "userId" });
            DropIndex("dbo.favorite", new[] { "categoryId" });
            DropIndex("dbo.myevent", new[] { "organization_id" });
            DropIndex("dbo.myevent", new[] { "category_id" });
            DropIndex("dbo.question", new[] { "event_id" });
            DropIndex("dbo.attribut", new[] { "questions_id" });
            DropIndex("dbo.answer", new[] { "idUser" });
            DropIndex("dbo.answer", new[] { "idAttribut" });
            DropTable("dbo.Role");
            DropTable("dbo.mymedia");
            DropTable("dbo.wishlist");
            DropTable("dbo.MyUserRoles");
            DropTable("dbo.transaction");
            DropTable("dbo.ticket");
            DropTable("dbo.reservation");
            DropTable("dbo.report");
            DropTable("dbo.referreluser");
            DropTable("dbo.rate");
            DropTable("dbo.task");
            DropTable("dbo.organizer");
            DropTable("dbo.organization");
            DropTable("dbo.notification");
            DropTable("dbo.message");
            DropTable("dbo.UserLogin");
            DropTable("dbo.comment");
            DropTable("dbo.UserClaim");
            DropTable("dbo.user");
            DropTable("dbo.favorite");
            DropTable("dbo.category");
            DropTable("dbo.myevent");
            DropTable("dbo.question");
            DropTable("dbo.attribut");
            DropTable("dbo.answer");
        }
    }
}
