using master.Controllers;
using master.Models;
using master.UsuarioController;

class Program
{
    static void Main(string[] args)
    {
        // Traer usuario
        Console.WriteLine("Ingrese Nombre de Usuario: ");
        string NombreUsuario = Console.ReadLine();
        var lisUsuario = UsuarioController.TraerUsuario(NombreUsuario);
        foreach(Usuario usu in lisUsuario)
        {
            Console.WriteLine(usu.Id);
            Console.WriteLine("Nombre: {0}", usu.Nombre);
            Console.WriteLine("Apellido: {0}", usu.Apellido);
            Console.WriteLine("NombreUsuario: {0}", usu.NombreUsuario);
            Console.WriteLine("Contraseña: {0}", usu.Contraseña);
            Console.WriteLine("Mail: {0}", usu.Mail);
            Console.WriteLine("--------------\n");
        }

        // Traer productos cargados por un usuario
        Console.WriteLine("Ingrese codigo de usuario: ");
        int idUsuario = Convert.ToInt32(Console.ReadLine());
        var listaProducto = ProductoController.TraerProducto(idUsuario);
        foreach(Producto prod in listaProducto)
        {
            Console.WriteLine(prod.Descripciones);
        }


        /*

        Console.WriteLine("\n\nc) Traer Productos Vendidos: Traer Todos los productos vendidos " +
            "de un Usuario, cuya información está en su producto (Utilizar dentro de esta función " +
            "el Traer Productos anteriormente hecho para saber que productosVendidos ir a buscar).\n");


        Console.WriteLine("\n\nd) Traer Ventas: Recibe como parámetro un IdUsuario, " +
            "debe traer todas las ventas de la base asignados al usuario particular.");


        Console.WriteLine("\n\nInicio de sesión: Se le pase como parámetro el nombre " +
            "del usuario y la contraseña, buscar en la base de datos si el usuario existe " +
            "y si coincide con la contraseña lo devuelve (el objeto Usuario), " +
            "caso contrario devuelve uno vacío (Con sus datos vacíos y el id en 0).");
        */

    }
}