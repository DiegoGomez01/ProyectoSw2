namespace ProyectoSoftware2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SolicitarCupoes", "CodEstudiante", c => c.Int(nullable: false));
            DropColumn("dbo.SolicitarCupoes", "CodigoEstudiante");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SolicitarCupoes", "CodigoEstudiante", c => c.Int(nullable: false));
            DropColumn("dbo.SolicitarCupoes", "CodEstudiante");
        }
    }
}
