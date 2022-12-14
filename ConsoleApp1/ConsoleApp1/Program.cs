using master.Controllers;
using master.Models;
using master.UsuarioController;

class Program
{
    static void Main(string[] args)
    {
        // a) Traer usuario
        Console.WriteLine("Ingrese Nombre de Usuario: ");
        string NombreUsuario = Console.ReadLine();
        var lisUsuario = UsuarioController.TraerUsuario(NombreUsuario);
        foreach(Usuario usu in lisUsuario)
        {
            Console.WriteLine("Id de usuario: {0}", usu.Id);
            Console.WriteLine("Nombre: {0}", usu.Nombre);
            Console.WriteLine("Apellido: {0}", usu.Apellido);
            Console.WriteLine("NombreUsuario: {0}", usu.NombreUsuario);
            Console.WriteLine("Contraseña: {0}", usu.Contraseña);
            Console.WriteLine("Mail: {0}", usu.Mail);
            Console.WriteLine("--------------\n");
        }

        // b) Traer productos cargados por un usuario
        Console.WriteLine("Ingrese codigo de usuario: ");
        int idUsuario = Convert.ToInt32(Console.ReadLine());
        var listaProducto = ProductoController.TraerProducto(idUsuario);
        foreach(Producto prod in listaProducto)
        {
            Console.WriteLine(prod.Descripciones);
        }
        Console.WriteLine("--------------\n");
        
        // c) Traer productos vendidos
        Console.WriteLine("Ingrese nombre de usuario: ");
        string nomDeUsuario = Console.ReadLine().ToString();
        var prodVentidosPorUsuario = ProdVendidoController.ProdutoVendido(nomDeUsuario);
        foreach (var prdVenUsu in prodVentidosPorUsuario)
        {
            Console.WriteLine(prdVenUsu.Descripciones);
        }
        Console.WriteLine("--------------\n");

        
        // d) Traer Ventas
        Console.WriteLine("\nIngrese codigo de usuario: ");
        int idUsuario2 = Convert.ToInt32(Console.ReadLine());
        var ventas = VentaController.TraerVentas(idUsuario2);
        foreach(Venta ven in ventas)
        {
            Console.WriteLine("Venta nro: {0}", ven.Id);
        }
        Console.WriteLine("--------------\n");

        // e) Inicio de Sesion
        Console.WriteLine("---- Iniciar Sesión: ----");
        Console.WriteLine("Nombre de uuario");
        string nombreDeUsuario = Console.ReadLine();
        Console.WriteLine("Contraseña");
        string contraseña = Console.ReadLine();
        var inicioSesion = InicioSesionController.InicioSesion(nombreDeUsuario, contraseña);
               
        Console.WriteLine("Id de usuario: {0}", inicioSesion.Id);
        Console.WriteLine("Nombre: {0}", inicioSesion.Nombre);
        Console.WriteLine("Apellido: {0}", inicioSesion.Apellido);
        Console.WriteLine("NombreUsuario: {0}", inicioSesion.NombreUsuario);
        Console.WriteLine("Contraseña: {0}", inicioSesion.Contraseña);
        Console.WriteLine("Mail: {0}", inicioSesion.Mail);
        Console.WriteLine("--------------\n");
    }
}