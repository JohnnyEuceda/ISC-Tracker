using System.Collections.Generic;
using System.Threading.Tasks;
using ISCTracker.Domain.Entities;

namespace ISCTracker.Application.Interfaces;

public interface IAsignaturaRepository
{
    Task<IEnumerable<Asignatura>> GetAllAsync();
}
