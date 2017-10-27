namespace ProyectoSoftware2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AreaXProfesors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfesorId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Profesors", t => t.ProfesorId, cascadeDelete: true)
                .Index(t => t.ProfesorId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        P_APELLIDO = c.String(nullable: false),
                        S_APELLIDO = c.String(nullable: false),
                        NOMBRES = c.String(nullable: false),
                        DIRECCION = c.String(),
                        TELEFONO = c.String(nullable: false),
                        SEXO = c.String(nullable: false),
                        FECHA_INICIO = c.DateTime(nullable: false),
                        FECHA_FIN = c.DateTime(nullable: false),
                        DEPARTAMENTO = c.String(nullable: false),
                        EMAIL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HorarioDesfavorableProfesors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CEDULADOCENTE = c.String(nullable: false),
                        DIA = c.String(nullable: false),
                        HORA = c.Int(nullable: false),
                        DURACION = c.Int(nullable: false),
                        Profesor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profesors", t => t.Profesor_Id)
                .Index(t => t.Profesor_Id);
            
            CreateTable(
                "dbo.ProfesorXGrupoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfesorId = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                        HorasDictadas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupoes", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.Profesors", t => t.ProfesorId, cascadeDelete: true)
                .Index(t => t.ProfesorId)
                .Index(t => t.GrupoId);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CODIGOMATERIA = c.String(nullable: false),
                        ANO = c.String(nullable: false),
                        PERIODO = c.String(nullable: false),
                        GRUPO = c.String(nullable: false),
                        CUPO = c.Int(nullable: false),
                        FECHA_INICIO = c.DateTime(nullable: false),
                        FECHA_FINAL = c.DateTime(nullable: false),
                        CUPO_LINEA = c.Int(nullable: false),
                        INICIO_INSCRIPCION = c.DateTime(nullable: false),
                        FIN_INSCRIPCION = c.DateTime(nullable: false),
                        FIN_CANCELACION = c.DateTime(nullable: false),
                        FECHA_CREACION = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstudianteXGrupoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstudianteId = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estudiantes", t => t.EstudianteId, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.GrupoId, cascadeDelete: true)
                .Index(t => t.EstudianteId)
                .Index(t => t.GrupoId);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CODIGO = c.String(nullable: false),
                        CARRERA = c.String(nullable: false),
                        PENSUM = c.String(nullable: false),
                        NOMBRE = c.String(nullable: false),
                        P_APELLIDO = c.String(nullable: false),
                        S_APELLIDO = c.String(nullable: false),
                        TELEFONO = c.String(nullable: false),
                        SEMESTRE_INGRES = c.String(nullable: false),
                        SEM_ACADEMICO = c.String(nullable: false),
                        SEXO = c.String(nullable: false),
                        ESTADO = c.String(nullable: false),
                        DOCUMENTO = c.String(nullable: false),
                        TIPO_DOCUMENTO = c.String(nullable: false),
                        EMAIL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstudianteXMaterias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ESTUDIANTEID = c.String(nullable: false),
                        MATERIAID = c.String(nullable: false),
                        GRUPO = c.String(nullable: false),
                        DEFINITIVA = c.Double(nullable: false),
                        HABILITACION = c.String(),
                        RECUPERATORIO = c.String(),
                        FINAL = c.Double(nullable: false),
                        FALLAS = c.Int(nullable: false),
                        PERIODO = c.String(nullable: false),
                        ANO = c.String(nullable: false),
                        Estudiante_Id = c.Int(),
                        Materia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estudiantes", t => t.Estudiante_Id)
                .ForeignKey("dbo.Materias", t => t.Materia_Id)
                .Index(t => t.Estudiante_Id)
                .Index(t => t.Materia_Id);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NOMBRE = c.String(nullable: false),
                        HORAS_TEO = c.Int(nullable: false),
                        HORAS_PRAC = c.Int(nullable: false),
                        H_NOPRESEN = c.Int(nullable: false),
                        DEPARTAMENTO = c.String(nullable: false),
                        CREDITOS = c.Int(nullable: false),
                        MODALIDAD = c.String(nullable: false),
                        CUPO = c.Int(nullable: false),
                        ABIERTA = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MateriaXPrerequisitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MateriaId = c.Int(nullable: false),
                        PreRequisitoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materias", t => t.MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.PreRequisitoes", t => t.PreRequisitoId, cascadeDelete: true)
                .Index(t => t.MateriaId)
                .Index(t => t.PreRequisitoId);
            
            CreateTable(
                "dbo.PreRequisitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PENSUM = c.String(nullable: false),
                        CODIGOMATERIA = c.String(nullable: false),
                        CODIGOMATERIA_PRE = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SolicitudEstudianteMaterias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstudianteId = c.Int(nullable: false),
                        MateriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estudiantes", t => t.EstudianteId, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.MateriaId, cascadeDelete: true)
                .Index(t => t.EstudianteId)
                .Index(t => t.MateriaId);
            
            CreateTable(
                "dbo.HorarioGrupoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CODIGOMATERIA = c.String(nullable: false),
                        ANO = c.String(nullable: false),
                        PERIODO = c.String(nullable: false),
                        GRUPO = c.String(nullable: false),
                        DIA = c.String(nullable: false),
                        HORA = c.Int(nullable: false),
                        DURACION = c.Int(nullable: false),
                        AULA = c.String(nullable: false),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupoes", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.Bloques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        BloqueId = c.Int(nullable: false),
                        VideoBeam = c.Boolean(nullable: false),
                        Televisor = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bloques", t => t.BloqueId, cascadeDelete: true)
                .Index(t => t.BloqueId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Salas", "BloqueId", "dbo.Bloques");
            DropForeignKey("dbo.ProfesorXGrupoes", "ProfesorId", "dbo.Profesors");
            DropForeignKey("dbo.ProfesorXGrupoes", "GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.HorarioGrupoes", "Group_Id", "dbo.Grupoes");
            DropForeignKey("dbo.EstudianteXGrupoes", "GrupoId", "dbo.Grupoes");
            DropForeignKey("dbo.SolicitudEstudianteMaterias", "MateriaId", "dbo.Materias");
            DropForeignKey("dbo.SolicitudEstudianteMaterias", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.MateriaXPrerequisitoes", "PreRequisitoId", "dbo.PreRequisitoes");
            DropForeignKey("dbo.MateriaXPrerequisitoes", "MateriaId", "dbo.Materias");
            DropForeignKey("dbo.EstudianteXMaterias", "Materia_Id", "dbo.Materias");
            DropForeignKey("dbo.EstudianteXMaterias", "Estudiante_Id", "dbo.Estudiantes");
            DropForeignKey("dbo.EstudianteXGrupoes", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.HorarioDesfavorableProfesors", "Profesor_Id", "dbo.Profesors");
            DropForeignKey("dbo.AreaXProfesors", "ProfesorId", "dbo.Profesors");
            DropForeignKey("dbo.AreaXProfesors", "AreaId", "dbo.Areas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Salas", new[] { "BloqueId" });
            DropIndex("dbo.HorarioGrupoes", new[] { "Group_Id" });
            DropIndex("dbo.SolicitudEstudianteMaterias", new[] { "MateriaId" });
            DropIndex("dbo.SolicitudEstudianteMaterias", new[] { "EstudianteId" });
            DropIndex("dbo.MateriaXPrerequisitoes", new[] { "PreRequisitoId" });
            DropIndex("dbo.MateriaXPrerequisitoes", new[] { "MateriaId" });
            DropIndex("dbo.EstudianteXMaterias", new[] { "Materia_Id" });
            DropIndex("dbo.EstudianteXMaterias", new[] { "Estudiante_Id" });
            DropIndex("dbo.EstudianteXGrupoes", new[] { "GrupoId" });
            DropIndex("dbo.EstudianteXGrupoes", new[] { "EstudianteId" });
            DropIndex("dbo.ProfesorXGrupoes", new[] { "GrupoId" });
            DropIndex("dbo.ProfesorXGrupoes", new[] { "ProfesorId" });
            DropIndex("dbo.HorarioDesfavorableProfesors", new[] { "Profesor_Id" });
            DropIndex("dbo.AreaXProfesors", new[] { "AreaId" });
            DropIndex("dbo.AreaXProfesors", new[] { "ProfesorId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Salas");
            DropTable("dbo.Bloques");
            DropTable("dbo.HorarioGrupoes");
            DropTable("dbo.SolicitudEstudianteMaterias");
            DropTable("dbo.PreRequisitoes");
            DropTable("dbo.MateriaXPrerequisitoes");
            DropTable("dbo.Materias");
            DropTable("dbo.EstudianteXMaterias");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.EstudianteXGrupoes");
            DropTable("dbo.Grupoes");
            DropTable("dbo.ProfesorXGrupoes");
            DropTable("dbo.HorarioDesfavorableProfesors");
            DropTable("dbo.Profesors");
            DropTable("dbo.AreaXProfesors");
            DropTable("dbo.Areas");
        }
    }
}
