using System;
using System.Collections.Generic;
using BibliotecaHeisenberg.Models;

namespace BibliotecaHeisenberg.Services
{
    public class LibroService
    {
        private List<Libro> listaLibros = new List<Libro>();

        // Operaciones básicas
        public void AgregarLibro(Libro nuevoLibro)
        {
            listaLibros.Add(nuevoLibro);
        }

        public bool EliminarLibro(int idLibro)
        {
            Libro libroAEliminar = null;

            foreach (Libro libroActual in listaLibros)
            {
                if (libroActual.Id == idLibro)
                {
                    libroAEliminar = libroActual;
                    break;
                }
            }

            if (libroAEliminar != null && libroAEliminar.Disponible)
            {
                listaLibros.Remove(libroAEliminar);
                return true;
            }

            return false;
        }

        public List<Libro> ObtenerTodos()
        {
            return listaLibros;
        }

        // Búsquedas (por ISBN, título o autor)
        public Libro BuscarPorIsbn(string isbnBuscado)
        {
            foreach (Libro libroActual in listaLibros)
            {
                if (libroActual.ISBN.ToLower() == isbnBuscado.ToLower())
                {
                    return libroActual;
                }
            }
            return null;
        }

        public Libro BuscarPorId(int idBuscado)
        {
            foreach (Libro libroActual in listaLibros)
            {
                if (libroActual.Id == idBuscado)
                {
                    return libroActual;
                }
            }
            return null;
        }

        public List<Libro> BuscarPorTitulo(string tituloBuscado)
        {
            List<Libro> librosEncontrados = new List<Libro>();

            foreach (Libro libroActual in listaLibros)
            {
                if (libroActual.Titulo.ToLower().Contains(tituloBuscado.ToLower()))
                {
                    librosEncontrados.Add(libroActual);
                }
            }

            return librosEncontrados;
        }

        public List<Libro> BuscarPorAutor(string autorBuscado)
        {
            List<Libro> librosEncontrados = new List<Libro>();

            foreach (Libro libroActual in listaLibros)
            {
                if (libroActual.Autor.ToLower().Contains(autorBuscado.ToLower()))
                {
                    librosEncontrados.Add(libroActual);
                }
            }

            return librosEncontrados;
        }

        // Ordenación (por título o año)
        public List<Libro> OrdenarPorTitulo()
        {
            List<Libro> librosOrdenados = new List<Libro>(listaLibros);

            for (int indicePasada = 0; indicePasada < librosOrdenados.Count - 1; indicePasada++)
            {
                for (int indiceComparacion = 0; indiceComparacion < librosOrdenados.Count - indicePasada - 1; indiceComparacion++)
                {
                    if (librosOrdenados[indiceComparacion].Titulo.CompareTo(librosOrdenados[indiceComparacion + 1].Titulo) > 0)
                    {
                        Libro libroTemporal = librosOrdenados[indiceComparacion];
                        librosOrdenados[indiceComparacion] = librosOrdenados[indiceComparacion + 1];
                        librosOrdenados[indiceComparacion + 1] = libroTemporal;
                    }
                }
            }

            return librosOrdenados;
        }

        public List<Libro> OrdenarPorAnio()
        {
            List<Libro> librosOrdenados = new List<Libro>(listaLibros);

            for (int indicePasada = 0; indicePasada < librosOrdenados.Count - 1; indicePasada++)
            {
                for (int indiceComparacion = 0; indiceComparacion < librosOrdenados.Count - indicePasada - 1; indiceComparacion++)
                {
                    if (librosOrdenados[indiceComparacion].Anio > librosOrdenados[indiceComparacion + 1].Anio)
                    {
                        Libro libroTemporal = librosOrdenados[indiceComparacion];
                        librosOrdenados[indiceComparacion] = librosOrdenados[indiceComparacion + 1];
                        librosOrdenados[indiceComparacion + 1] = libroTemporal;
                    }
                }
            }

            return librosOrdenados;
        }

        // KPIs y estadísticas
        public int TotalLibros()
        {
            return listaLibros.Count;
        }

        public int TotalDisponibles()
        {
            int cantidadDisponibles = 0;

            foreach (Libro libroActual in listaLibros)
            {
                if (libroActual.Disponible)
                {
                    cantidadDisponibles++;
                }
            }

            return cantidadDisponibles;
        }

        public int TotalPrestados()
        {
            int cantidadPrestados = 0;

            foreach (Libro libroActual in listaLibros)
            {
                if (!libroActual.Disponible)
                {
                    cantidadPrestados++;
                }
            }

            return cantidadPrestados;
        }
    }
}