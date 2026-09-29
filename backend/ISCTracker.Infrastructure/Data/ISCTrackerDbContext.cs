using ISCTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISCTracker.Infrastructure.Data;

public class ISCTrackerDbContext : DbContext
{
    public ISCTrackerDbContext(DbContextOptions<ISCTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<AreaAcademica> AreasAcademicas { get; set; }
    public DbSet<EstadoAsignatura> EstadosAsignatura { get; set; }
    public DbSet<Asignatura> Asignaturas { get; set; }
}