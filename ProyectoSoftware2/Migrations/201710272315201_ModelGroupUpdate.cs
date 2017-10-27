namespace ProyectoSoftware2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelGroupUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupoes", "REFERENCIA_GRUPO", c => c.String(nullable: false));
            DropColumn("dbo.Grupoes", "GRUPO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grupoes", "GRUPO", c => c.String(nullable: false));
            DropColumn("dbo.Grupoes", "REFERENCIA_GRUPO");
        }
    }
}
