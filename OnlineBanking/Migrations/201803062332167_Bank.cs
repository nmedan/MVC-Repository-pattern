namespace OnlineBanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bank : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Racuns", "BrojRacuna", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Racuns", "BrojRacuna", c => c.String());
        }
    }
}
