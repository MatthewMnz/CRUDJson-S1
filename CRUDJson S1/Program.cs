using CRUDJson_S1.Services;
using CRUDJson_S1.Models;

namespace CRUDJson_S1
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDServices crudService = new CRUDServices();

            Console.WriteLine("CRUD con JSON");

            while (true)
            {
                // Menú principal que muestra las opciones disponibles
                Console.WriteLine("Opciones:");
                Console.WriteLine("1. Crear un usuario");
                Console.WriteLine("2. Leer usuarios");
                Console.WriteLine("3. Actualizar un usuario");
                Console.WriteLine("4. Eliminar un usuario");
                Console.WriteLine("5. Cerrar");
                Console.Write("Selecciona una opción: ");

                int opcion = int.Parse(Console.ReadLine() ?? "0");

                switch (opcion)
                {
                    case 1:
                        crudService.CrearUsuario(); // Crea un usuario nuevo
                        break;
                    case 2:
                        crudService.LeerUsuarios(); // Lista los usuarios existentes
                        break;
                    case 3:
                        crudService.ActualizarUsuario(); // Actualiza un usuario existente
                        break;
                    case 4:
                        crudService.EliminarUsuario(); // Elimina un usuario por su ID
                        break;
                    case 5:
                        Console.WriteLine("Cerrando..");
                        return; 
                    default:
                        Console.WriteLine("Opción seleccionada no es válida."); 
                        break;
                }
            }
        }
    }
}
