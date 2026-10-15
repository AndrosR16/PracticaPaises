using System.ComponentModel.DataAnnotations;
using TicketSystem.Validations; 


namespace TicketSystem.DTOs
{
    public class Login
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string nombre_usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(
            50, //Cantidad Maxima de caracteres
            MinimumLength = 6,
            ErrorMessage = "La contraseña debe de tener minimo 6 caracteres"
        )]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$",
            ErrorMessage = "La contraseña debe contener al menos una letra mayuscula, una letra minuscula, un número y un carácter especial"
        )]
        [PasswordNotContainsUsernameAttribute]
        public string password { get; set; }
    }
}
