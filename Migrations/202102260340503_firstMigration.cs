namespace CaloryCounterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        dietId = c.Int(nullable: false, identity: true),
                        dateDiet = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.dietId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        foodId = c.Int(nullable: false, identity: true),
                        foodName = c.String(),
                        foodWeight = c.Int(nullable: false),
                        calory = c.Int(nullable: false),
                        foodType = c.String(),
                    })
                .PrimaryKey(t => t.foodId);
            
            CreateTable(
                "dbo.Foodxdiets",
                c => new
                    {
                        FdId = c.Int(nullable: false, identity: true),
                        dietId = c.Int(nullable: false),
                        foodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FdId)
                .ForeignKey("dbo.Diets", t => t.dietId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.foodId, cascadeDelete: true)
                .Index(t => t.dietId)
                .Index(t => t.foodId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lname = c.String(),
                        age = c.Int(nullable: false),
                        gender = c.String(),
                        userHeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserWeights",
                c => new
                    {
                        weightId = c.Int(nullable: false, identity: true),
                        date = c.String(),
                        numberweight = c.Int(nullable: false),
                        weight = c.Double(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.weightId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWeights", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Diets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Foodxdiets", "foodId", "dbo.Foods");
            DropForeignKey("dbo.Foodxdiets", "dietId", "dbo.Diets");
            DropIndex("dbo.UserWeights", new[] { "User_Id" });
            DropIndex("dbo.Foodxdiets", new[] { "foodId" });
            DropIndex("dbo.Foodxdiets", new[] { "dietId" });
            DropIndex("dbo.Diets", new[] { "User_Id" });
            DropTable("dbo.UserWeights");
            DropTable("dbo.Users");
            DropTable("dbo.Foodxdiets");
            DropTable("dbo.Foods");
            DropTable("dbo.Diets");
        }
    }
}
