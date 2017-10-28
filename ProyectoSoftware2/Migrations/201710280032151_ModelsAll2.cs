namespace ProyectoSoftware2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsAll2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SolicitudEstudianteMaterias", "Estudiante_Id", c => c.Int());
            CreateIndex("dbo.SolicitudEstudianteMaterias", "Estudiante_Id");
            AddForeignKey("dbo.SolicitudEstudianteMaterias", "Estudiante_Id", "dbo.Estudiantes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SolicitudEstudianteMaterias", "Estudiante_Id", "dbo.Estudiantes");
            DropIndex("dbo.SolicitudEstudianteMaterias", new[] { "Estudiante_Id" });
            DropColumn("dbo.SolicitudEstudianteMaterias", "Estudiante_Id");
        }
    }
}
