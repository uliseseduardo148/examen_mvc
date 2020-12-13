﻿namespace ExamenMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.Employees",
                 c => new
                     {
                         Id = c.Int(nullable: false, identity: true),
                         EmployeeName = c.String(),
                         Position = c.String(),
                         Departament = c.String(),
                         Version = c.Binary(),
                     })
                 .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
