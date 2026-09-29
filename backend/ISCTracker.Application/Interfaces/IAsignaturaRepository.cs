using ISCTracker.Domain;

namespace ISCTracker.Application.Interfaces;

public interface IAsignaturaRepository
{
    Task<IEnumerable<Asignatura>> GetAllAsync();
}