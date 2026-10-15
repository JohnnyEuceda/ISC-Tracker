namespace ISCTracker.Domain.Entities;

public class EstadoAsignatura
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public ICollection<Asignatura> Asignaturas { get; set; }
        = new List<Asignatura>();
}
