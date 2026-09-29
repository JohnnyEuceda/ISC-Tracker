using ISCTracker.Application.Interfaces;
using ISCTracker.Domain;
using ISCTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ISCTracker.Infrastructure.Repositories;

public class AsignaturaRepository : IAsignaturaRepository
{
    private readonly ISCTrackerDbContext _context;

    public AsignaturaRepository(ISCTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Asignatura>> GetAllAsync()
    {
        return await _context.Asignaturas.ToListAsync();
    }
}