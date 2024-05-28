using System;

namespace ListaDeTareas
{
    // Clase para una tarea
    public class Tarea
    {
        public string Descripcion { get; set; }
        public Tarea Siguiente { get; set; }

        public Tarea(string descripcion)
        {
            Descripcion = descripcion;
            Siguiente = null;
        }
    }

    // Clase para la lista de tareas
    public class ListaDeTareas
    {
        private Tarea primera;

        public ListaDeTareas()
        {
            primera = null;
        }

        // Método para agregar una tarea
        public void AgregarTarea(string descripcion)
        {
            Tarea nueva = new Tarea(descripcion);
            if (primera == null)
            {
                primera = nueva;
            }
            else
            {
                Tarea actual = primera;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nueva;
            }
            Console.WriteLine("Tarea agregada: " + descripcion);
        }

        // Método para eliminar una tarea
        public void EliminarTarea(string descripcion)
        {
            if (primera == null)
            {
                Console.WriteLine("No hay tareas en la lista.");
                return;
            }

            if (primera.Descripcion == descripcion)
            {
                primera = primera.Siguiente;
                Console.WriteLine("Tarea eliminada: " + descripcion);
                return;
            }

            Tarea actual = primera;
            while (actual.Siguiente != null && actual.Siguiente.Descripcion != descripcion)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente == null)
            {
                Console.WriteLine("No encontré la tarea: " + descripcion);
            }
            else
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                Console.WriteLine("Tarea eliminada: " + descripcion);
            }
        }

        // Método para mostrar todas las tareas
        public void MostrarTareas()
        {
            if (primera == null)
            {
                Console.WriteLine("No hay tareas en la lista.");
                return;
            }

            Tarea actual = primera;
            Console.WriteLine("Tareas pendientes:");
            while (actual != null)
            {
                Console.WriteLine("- " + actual.Descripcion);
                actual = actual.Siguiente;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaDeTareas miLista = new ListaDeTareas();

            while (true)
            {
                Console.WriteLine("\nGestor de Tareas:");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Eliminar tarea");
                Console.WriteLine("3. Ver tareas");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Descripción de la tarea: ");
                        string descripcionAgregar = Console.ReadLine();
                        miLista.AgregarTarea(descripcionAgregar);
                        break;

                    case "2":
                        Console.Write("Tarea a eliminar: ");
                        string descripcionEliminar = Console.ReadLine();
                        miLista.EliminarTarea(descripcionEliminar);
                        break;

                    case "3":
                        miLista.MostrarTareas();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Opción inválida, intenta de nuevo.");
                        break;
                }
            }
        }
    }
}
