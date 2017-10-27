using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoSoftware2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.Area> Areas { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.Profesor> Profesors { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.AreaXProfesor> AreaXProfesors { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.Sala> Salas { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.Bloque> Bloques { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.Materia> Materias { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.Estudiante> Estudiantes { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.EstudianteXMateria> EstudianteXMaterias { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.Grupo> Grupoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.HorarioDesfavorableProfesor> HorarioDesfavorableProfesors { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.HorarioGrupo> HorarioGrupoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.MateriaXPrerequisito> MateriaXPrerequisitoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.PreRequisito> PreRequisitoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.ProfesorXGrupo> ProfesorXGrupoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.EstudianteXGrupo> EstudianteXGrupoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoSoftware2.Models.SolicitudEstudianteMateria> SolicitudEstudianteMaterias { get; set; }
    }
}