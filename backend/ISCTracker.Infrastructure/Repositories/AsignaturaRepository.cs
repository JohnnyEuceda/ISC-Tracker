using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISCTracker.Application.Interfaces;
using ISCTracker.Domain.Entities;
using ISCTracker.Infrastructure.Data;

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

    public async Task<Asignatura> AddAsync(Asignatura asignatura)
    {
        await _context.Asignaturas.AddAsync(asignatura);
        await _context.SaveChangesAsync();
        return asignatura;
    }
}
