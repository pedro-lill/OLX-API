using System.ComponentModel.DataAnnotations;
namespace olxapi.Models
{
    public class Anuncio
    {

        // titulo, descricao, preco, data de publicacao, data de validade, categoria, cidade, estado, email, telefone

        [Required(ErrorMessage = "O título do anúncio é obrigatório")]
        [MaxLength(50, ErrorMessage = "O título do anúncio não pode exceder 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição do anúncio é obrigatória")]
        [MaxLength(100, ErrorMessage = "A descrição do anúncio não pode exceder 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço do anúncio é obrigatório")]
        [Range(0, 1000000, ErrorMessage = "O preço do anúncio deve ser maior que 0 e menor que 1.000.000")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "A data de publicação do anúncio é obrigatória")]
        public string DataPublicacao { get; set; }

        [Required(ErrorMessage = "A data de validade do anúncio é obrigatória")]
        public string DataValidade { get; set; }
        

        [Required(ErrorMessage = "A categoria do anúncio é obrigatória")]
        [MaxLength(50, ErrorMessage = "A categoria do anúncio não pode exceder 50 caracteres")]
        public string Categoria { get; set; }


        [Required(ErrorMessage = "A cidade do anúncio é obrigatória")]
        [MaxLength(50, ErrorMessage = "A cidade do anúncio não pode exceder 50 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado do anúncio é obrigatório")]
        [MaxLength(50, ErrorMessage = "O estado do anúncio não pode exceder 50 caracteres")]
        public string Estado { get; set; }


        [Required(ErrorMessage = "O email do anúncio é obrigatório")]
        [MaxLength(50, ErrorMessage = "O email do anúncio não pode exceder 50 caracteres")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O telefone do anúncio é obrigatório")]
        [MaxLength(50, ErrorMessage = "O telefone do anúncio não pode exceder 50 caracteres")]
        public string Telefone { get; set; }
    }
}