namespace TicketSystem.DTOs
{
    public class Usuarios
    {
        public List<Usuario> lista_usuarios { get; set; }

        public Usuarios()
        {

            lista_usuarios = new List<Usuario>
            {
                new Usuario
                {
                    nombre = "Cris", 
                    apellido = "Morales", 
                    nombre_usuario  = "cmorales",
                    password = "Cris123@",
                    isAdmin = true,
                },
                new Usuario
                {
                    nombre = "Juan",
                    apellido = "Lopez", 
                    nombre_usuario = "jlopez", 
                    password = "Juan123@",
                    isAdmin = false,
                }
            };

        }
    }
}
