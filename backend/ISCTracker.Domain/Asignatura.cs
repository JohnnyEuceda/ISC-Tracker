namespace ISCTracker.Domain;

public class Asignatura
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int UnidadesValorativas { get; set; }

    public int AreaAcademicaId { get; set; }
    public AreaAcademica AreaAcademica { get; set; } = null!;

    public int EstadoAsignaturaId { get; set; }
    public EstadoAsignatura EstadoAsignatura { get; set; } = null!;
}