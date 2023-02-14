using System.ComponentModel.DataAnnotations;
namespace FilmesApi.Dtos
{
    public class ReadFilmeDto
    {
    public String? Titulo { get; set; }

    public int Duracao { get; set; }

    public String? Diretor { get; set; }

    public String? Genero { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}