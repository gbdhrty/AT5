using System.ComponentModel.DataAnnotations;

namespace AT5.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "O nome não pode ficar em branco.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail não pode ficar em branco.")]
        [EmailAddress(ErrorMessage = "Formato inválido de e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento não pode ficar em branco.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataNaoFutura(ErrorMessage = "A data não pode ser no futuro.")]
        public DateTime DataNascimento { get; set; }
    }

    public class DataNaoFuturaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime data)
            {
                return data <= DateTime.Now;
            }
            return false;
        }
    }
}
