using System.ComponentModel.DataAnnotations;
namespace olxapi.Models
{
    public class Ad
    {     
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int State { get; set; }

    [Required]
    public int Category { get; set; }

    [Required]
    public int dateCreated { get; set; }

    [Required(ErrorMessage = "O título do anúncio é obrigatório")]
    [StringLength(50, ErrorMessage = "O título do anúncio não pode exceder 50 caracteres")]
    public String? Title { get; set; }

    [Required(ErrorMessage = "O preço do anúncio é obrigatório")]
    public int Price { get; set; }

    [Required]
    public Boolean? PriceNegotiable { get; set; }

    [Required]//description
    [StringLength(500, ErrorMessage = "A descrição do anúncio não pode exceder 500 caracteres")]
    public String? Description { get; set; }

    [Required]
    public int Views { get; set; }

    [Required] //status
    public String? Status { get; set; }
    }
}