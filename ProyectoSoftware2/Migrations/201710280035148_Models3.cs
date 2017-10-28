namespace ProyectoSoftware2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SolicitudEstudianteMaterias", "Materia_Id", "dbo.Materias");
            DropIndex("dbo.SolicitudEstudianteMaterias", new[] { "Materia_Id" });
            RenameColumn(table: "dbo.SolicitudEstudianteMaterias", name: "Materia_Id", newName: "MateriaId");
            AlterColumn("dbo.SolicitudEstudianteMaterias", "MateriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.SolicitudEstudianteMaterias", "MateriaId");
            AddForeignKey("dbo.SolicitudEstudianteMaterias", "MateriaId", "dbo.Materias", "Id", cascadeDelete: true);
            DropColumn("dbo.SolicitudEstudianteMaterias", "NombreMateria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SolicitudEstudianteMaterias", "NombreMateria", c => c.Int(nullable: false));
            DropForeignKey("dbo.SolicitudEstudianteMaterias", "MateriaId", "dbo.Materias");
            DropIndex("dbo.SolicitudEstudianteMaterias", new[] { "MateriaId" });
            AlterColumn("dbo.SolicitudEstudianteMaterias", "MateriaId", c => c.Int());
            RenameColumn(table: "dbo.SolicitudEstudianteMaterias", name: "MateriaId", newName: "Materia_Id");
            CreateIndex("dbo.SolicitudEstudianteMaterias", "Materia_Id");
            AddForeignKey("dbo.SolicitudEstudianteMaterias", "Materia_Id", "dbo.Materias", "Id");
        }
    }
}
