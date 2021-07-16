using System.ComponentModel.DataAnnotations;

namespace ExemploApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve só pode conter de 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora só pode conter de 3 e 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço mínimo é de 1 real e o máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
