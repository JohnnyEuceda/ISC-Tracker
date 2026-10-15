using Microsoft.EntityFrameworkCore;
using ISCTracker.Domain.Entities;

namespace ISCTracker.Infrastructure.Data;

public class ISCTrackerDbContext : DbContext
{
    public ISCTrackerDbContext(
        DbContextOptions<ISCTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<AreaAcademica> AreasAcademicas { get; set; } = null!;

    public DbSet<EstadoAsignatura> EstadosAsignaturas { get; set; } = null!;

    public DbSet<Asignatura> Asignaturas { get; set; } = null!;
}
