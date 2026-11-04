using System;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
    }
    static void ShowMainMenu()
    {
        bool running = true;
        while (running)
        {
            // Console.Clear(); (implementado cuando haya más funcionalidades)
            Console.WriteLine("========================================");
            Console.WriteLine("         SISTEMA DE BIBLIOTECA          ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción (1-6): ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowBooksMenu();
                    break;
                case "2":
                    Console.WriteLine("Funcionalidad de usuarios aún no implementada.");
                    break;
                case "3":
                    Console.WriteLine("Funcionalidad de préstamos aún no implementada.");
                    break;
                case "4":
                    Console.WriteLine("Funcionalidad de búsquedas y reportes aún no implementada.");
                    break;
                case "5":
                    Console.WriteLine("Funcionalidad de guardar/cargar datos aún no implementada.");
                    break;
                case "6":
                    Console.WriteLine("Funcionalidad de salir aún no implementada.");
                    break;
                default:
                    Console.WriteLine("\n[Error] Opción no válida. Por favor, ingrese un número entre 1 y 6.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowBooksMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- MENÚ LIBROS ---");
            Console.WriteLine("1.1 Registrar libro");
            Console.WriteLine("1.2 Listar libros");
            Console.WriteLine("1.3 Ver detalle (por ID/ISBN)");
            Console.WriteLine("1.4 Actualizar libro");
            Console.WriteLine("1.5 Eliminar libro");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1.1":
                case "1":
                    RegisterBook();
                    break;
                case "1.2":
                case "2":
                    ListBooksMenu();
                    break;
                case "1.3":
                case "3":
                    ViewBookDetail();
                    break;
                case "1.4":
                case "4":
                    UpdateBookMenu();
                    break;
                case "1.5":
                case "5":
                    DeleteBook();
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("\n[Error] Opción no válida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void RegisterBook()
    {
        Console.Clear();
        Console.WriteLine("--- Registrar Libro ---");
        Console.WriteLine("[Simulación] Función ejecutada: Registro de un nuevo libro exitoso.");
        Console.WriteLine("\nPresione cualquier tecla para volver...");
        Console.ReadKey();
    }

    static void ListBooksMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- LISTAR LIBROS ---");
            Console.WriteLine("1.2.1 Listar todos");
            Console.WriteLine("1.2.2 Listar disponibles");
            Console.WriteLine("1.2.3 Listar prestados");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1.2.1":
                case "1":
                    ListBooksAll();
                    break;
                case "1.2.2":
                case "2":
                    ListBooksAvailable();
                    break;
                case "1.2.3":
                case "3":
                    ListBooksBorrowed();
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("\n[Error] Opción no válida. Presione una tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ListBooksAll()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Listando todos los libros registrados.");
        Console.ReadKey();
    }

    static void ListBooksAvailable()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Listando libros disponibles.");
        Console.ReadKey();
    }

    static void ListBooksBorrowed()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Listando libros prestados.");
        Console.ReadKey();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Visualizando detalle del libro por ID/ISBN.");
        Console.ReadKey();
    }

    static void UpdateBookMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- ACTUALIZAR LIBRO ---");
            Console.WriteLine("1.4.1 Editar título");
            Console.WriteLine("1.4.2 Editar autor");
            Console.WriteLine("1.4.3 Editar año / categoría");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1.4.1":
                case "1":
                    EditBookTitle();
                    break;
                case "1.4.2":
                case "2":
                    EditBookAuthor();
                    break;
                case "1.4.3":
                case "3":
                    EditBookYearCategory();
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("\n[Error] Opción no válida. Presione una tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void EditBookTitle()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Editando título del libro.");
        Console.ReadKey();
    }

    static void EditBookAuthor()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Editando autor del libro.");
        Console.ReadKey();
    }

    static void EditBookYearCategory()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Editando año / categoría del libro.");
        Console.ReadKey();
    }

    static void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Libro ---");
        Console.WriteLine("[Validación] Validar no permitir si está prestado.");
        Console.ReadKey();
    }
}