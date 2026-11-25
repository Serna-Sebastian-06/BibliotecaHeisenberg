using System;
using System.Collections.Generic;
using BibliotecaHeisenberg.Models;
using BibliotecaHeisenberg.Services;

namespace BibliotecaHeisenberg
{
    class Program
    {
        // Instancias globales de los servicios en memoria
        static LibroService libroService = new LibroService();
        static UsuarioService usuarioService = new UsuarioService();
        static PrestamoService prestamoService = new PrestamoService();

        static void Main(string[] args)
        {
            CargarDatosIniciales();
            ShowMainMenu();
        }

        // DATOS INICIALES EN MEMORIA
        static void CargarDatosIniciales()
        {
            Libro libro1 = new Libro(1, "978-0307474728", "Cien años de soledad", "Gabriel García Márquez", 1967, "Novela");
            Libro libro2 = new Libro(2, "978-8445071403", "El Señor de los Anillos", "J.R.R. Tolkien", 1954, "Fantasía");
            Libro libro3 = new Libro(3, "978-0132350884", "Clean Code", "Robert C. Martin", 2008, "Tecnología");
            libro2.Disponible = false; // Prestado en el préstamo #101

            libroService.AgregarLibro(libro1);
            libroService.AgregarLibro(libro2);
            libroService.AgregarLibro(libro3);

            Usuario usuario1 = new Usuario(1, "1001234567", "Sebastián Serna", "sebastian@correo.com");
            Usuario usuario2 = new Usuario(2, "1007654321", "Ender Jiménez", "ender@correo.com");
            Usuario usuario3 = new Usuario(3, "1009998887", "Carlos Pérez", "carlos@correo.com");
            usuario3.Activo = false;

            usuarioService.AgregarUsuario(usuario1);
            usuarioService.AgregarUsuario(usuario2);
            usuarioService.AgregarUsuario(usuario3);

            Prestamo prestamo1 = new Prestamo(101, libro2, usuario1, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(5));
            Prestamo prestamo2 = new Prestamo(102, libro1, usuario2, DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-2));

            prestamoService.AgregarPrestamo(prestamo1);
            prestamoService.AgregarPrestamo(prestamo2);
        }


        // MENÚ PRINCIPAL
        static void ShowMainMenu()
        {
            bool ejecutando = true;
            while (ejecutando)
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

                string opcion = Console.ReadLine();

                switch (opcion)
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
                        ShowPersistenceMenu();
                        break;
                    case "6":
                        if (ConfirmExitAndSave())
                        {
                            ejecutando = false;
                        }
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // 1) MÓDULO DE LIBROS
        static void ShowBooksMenu()
        {
            bool volver = false;
            while (!volver)
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

                string opcion = Console.ReadLine();

                switch (opcion)
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
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida. Presione una tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RegisterBook()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRAR NUEVO LIBRO ---");
            Console.Write("ID numérico: ");
            int idLibro = int.Parse(Console.ReadLine());
            Console.Write("ISBN: ");
            string isbnLibro = Console.ReadLine();
            Console.Write("Título: ");
            string tituloLibro = Console.ReadLine();
            Console.Write("Autor: ");
            string autorLibro = Console.ReadLine();
            Console.Write("Año de publicación: ");
            int anioLibro = int.Parse(Console.ReadLine());
            Console.Write("Categoría: ");
            string categoriaLibro = Console.ReadLine();

            Libro nuevoLibro = new Libro(idLibro, isbnLibro, tituloLibro, autorLibro, anioLibro, categoriaLibro);
            libroService.AgregarLibro(nuevoLibro);

            Console.WriteLine("\n[OK] Libro registrado exitosamente en memoria.");
            Console.ReadKey();
        }

        static void ListBooksMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("--- LISTAR LIBROS ---");
                Console.WriteLine("1.2.1 Listar todos");
                Console.WriteLine("1.2.2 Listar disponibles");
                Console.WriteLine("1.2.3 Listar prestados");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
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
                        volver = true;
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
            Console.WriteLine("--- TODOS LOS LIBROS (ORDENADOS POR TÍTULO) ---");
            List<Libro> librosOrdenados = libroService.OrdenarPorTitulo();

            if (librosOrdenados.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
            }
            else
            {
                foreach (Libro libroActual in librosOrdenados)
                {
                    Console.WriteLine(libroActual.ResumenCorto());
                }
            }
            Console.ReadKey();
        }

