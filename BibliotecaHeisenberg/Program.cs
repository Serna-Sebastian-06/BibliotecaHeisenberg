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
            Console.Clear();
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
                    ShowUsersMenu();
                    break;
                case "3":
                    ShowLoansMenu();
                    break;
                case "4":
                    ShowSearchReportsMenu();
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

    static void ShowUsersMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- MENÚ USUARIOS ---");
            Console.WriteLine("2.1 Registrar usuario");
            Console.WriteLine("2.2 Listar usuarios");
            Console.WriteLine("2.3 Ver detalle (por ID/documento)");
            Console.WriteLine("2.4 Actualizar usuario");
            Console.WriteLine("2.5 Eliminar usuario");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "2.1":
                case "1":
                    RegisterUser();
                    break;
                case "2.2":
                case "2":
                    ListUsers();
                    break;
                case "2.3":
                case "3":
                    ViewUserDetail();
                    break;
                case "2.4":
                case "4":
                    UpdateUserMenu();
                    break;
                case "2.5":
                case "5":
                    DeleteUser();
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

    static void RegisterUser()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Registrando nuevo usuario.");
        Console.ReadKey();
    }

    static void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Listando todos los usuarios.");
        Console.ReadKey();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Visualizando detalle de usuario por ID/documento.");
        Console.ReadKey();
    }

    static void UpdateUserMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- ACTUALIZAR USUARIO ---");
            Console.WriteLine("2.4.1 Editar nombre");
            Console.WriteLine("2.4.2 Editar contacto");
            Console.WriteLine("2.4.3 Activar / desactivar");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "2.4.1":
                case "1":
                    EditUserName();
                    break;
                case "2.4.2":
                case "2":
                    EditUserContact();
                    break;
                case "2.4.3":
                case "3":
                    ToggleUserActiveStatus();
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

    static void EditUserName()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Editando nombre de usuario.");
        Console.ReadKey();
    }

    static void EditUserContact()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Editando contacto de usuario.");
        Console.ReadKey();
    }

    static void ToggleUserActiveStatus()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Cambiando estado Activo/Desactivar del usuario.");
        Console.ReadKey();
    }

    static void DeleteUser()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Usuario ---");
        Console.WriteLine("[Validación] Validar no permitir si tiene préstamos activos.");
        Console.ReadKey();
    }

    static void ShowLoansMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- MENÚ PRÉSTAMOS ---");
            Console.WriteLine("3.1 Crear préstamo");
            Console.WriteLine("3.2 Listar préstamos");
            Console.WriteLine("3.3 Ver detalle de préstamo (por ID)");
            Console.WriteLine("3.4 Registrar devolución");
            Console.WriteLine("3.5 Eliminar préstamo");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "3.1":
                case "1":
                    CreateLoan();
                    break;
                case "3.2":
                case "2":
                    ListLoansMenu();
                    break;
                case "3.3":
                case "3":
                    ViewLoanDetail();
                    break;
                case "3.4":
                case "4":
                    RegisterReturn();
                    break;
                case "3.5":
                case "5":
                    DeleteLoan();
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

    static void CreateLoan()
    {
        Console.Clear();
        Console.WriteLine("--- Crear Préstamo (Validaciones) ---");
        Console.WriteLine("- Validar que el usuario exista y esté activo.");
        Console.WriteLine("- Validar que el libro exista y esté disponible.");
        Console.WriteLine("- Validar límite de préstamos por usuario.");
        Console.WriteLine("\n[Simulación] Préstamo creado correctamente.");
        Console.ReadKey();
    }

    static void ListLoansMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- LISTAR PRÉSTAMOS ---");
            Console.WriteLine("3.2.1 Todos");
            Console.WriteLine("3.2.2 Activos");
            Console.WriteLine("3.2.3 Cerrados");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "3.2.1":
                case "1":
                    ListLoansAll();
                    break;
                case "3.2.2":
                case "2":
                    ListLoansActive();
                    break;
                case "3.2.3":
                case "3":
                    ListLoansClosed();
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

    static void ListLoansAll()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Listando todos los préstamos.");
        Console.ReadKey();
    }

    static void ListLoansActive()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Listando préstamos activos.");
        Console.ReadKey();
    }

    static void ListLoansClosed()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Listando préstamos cerrados.");
        Console.ReadKey();
    }

    static void ViewLoanDetail()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Ver detalle de préstamo por ID.");
        Console.ReadKey();
    }

    static void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("--- Registrar Devolución ---");
        Console.WriteLine("[Simulación] Marcado como devuelto y libro disponible nuevamente.");
        Console.ReadKey();
    }

    static void DeleteLoan()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Préstamo ---");
        Console.WriteLine("[Simulación] Reglas sugeridas de eliminación aplicadas.");
        Console.ReadKey();
    }

    static void ShowSearchReportsMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- BÚSQUEDAS Y REPORTES ---");
            Console.WriteLine("4.1 Buscar libro (título/autor/id/categoría)");
            Console.WriteLine("4.2 Buscar usuario (nombre/id)");
            Console.WriteLine("4.3 Reportes");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "4.1":
                case "1":
                    SearchBook();
                    break;
                case "4.2":
                case "2":
                    SearchUser();
                    break;
                case "4.3":
                case "3":
                    ReportsMenu();
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

    static void SearchBook()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Buscando libro por título, autor, ID o categoría.");
        Console.ReadKey();
    }

    static void SearchUser()
    {
        Console.Clear();
        Console.WriteLine("[Simulación] Buscando usuario por nombre o ID.");
        Console.ReadKey();
    }

    static void ReportsMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("--- MENÚ REPORTES ---");
            Console.WriteLine("1. Reporte por usuario");
            Console.WriteLine("2. Reporte por libro");
            Console.WriteLine("3. Reporte vencidos");
            Console.WriteLine("4. Resumen general");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción (o presione 0 para volver): ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("[Simulación] Generando reporte por usuario...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("[Simulación] Generando reporte por libro...");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("[Simulación] Generando reporte vencidos...");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("[Simulación] Generando resumen general...");
                    Console.ReadKey();
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

    
}