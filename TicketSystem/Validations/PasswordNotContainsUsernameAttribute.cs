using System.ComponentModel.DataAnnotations;
using TicketSystem.DTOs; 


namespace TicketSystem.Validations
{
    public class PasswordNotContainsUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value, 
            ValidationContext validationContext 
        )
        {
            string? nombreUsuario = null; 
            //Obtener el usuario (validar) 
            if(validationContext.ObjectInstance is Usuario usuario)
            {
                nombreUsuario = usuario.nombre_usuario;
            } else if (validationContext.ObjectInstance is Login login)
            {
                nombreUsuario = login.nombre_usuario;
            }
            

            //Obtener la contraseña
            string? password = value?.ToString();

            if ( string.IsNullOrEmpty(password) ||
                 string.IsNullOrEmpty(nombreUsuario)
            )
            {
                return ValidationResult.Success;
            }

            if (password.Contains(nombreUsuario, StringComparison.OrdinalIgnoreCase)){
                return new ValidationResult(
                        "La contraseña no puede contener el nombre de usuario"
                    );
            }

            return ValidationResult.Success;
            
        }
    }
}