        static void ListBooksAvailable()
        {
            Console.Clear();
            Console.WriteLine("--- LIBROS DISPONIBLES ---");
            int contadorDisponibles = 0;

            foreach (Libro libroActual in libroService.ObtenerTodos())
            {
                if (libroActual.Disponible)
                {
                    Console.WriteLine(libroActual.ResumenCorto());
                    contadorDisponibles++;
                }
            }

            if (contadorDisponibles == 0)
            {
                Console.WriteLine("No hay libros disponibles en este momento.");
            }
            Console.ReadKey();
        }

        static void ListBooksBorrowed()
        {
            Console.Clear();
            Console.WriteLine("--- LIBROS PRESTADOS ---");
            int contadorPrestados = 0;

            foreach (Libro libroActual in libroService.ObtenerTodos())
            {
                if (!libroActual.Disponible)
                {
                    Console.WriteLine(libroActual.ResumenCorto());
                    contadorPrestados++;
                }
            }

            if (contadorPrestados == 0)
            {
                Console.WriteLine("No hay libros prestados en este momento.");
            }
            Console.ReadKey();
        }

        static void ViewBookDetail()
        {
            Console.Clear();
            Console.Write("Ingrese el ID/ISBN del libro a consultar: ");
            string idOrIsbn = Console.ReadLine();
            Libro libroEncontrado = null;

            // Intentar buscar por ID primero
            if (int.TryParse(idOrIsbn, out int idBuscado))
            {
                libroEncontrado = libroService.BuscarPorId(idBuscado);
            }
            else
            {
                libroEncontrado = libroService.BuscarPorIsbn(idOrIsbn);
            }

            if (libroEncontrado != null)
            {
                Console.WriteLine("\n" + libroEncontrado.DetalleCompleto());
            }
            else
            {
                Console.WriteLine("\n[Aviso] No se encontró ningún libro con ese ID o ISBN.");
            }
            Console.ReadKey();
        }

        static void UpdateBookMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("--- ACTUALIZAR LIBRO ---");
                Console.WriteLine("1.4.1 Editar título");
                Console.WriteLine("1.4.2 Editar autor");
                Console.WriteLine("1.4.3 Editar año / categoría");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
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
                        volver = true;
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
            Console.Write("Ingrese el ID/ISBN del libro a editar: ");
            string idOrIsbn = Console.ReadLine();
            Libro libroEncontrado = libroService.BuscarPorId(int.Parse(idOrIsbn)) ?? libroService.BuscarPorIsbn(idOrIsbn);

