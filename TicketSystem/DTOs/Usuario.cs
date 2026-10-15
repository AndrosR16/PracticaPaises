using System.ComponentModel.DataAnnotations;
using TicketSystem.Validations;

namespace TicketSystem.DTOs
{
    public class Usuario
    {
        [Required(ErrorMessage ="El nombre es un campo requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es un campo requerido")]
        public string apellido { get; set; }

        [Required(ErrorMessage ="El nombre de usuario es requerido")]
        public string nombre_usuario { get; set; }

        [Required(ErrorMessage ="La contraseña es requerida")]
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

        [Required(ErrorMessage = "El role del usuario es necesario")]
        public bool isAdmin { get; set; }
    }
}
