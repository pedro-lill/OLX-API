using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class UpdateFilmeDto
{   
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O título do filme não pode exceder 50 caracteres")]
    public String? Titulo { get; set; }

    [Range(60, 600, ErrorMessage = "A duração deve ter no mínimo 60 e no máximo 600 minutos")]
    [Required (ErrorMessage = "O campo duração é obrigatório")]
    public int Duracao { get; set; }

    [StringLength(50, MinimumLength = 2, ErrorMessage = "O diretor deve ter no mínimo 2 e no máximo 50 caracteres")]
    public String? Diretor { get; set; }

    [StringLength(30, MinimumLength = 2, ErrorMessage = "O gênero deve ter no mínimo 2 e no máximo 30 caracteres")]
    [Required(ErrorMessage = "O campo gênero é obrigatório")]
    public String? Genero { get; set; }
    
}