            if (libroEncontrado != null)
            {
                Console.Write($"Título actual ({libroEncontrado.Titulo}). Nuevo título: ");
                libroEncontrado.Titulo = Console.ReadLine();
                Console.WriteLine("\n[OK] Título actualizado en memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] Libro no encontrado.");
            }
            Console.ReadKey();
        }

        static void EditBookAuthor()
        {
            Console.Clear();
            Console.Write("Ingrese el ID/ISBN del libro a editar: ");
            string idOrIsbn = Console.ReadLine();
            Libro libroEncontrado = libroService.BuscarPorId(int.Parse(idOrIsbn)) ?? libroService.BuscarPorIsbn(idOrIsbn);

            if (libroEncontrado != null)
            {
                Console.Write($"Autor actual ({libroEncontrado.Autor}). Nuevo autor: ");
                libroEncontrado.Autor = Console.ReadLine();
                Console.WriteLine("\n[OK] Autor actualizado en memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] Libro no encontrado.");
            }
            Console.ReadKey();
        }

        static void EditBookYearCategory()
        {
            Console.Clear();
            Console.Write("Ingrese el ID/ISBN del libro a editar: ");
            string idOrIsbn = Console.ReadLine();
            Libro libroEncontrado = libroService.BuscarPorId(int.Parse(idOrIsbn)) ?? libroService.BuscarPorIsbn(idOrIsbn);

            if (libroEncontrado != null)
            {
                Console.Write($"Año actual ({libroEncontrado.Anio}). Nuevo año: ");
                libroEncontrado.Anio = int.Parse(Console.ReadLine());
                Console.Write($"Categoría actual ({libroEncontrado.Categoria}). Nueva categoría: ");
                libroEncontrado.Categoria = Console.ReadLine();
                Console.WriteLine("\n[OK] Año y categoría actualizados en memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] Libro no encontrado.");
            }
            Console.ReadKey();
        }

        static void DeleteBook()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del libro a eliminar: ");
            int idLibro = int.Parse(Console.ReadLine());

            if (libroService.EliminarLibro(idLibro))
            {
                Console.WriteLine("\n[OK] Libro eliminado de la memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] No se pudo eliminar (el libro no existe o está prestado actualmente).");
            }
            Console.ReadKey();
        }

        // 2) MÓDULO DE USUARIOS
        static void ShowUsersMenu()
        {
            bool volver = false;
            while (!volver)
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

                string opcion = Console.ReadLine();
                switch (opcion)
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
                        volver = true;
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
            Console.WriteLine("--- REGISTRAR NUEVO USUARIO ---");
            Console.Write("ID numérico: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("Documento: ");
            string documentoUsuario = Console.ReadLine();
            Console.Write("Nombre completo: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Contacto (correo/teléfono): ");
            string contactoUsuario = Console.ReadLine();

            Usuario nuevoUsuario = new Usuario(idUsuario, documentoUsuario, nombreUsuario, contactoUsuario);
            usuarioService.AgregarUsuario(nuevoUsuario);

            Console.WriteLine("\n[OK] Usuario registrado exitosamente en memoria.");
            Console.ReadKey();
        }

        static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("--- TODOS LOS USUARIOS (ORDENADOS POR NOMBRE) ---");
            List<Usuario> usuariosOrdenados = usuarioService.OrdenarPorNombre();

            if (usuariosOrdenados.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                foreach (Usuario usuarioActual in usuariosOrdenados)
                {
                    Console.WriteLine(usuarioActual.ResumenCorto());
                }
            }
            Console.ReadKey();
        }

        static void ViewUserDetail()
        {
            Console.Clear();
            Console.Write("Ingrese el documento del usuario: ");
            string documentoBuscado = Console.ReadLine();
            Usuario usuarioEncontrado = usuarioService.BuscarPorDocumento(documentoBuscado);

            if (usuarioEncontrado != null)
            {
                Console.WriteLine("\n" + usuarioEncontrado.DetalleCompleto());
            }
            else
            {
                Console.WriteLine("\n[Aviso] Usuario no encontrado.");
            }
            Console.ReadKey();
        }

        static void UpdateUserMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("--- ACTUALIZAR USUARIO ---");
                Console.WriteLine("2.4.1 Editar nombre");
                Console.WriteLine("2.4.2 Editar contacto");
                Console.WriteLine("2.4.3 Activar / desactivar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
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
                        volver = true;
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
            Console.Write("Ingrese el documento del usuario: ");
            string documentoBuscado = Console.ReadLine();
            Usuario usuarioEncontrado = usuarioService.BuscarPorDocumento(documentoBuscado);

            if (usuarioEncontrado != null)
            {
                Console.Write($"Nombre actual ({usuarioEncontrado.Nombre}). Nuevo nombre: ");
                usuarioEncontrado.Nombre = Console.ReadLine();
                Console.WriteLine("\n[OK] Nombre actualizado en memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] Usuario no encontrado.");
            }
            Console.ReadKey();
        }

        static void EditUserContact()
        {
            Console.Clear();
            Console.Write("Ingrese el documento del usuario: ");
            string documentoBuscado = Console.ReadLine();
            Usuario usuarioEncontrado = usuarioService.BuscarPorDocumento(documentoBuscado);

            if (usuarioEncontrado != null)
            {
                Console.Write($"Contacto actual ({usuarioEncontrado.Contacto}). Nuevo contacto: ");
                usuarioEncontrado.Contacto = Console.ReadLine();
                Console.WriteLine("\n[OK] Contacto actualizado en memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] Usuario no encontrado.");
            }
            Console.ReadKey();
        }

        static void ToggleUserActiveStatus()
        {
            Console.Clear();
            Console.Write("Ingrese el documento del usuario: ");
            string documentoBuscado = Console.ReadLine();
            Usuario usuarioEncontrado = usuarioService.BuscarPorDocumento(documentoBuscado);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Activo = !usuarioEncontrado.Activo;
                string estadoTexto = usuarioEncontrado.Activo ? "ACTIVO" : "INACTIVO";
                Console.WriteLine($"\n[OK] El estado de {usuarioEncontrado.Nombre} ahora es: {estadoTexto}");
            }
            else
            {
                Console.WriteLine("\n[Error] Usuario no encontrado.");
            }
            Console.ReadKey();
        }

        static void DeleteUser()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del usuario a eliminar: ");
            int idUsuario = int.Parse(Console.ReadLine());

            bool tienePrestamosActivos = false;
            foreach (Prestamo prestamoActual in prestamoService.ObtenerTodos())
            {
                if (prestamoActual.UsuarioPrestatario != null &&
                    prestamoActual.UsuarioPrestatario.Id == idUsuario &&
                    prestamoActual.Estado == EstadoPrestamo.Activo)
                {
                    tienePrestamosActivos = true;
                    break;
                }
            }

            if (tienePrestamosActivos)
            {
                Console.WriteLine("\n[Error] No se puede eliminar el usuario porque tiene préstamos activos.");
            }
            else if (usuarioService.EliminarUsuario(idUsuario))
            {
                Console.WriteLine("\n[OK] Usuario eliminado de la memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] Usuario no encontrado.");
            }
            Console.ReadKey();
        }

        // 3) MÓDULO DE PRÉSTAMOS
        static void ShowLoansMenu()
        {
            bool volver = false;
            while (!volver)
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

                string opcion = Console.ReadLine();
                switch (opcion)
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
                        volver = true;
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
            Console.WriteLine("--- CREAR NUEVO PRÉSTAMO ---");
            Console.Write("ID del préstamo: ");
            int idPrestamo = int.Parse(Console.ReadLine());

            Console.Write("Documento del usuario: ");
            string documentoUsuario = Console.ReadLine();
            Usuario usuarioEncontrado = usuarioService.BuscarPorDocumento(documentoUsuario);

            if (usuarioEncontrado == null || !usuarioEncontrado.Activo)
            {
                Console.WriteLine("\n[Error] El usuario no existe o se encuentra inactivo.");
                Console.ReadKey();
                return;
            }

            Console.Write("ID/ISBN del libro: ");
            string idOrIsbn = Console.ReadLine();
            Libro libroEncontrado = libroService.BuscarPorId(int.Parse(idOrIsbn)) ?? libroService.BuscarPorIsbn(idOrIsbn);

            if (libroEncontrado == null || !libroEncontrado.Disponible)
            {
                Console.WriteLine("\n[Error] El libro no existe o no está disponible.");
                Console.ReadKey();
                return;
            }

            Console.Write("Días de plazo para el préstamo: ");
            int diasPlazo = int.Parse(Console.ReadLine());

            libroEncontrado.Disponible = false;
            Prestamo nuevoPrestamo = new Prestamo(idPrestamo, libroEncontrado, usuarioEncontrado, DateTime.Now, DateTime.Now.AddDays(diasPlazo));
            prestamoService.AgregarPrestamo(nuevoPrestamo);

            Console.WriteLine("\n[OK] Préstamo creado y libro marcado como no disponible.");
            Console.ReadKey();
        }

        static void ListLoansMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("--- LISTAR PRÉSTAMOS ---");
                Console.WriteLine("3.2.1 Todos");
                Console.WriteLine("3.2.2 Activos");
                Console.WriteLine("3.2.3 Cerrados");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
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
                        volver = true;
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
            Console.WriteLine("--- TODOS LOS PRÉSTAMOS (ORDENADOS POR FECHA LÍMITE) ---");
            List<Prestamo> prestamosOrdenados = prestamoService.OrdenarPorFechaLimite();

            if (prestamosOrdenados.Count == 0)
            {
                Console.WriteLine("No hay préstamos registrados.");
            }
            else
            {
                foreach (Prestamo prestamoActual in prestamosOrdenados)
                {
                    Console.WriteLine(prestamoActual.ResumenCorto());
                }
            }
            Console.ReadKey();
        }

        static void ListLoansActive()
        {
            Console.Clear();
            Console.WriteLine("--- PRÉSTAMOS ACTIVOS ---");
            List<Prestamo> prestamosActivos = prestamoService.BuscarPorEstado(EstadoPrestamo.Activo);

            if (prestamosActivos.Count == 0)
            {
                Console.WriteLine("No hay préstamos activos.");
            }
            else
            {
                foreach (Prestamo prestamoActual in prestamosActivos)
                {
                    Console.WriteLine(prestamoActual.ResumenCorto());
                }
            }
            Console.ReadKey();
        }

        static void ListLoansClosed()
        {
            Console.Clear();
            Console.WriteLine("--- PRÉSTAMOS DEVUELTOS / CERRADOS ---");
            List<Prestamo> prestamosCerrados = prestamoService.BuscarPorEstado(EstadoPrestamo.Devuelto);

            if (prestamosCerrados.Count == 0)
            {
                Console.WriteLine("No hay préstamos cerrados.");
            }
            else
            {
                foreach (Prestamo prestamoActual in prestamosCerrados)
                {
                    Console.WriteLine(prestamoActual.ResumenCorto());
                }
            }
            Console.ReadKey();
        }

        static void ViewLoanDetail()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del préstamo: ");
            int idBuscado = int.Parse(Console.ReadLine());
            Prestamo prestamoEncontrado = prestamoService.BuscarPorId(idBuscado);

            if (prestamoEncontrado != null)
            {
                Console.WriteLine("\n" + prestamoEncontrado.DetalleCompleto());
            }
            else
            {
                Console.WriteLine("\n[Aviso] Préstamo no encontrado.");
            }
            Console.ReadKey();
        }

        static void RegisterReturn()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del préstamo a devolver: ");
            int idBuscado = int.Parse(Console.ReadLine());
            Prestamo prestamoEncontrado = prestamoService.BuscarPorId(idBuscado);

            if (prestamoEncontrado != null && prestamoEncontrado.Estado != EstadoPrestamo.Devuelto)
            {
                prestamoEncontrado.Estado = EstadoPrestamo.Devuelto;
                prestamoEncontrado.FechaDevolucion = DateTime.Now;
                if (prestamoEncontrado.LibroPrestado != null)
                {
                    prestamoEncontrado.LibroPrestado.Disponible = true;
                }
                Console.WriteLine("\n[OK] Devolución registrada y libro disponible nuevamente.");
            }
            else
            {
                Console.WriteLine("\n[Error] Préstamo no encontrado o ya fue devuelto.");
            }
            Console.ReadKey();
        }

        static void DeleteLoan()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del préstamo a eliminar: ");
            int idBuscado = int.Parse(Console.ReadLine());
            Prestamo prestamoEncontrado = prestamoService.BuscarPorId(idBuscado);

            if (prestamoEncontrado != null)
            {
                if (prestamoEncontrado.Estado == EstadoPrestamo.Activo && prestamoEncontrado.LibroPrestado != null)
                {
                    prestamoEncontrado.LibroPrestado.Disponible = true;
                }
                prestamoService.EliminarPrestamo(idBuscado);
                Console.WriteLine("\n[OK] Préstamo eliminado de la memoria.");
            }
            else
            {
                Console.WriteLine("\n[Error] Préstamo no encontrado.");
            }
            Console.ReadKey();
        }

        // 4) MÓDULO DE BÚSQUEDAS Y REPORTES
        static void ShowSearchReportsMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("--- BÚSQUEDAS Y REPORTES ---");
                Console.WriteLine("4.1 Buscar libro (título/autor/id/categoría)");
                Console.WriteLine("4.2 Buscar usuario (nombre/id)");
                Console.WriteLine("4.3 Reportes");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
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
                        volver = true;
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
            Console.Write("Ingrese el título a buscar: ");
            string textoBuscado = Console.ReadLine();
            List<Libro> librosEncontrados = libroService.BuscarPorTitulo(textoBuscado);

            Console.WriteLine($"\nResultados encontrados: {librosEncontrados.Count}");
            foreach (Libro libroActual in librosEncontrados)
            {
                Console.WriteLine(" - " + libroActual.ResumenCorto());
            }
            Console.ReadKey();
        }

        static void SearchUser()
        {
            Console.Clear();
            Console.Write("Ingrese el nombre a buscar: ");
            string textoBuscado = Console.ReadLine();
            List<Usuario> usuariosEncontrados = usuarioService.BuscarPorNombre(textoBuscado);

            Console.WriteLine($"\nResultados encontrados: {usuariosEncontrados.Count}");
            foreach (Usuario usuarioActual in usuariosEncontrados)
            {
                Console.WriteLine(" - " + usuarioActual.ResumenCorto());
            }
            Console.ReadKey();
        }

        static void ReportsMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("--- MENÚ REPORTES Y ESTADÍSTICAS ---");
                Console.WriteLine("1. Reporte por usuario");
                Console.WriteLine("2. Reporte por libro");
                Console.WriteLine("3. Reporte vencidos");
                Console.WriteLine("4. Resumen general (KPIs)");
                Console.WriteLine("5. Comparación Array vs List<T>");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        ReportByUser();
                        break;
                    case "2":
                        ReportByBook();
                        break;
                    case "3":
                        ReportOverdue();
                        break;
                    case "4":
                        ReportSummary();
                        break;
                    case "5":
                        CompararArrayVsList();
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida. Presione una tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ReportByUser()
        {
            Console.Clear();
            Console.WriteLine("--- REPORTE DE USUARIOS ---");
            foreach (Usuario usuarioActual in usuarioService.ObtenerTodos())
            {
                Console.WriteLine(usuarioActual.DetalleCompleto());
                Console.WriteLine("----------------------------------------");
            }
            Console.ReadKey();
        }

        static void ReportByBook()
        {
            Console.Clear();
            Console.WriteLine("--- REPORTE DE LIBROS (ORDENADOS POR AÑO) ---");
            foreach (Libro libroActual in libroService.OrdenarPorAnio())
            {
                Console.WriteLine($"{libroActual.ResumenCorto()} - Año: {libroActual.Anio}");
            }
            Console.ReadKey();
        }

        static void ReportOverdue()
        {
            Console.Clear();
            Console.WriteLine("--- REPORTE DE PRÉSTAMOS VENCIDOS ---");
            int cantidadVencidos = 0;

            foreach (Prestamo prestamoActual in prestamoService.ObtenerTodos())
            {
                if (prestamoActual.EstaVencido())
                {
                    Console.WriteLine(prestamoActual.DetalleCompleto());
                    Console.WriteLine("----------------------------------------");
                    cantidadVencidos++;
                }
            }

            if (cantidadVencidos == 0)
            {
                Console.WriteLine("No hay préstamos vencidos.");
            }
            Console.ReadKey();
        }

        static void ReportSummary()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("      ESTADÍSTICAS Y KPIs DEL SISTEMA   ");
            Console.WriteLine("========================================");

            Console.WriteLine("\n[KPIs - LIBROS]");
            Console.WriteLine($"- Total de libros: {libroService.TotalLibros()}");
            Console.WriteLine($"- Disponibles: {libroService.TotalDisponibles()} | Prestados: {libroService.TotalPrestados()}");

            Console.WriteLine("\n[KPIs - USUARIOS]");
            Console.WriteLine($"- Total de usuarios: {usuarioService.TotalUsuarios()}");
            Console.WriteLine($"- Activos: {usuarioService.TotalActivos()} | Inactivos: {usuarioService.TotalInactivos()}");

            Console.WriteLine("\n[KPIs - PRÉSTAMOS]");
            Console.WriteLine($"- Total de préstamos: {prestamoService.TotalPrestamos()}");
            Console.WriteLine($"- Activos: {prestamoService.TotalActivos()} | Vencidos: {prestamoService.TotalVencidos()} | Devueltos: {prestamoService.TotalDevueltos()}");
            Console.WriteLine($"- Promedio de días de préstamo: {prestamoService.PromedioDiasPrestamo():F1} días");

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        static void CompararArrayVsList()
        {
            Console.Clear();
            Console.WriteLine("=== COMPARACIÓN: ARRAY VS LIST<T> ===\n");

            // 1. Ejemplo usando Array (Tamaño fijo)
            Libro[] arregloLibrosFijo = new Libro[2];
            arregloLibrosFijo[0] = new Libro(10, "111", "Libro Array 1", "Autor A", 2020, "General");
            arregloLibrosFijo[1] = new Libro(11, "222", "Libro Array 2", "Autor B", 2021, "General");

            Console.WriteLine($"[Array] Capacidad fija: {arregloLibrosFijo.Length} elementos.");
            foreach (Libro libroEnArreglo in arregloLibrosFijo)
            {
                Console.WriteLine(" - " + libroEnArreglo.ResumenCorto());
            }

            // 2. Ejemplo usando List<T> (Tamaño dinámico)
            List<Libro> listaLibrosDinamica = new List<Libro>();
            listaLibrosDinamica.Add(new Libro(20, "333", "Libro List 1", "Autor C", 2022, "General"));
            listaLibrosDinamica.Add(new Libro(21, "444", "Libro List 2", "Autor D", 2023, "General"));
            listaLibrosDinamica.Add(new Libro(22, "555", "Libro List 3", "Autor E", 2024, "General"));

            Console.WriteLine($"\n[List<T>] Cantidad dinámica actual: {listaLibrosDinamica.Count} elementos.");
            foreach (Libro libroEnLista in listaLibrosDinamica)
            {
                Console.WriteLine(" - " + libroEnLista.ResumenCorto());
            }

            Console.WriteLine("\n--- DIFERENCIAS CLAVE ---");
            Console.WriteLine("1. Tamaño: El Array tiene tamaño fijo al crearse; List<T> crece o se reduce dinámicamente.");
            Console.WriteLine("2. Métodos: List<T> incluye métodos integrados como Add(), Remove() y Count; el Array requiere manejo manual de índices.");
            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();
        }

        // 5) MÓDULO DE PERSISTENCIA EN MEMORIA
        static void ShowPersistenceMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("--- GUARDAR / CARGAR DATOS ---");
                Console.WriteLine("5.1 Guardar datos");
                Console.WriteLine("5.2 Cargar datos");
                Console.WriteLine("5.3 Reiniciar datos");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "5.1":
                    case "1":
                        SaveData();
                        break;
                    case "5.2":
                    case "2":
                        LoadData();
                        break;
                    case "5.3":
                    case "3":
                        ResetData();
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida. Presione una tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void SaveData()
        {
            Console.Clear();
            Console.WriteLine("[Memoria] Estado actual sincronizado en las listas en memoria:");
            Console.WriteLine($"- Libros: {libroService.TotalLibros()} | Usuarios: {usuarioService.TotalUsuarios()} | Préstamos: {prestamoService.TotalPrestamos()}");
            Console.ReadKey();
        }

        static void LoadData()
        {
            Console.Clear();
            CargarDatosIniciales();
            Console.WriteLine("[OK] Datos iniciales recargados en memoria.");
            Console.ReadKey();
        }

        static void ResetData()
        {
            Console.Clear();
            Console.WriteLine("--- REINICIAR DATOS ---");
            Console.Write("¿Está seguro de reiniciar los datos en memoria? (S/N): ");
            string respuesta = Console.ReadLine();

            if (respuesta != null && respuesta.ToUpper() == "S")
            {
                libroService = new LibroService();
                usuarioService = new UsuarioService();
                prestamoService = new PrestamoService();
                Console.WriteLine("\n[OK] Todas las listas en memoria han sido vaciadas.");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
            Console.ReadKey();
        }

        // 6) SALIDA DEL SISTEMA
        static bool ConfirmExitAndSave()
        {
            Console.Clear();
            Console.Write("¿Desea guardar los datos en memoria antes de salir? (S/N): ");
            string respuesta = Console.ReadLine();

            if (respuesta != null && respuesta.ToUpper() == "S")
            {
                Console.WriteLine("[OK] Datos confirmados en memoria.");
            }

            Console.WriteLine("\nSaliendo del sistema. ¡Hasta luego!");
            return true;
        }
    }
}