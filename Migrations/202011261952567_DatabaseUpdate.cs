namespace ExamenMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Employees", "Version", c => c.Decimal());
            DropColumn("dbo.Employees", "Version");
            AddColumn("dbo.Employees", "Version", c => c.Decimal());
        }
        
        public override void Down()
        {
        }
    }
}
