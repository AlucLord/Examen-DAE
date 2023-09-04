namespace Examen_DAE
{
    internal class Program
    {
        static Libro[] biblioteca = new Libro[100];
        static int contadorLibros = 0;
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Menu de seleccion:");
                Console.WriteLine("1. Costo de llamadas internacionales");
                Console.WriteLine("2. Libreria");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Seleccione una opcion");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ha seleccionado costo de llamadas");

                            while (continuar)
                            {
                                Console.WriteLine("Seleccione su clave: ");
                                Console.WriteLine("12. America del norte");
                                Console.WriteLine("15. America central");
                                Console.WriteLine("18. America del sur");
                                Console.WriteLine("19. Europa");
                                Console.WriteLine("23. Asia");
                                Console.WriteLine("1. Salir");

                                if (int.TryParse(Console.ReadLine(), out int opcion2))
                                {
                                    switch (opcion2)
                                    {
                                        case 12:
                                            int minutos;
                                            Console.WriteLine("Ingrese la cantidad de minutos hablados");
                                            minutos = int.Parse(Console.ReadLine());
                                            Console.WriteLine("El precio por la llamada es $ " + minutos * 2 + ".00");
                                            break;

                                        case 15:
                                            int minutos2;
                                            Console.WriteLine("Ingrese la cantidad de minutos hablados");
                                            minutos2 = int.Parse(Console.ReadLine());
                                            Console.WriteLine("El precio por la llamada es $ " + minutos2 * 2.2 + ".00");
                                            break;

                                        case 18:
                                            int minutos3;
                                            Console.WriteLine("Ingrese la cantidad de minutos hablados");
                                            minutos3 = int.Parse(Console.ReadLine());
                                            Console.WriteLine("El precio por la llamada es $ " + minutos3 * 4.5 + ".00");
                                            break;

                                        case 19:
                                            int minutos4;
                                            Console.WriteLine("Ingrese la cantidad de minutos hablados");
                                            minutos4 = int.Parse(Console.ReadLine());
                                            Console.WriteLine("El precio por la llamada es $ " + minutos4 * 3.5 + ".00");
                                            break;

                                        case 23:
                                            int minutos5;
                                            Console.WriteLine("Ingrese la cantidad de minutos hablados");
                                            minutos5 = int.Parse(Console.ReadLine());
                                            Console.WriteLine("El precio por la llamada es $ " + minutos5 * 6 + ".00");
                                            break;

                                        case 1:
                                            continuar = true; //para salir al menú principal
                                            break;

                                        default:
                                            Console.WriteLine("Ingrese una opcion valida");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada no valida, Ingrese un numero valido");
                                }
                                if (!continuar)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 2:
                            while (true)
                            {
                                Console.WriteLine("Gestión de Biblioteca");
                                Console.WriteLine("1. Agregar libro");
                                Console.WriteLine("2. Mostrar listado de libros");
                                Console.WriteLine("3. Buscar libro por código");
                                Console.WriteLine("4. Editar información de un libro");
                                Console.WriteLine("5. Salir");
                                Console.Write("Seleccione una opción: ");

                                int opcion3;
                                if (int.TryParse(Console.ReadLine(), out opcion3))
                                {
                                    switch (opcion3)
                                    {
                                        case 1:
                                            AgregarLibro();
                                            break;
                                        case 2:
                                            MostrarLibros();
                                            break;
                                        case 3:
                                            BuscarLibroPorCodigo();
                                            break;
                                        case 4:
                                            EditarLibroPorCodigo();
                                            break;
                                        case 5:
                                            Environment.Exit(0);
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                                }

                                Console.WriteLine();
                            }
                            break;

                        case 3:
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no valida, Ingrese un numero valido");
                }

                if (!continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla...");
                    Console.ReadKey();
                }
            }
        }
        static void AgregarLibro()
        {
            if (contadorLibros < biblioteca.Length)
            {
                Libro libro = new Libro();

                Console.Write("Código: ");
                libro.Codigo = Console.ReadLine();
                Console.Write("Título: ");
                libro.Titulo = Console.ReadLine();
                Console.Write("ISBN: ");
                libro.ISBN = Console.ReadLine();
                Console.Write("Edición: ");
                libro.Edicion = Console.ReadLine();
                Console.Write("Autor: ");
                libro.Autor = Console.ReadLine();

                biblioteca[contadorLibros] = libro;
                contadorLibros++;

                Console.WriteLine("Libro agregado con éxito.");
            }
            else
            {
                Console.WriteLine("La biblioteca está llena. No se pueden agregar más libros.");
            }
        }
        static void MostrarLibros()
        {
            if (contadorLibros > 0)
            {
                Console.WriteLine("Listado de Libros:");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("| Código |          Título          |   ISBN   |  Edición  |  Autor   |");
                Console.WriteLine("----------------------------------------------------------------");
                for (int i = 0; i < contadorLibros; i++)
                {
                    Console.WriteLine($"| {biblioteca[i].Codigo,-7} | {biblioteca[i].Titulo,-25} | {biblioteca[i].ISBN,-9} | {biblioteca[i].Edicion,-10} | {biblioteca[i].Autor,-9} |");
                }
                Console.WriteLine("----------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
        }

        static void BuscarLibroPorCodigo()
        {
            Console.Write("Ingrese el código del libro a buscar: ");
            string codigoBuscado = Console.ReadLine();

            bool encontrado = false;
            for (int i = 0; i < contadorLibros; i++)
            {
                if (biblioteca[i].Codigo.Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Información del libro encontrado:");
                    Console.WriteLine("Código: " + biblioteca[i].Codigo);
                    Console.WriteLine("Título: " + biblioteca[i].Titulo);
                    Console.WriteLine("ISBN: " + biblioteca[i].ISBN);
                    Console.WriteLine("Edición: " + biblioteca[i].Edicion);
                    Console.WriteLine("Autor: " + biblioteca[i].Autor);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        static void EditarLibroPorCodigo()
        {
            Console.Write("Ingrese el código del libro a editar: ");
            string codigoEditar = Console.ReadLine();

            bool encontrado = false;
            for (int i = 0; i < contadorLibros; i++)
            {
                if (biblioteca[i].Codigo.Equals(codigoEditar, StringComparison.OrdinalIgnoreCase))
                {

                    Console.WriteLine("Ingrese la nueva información del libro:");
                    Console.Write("Título: ");
                    biblioteca[i].Titulo = Console.ReadLine();
                    Console.Write("ISBN: ");
                    biblioteca[i].ISBN = Console.ReadLine();
                    Console.Write("Edición: ");
                    biblioteca[i].Edicion = Console.ReadLine();
                    Console.Write("Autor: ");
                    biblioteca[i].Autor = Console.ReadLine();

                    Console.WriteLine("Información del libro actualizada con éxito.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }
    }

    class Libro
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Edicion { get; set; }
        public string Autor { get; set; }
    }
}
