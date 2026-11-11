# 📚 Sistema de Gestión de Biblioteca (Console App C#)

**Sistema de Gestión de Biblioteca** de Biblioteca Heisenberg. Una aplicación de consola desarrollada en C#, diseñada siguiendo los lineamientos y especificaciones de la guía **GFPI-F-135 V04** del SENA (Tecnología en Análisis y Desarrollo de Software - ADSO).

---

## 📌 Tabla de Contenidos

1. [Descripción General](#-descripción-general)
2. [Características Principales](#-características-principales)
3. [Evidencia de Ejecución](#-evidencia-de-ejecución)


---

## 📖 Descripción General

Este proyecto simula la gestión administrativa de una biblioteca. Permite el control de inventario de libros, registro y administración de usuarios, procesamiento de préstamos y devoluciones, consultas mediante reportes y la gestión de la persistencia de datos en disco.

El desarrollo prioriza los conceptos de programación estructural vistos hasta ahora (métodos estáticos, paso de parámetros, control estricto de bucles `do-while` y validación de entradas mediante `int.TryParse`), evitando el uso de Programación Orientada a Objetos (POO) según los requerimientos formativos.

---

## ✨ Características Principales

- **Módulo de Libros:** Registrar, listar (todos, disponibles, prestados), actualizar y eliminar libros.
- **Módulo de Usuarios:** Registro, actualización, listado e inactivación de usuarios.
- **Módulo de Préstamos:** Registro de préstamos con verificación de reglas de negocio, detalle por ID, devoluciones y anulación/eliminación bajo restricciones administrativas.
- **Búsqueda y Reportes:** Filtros combinados de libros (título, autor, ID, categoría), búsquedas de usuarios y reportes resumidos/vencidos.
- **Persistencia de Datos:** Simulación/ejecución de guardado, carga y reinicio de datos con validación de confirmación `(S/N)`.
- **Flujo de Salida Limpio:** Salida controlada con prompt de guardado previo y limpieza de interfaz en consola.

---

## 📸 Evidencia de Ejecución

### 1. Menú Principal
Muestra de la interfaz del menú principal al ejecutar la aplicación.

![Menú Principal](/BibliotecaHeisenberg/evidencias/Salida1MenuPpal.png)

---

### 2. Módulo de Libros y Submenú de Listado
Evidencia de la navegación en el menú de libros (1) y el submenú interactivo para listar libros por estado (1.2).

| Menú de Libros | Submenú Listar Libros (1.1) |
|:---:|:---:|
| ![Menú Libros](/BibliotecaHeisenberg/evidencias/Salida2MenuLibros.png) | ![Submenú Registrar libro](/BibliotecaHeisenberg/evidencias/Salida3RegistrarLibro.png) |

---

### 3. Módulo de Usuarios
Navegación e interacciones del módulo de administración de usuarios (2).

![Módulo Usuarios](/BibliotecaHeisenberg/evidencias/Salida4MenuUsuarios.png)

---

### 4. Módulo de Préstamos
Navegación del módulo de préstamos 

![Módulo Préstamos](/BibliotecaHeisenberg/evidencias/Salida5MenuPrestamos.png)

---

### 5. Búsqueda y Reportes
Ejecución de los submenús de búsqueda (4.1, 4.2) y generación de reportes (4.3).

![Búsqueda y Reportes](/BibliotecaHeisenberg/evidencias/Salida6BusquedaReportes.png)

![Búsqueda y Reportes - Busqueda de Libro](/BibliotecaHeisenberg/evidencias/Salida7BusquedaLibro.png)

![Búsqueda y Reportes - Busqueda de Usuario](/BibliotecaHeisenberg/evidencias/Salida8BusquedaUsuario.png)

![Búsqueda y Reportes - REPORTES](/BibliotecaHeisenberg/evidencias/Salida9Reportes.png)


---

### 6. Gestión de Datos y Persistencia
Prueba de confirmación `(S/N)` en el reinicio de datos del sistema (5.3).

![Persistencia de Datos](/BibliotecaHeisenberg/evidencias/Salida10PersistenciaDatos.png)

![Persistencia de Datos - Prueba del S/N](/BibliotecaHeisenberg/evidencias/Salida11PersistenciaDatosSN.png)

---

### 7. Flujo de Salida Limpio
Evidencia de la opción 6 (Salir) solicitando guardar datos antes de finalizar la sesión y limpiando la terminal.

![Flujo de Salida](/BibliotecaHeisenberg/evidencias/Salida12FlujoSalida.png)