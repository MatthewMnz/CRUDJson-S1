using CRUDJson_S1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUDJson_S1.Services
{
    public class CRUDServices
    {
        private const string FilePath = "usuarios.json"; 

        public void CrearUsuario()
        {
            var usuarios = LeerUsuariosDesdeArchivo(); // Carga la lista actual de usuarios

            Console.Write("Introduce el ID del usuario: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Introduce el nombre del usuario: ");
            string nombre = Console.ReadLine();

            Console.Write("Introduce el correo del usuario: ");
            string correo = Console.ReadLine();

            usuarios.Add(new Usuario { ID = id, Nombre = nombre, Correo = correo }); // Añade un nuevo usuario a la lista
            GuardarUsuariosEnArchivo(usuarios); // Guarda los cambios en el archivo
            Console.WriteLine("Usuario creado exitosamente.");
        }

        public void LeerUsuarios()
        {
            var usuarios = LeerUsuariosDesdeArchivo(); // Carga los usuarios desde el archivo

            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            // Muestra los usuarios almacenados.
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.ID}, Nombre: {usuario.Nombre}, Correo: {usuario.Correo}");
            }
        }

        public void ActualizarUsuario()
        {
            var usuarios = LeerUsuariosDesdeArchivo(); // Carga la lista actual de usuarios

            Console.Write("Introduce el ID del usuario a actualizar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var usuario = usuarios.FirstOrDefault(u => u.ID == id); // Busca el usuario por ID
            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return;
            }

            // Actualiza los datos del usuario.
            Console.Write("Introduce el nuevo nombre del usuario: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Introduce el nuevo correo del usuario: ");
            usuario.Correo = Console.ReadLine();

            GuardarUsuariosEnArchivo(usuarios); // Guarda los cambios en el archivo
            Console.WriteLine("Usuario actualizado exitosamente.");
        }

        public void EliminarUsuario()
        {
            var usuarios = LeerUsuariosDesdeArchivo(); // Carga la lista actual de usuarios

            Console.Write("Introduce el ID del usuario a eliminar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var usuario = usuarios.FirstOrDefault(u => u.ID == id); // Busca el usuario por ID
            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return;
            }

            usuarios.Remove(usuario); // Elimina el usuario de la lista
            GuardarUsuariosEnArchivo(usuarios); // Guarda los cambios en el archivo
            Console.WriteLine("Usuario eliminado exitosamente.");
        }

        private List<Usuario> LeerUsuariosDesdeArchivo()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Usuario>(); // Retorna una lista vacía si el archivo no existe
            }

            string json = File.ReadAllText(FilePath); 
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>(); // Deserializa a una lista de usuarios
        }

        // Método auxiliar: Guarda los usuarios en el archivo JSON.
        private void GuardarUsuariosEnArchivo(List<Usuario> usuarios)
        {
            string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true }); // Serializa la lista con formato legible.
            File.WriteAllText(FilePath, json); // Escribe el JSON en el archivo.
        }
    }
}
