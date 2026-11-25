using System;
using System.Collections.Generic;
using BibliotecaHeisenberg.Models;

namespace BibliotecaHeisenberg.Services
{
    public class PrestamoService
    {
        private List<Prestamo> listaPrestamos = new List<Prestamo>();

        // Operaciones básicas
        public void AgregarPrestamo(Prestamo nuevoPrestamo)
        {
            listaPrestamos.Add(nuevoPrestamo);
        }

        public bool EliminarPrestamo(int idPrestamo)
        {
            Prestamo prestamoAEliminar = null;

            foreach (Prestamo prestamoActual in listaPrestamos)
            {
                if (prestamoActual.Id == idPrestamo)
                {
                    prestamoAEliminar = prestamoActual;
                    break;
                }
            }

            if (prestamoAEliminar != null)
            {
                listaPrestamos.Remove(prestamoAEliminar);
                return true;
            }

            return false;
        }

        public List<Prestamo> ObtenerTodos()
        {
            return listaPrestamos;
        }

        // Búsquedas (por ID o estado)
        public Prestamo BuscarPorId(int idBuscado)
        {
            foreach (Prestamo prestamoActual in listaPrestamos)
            {
                if (prestamoActual.Id == idBuscado)
                {
                    return prestamoActual;
                }
            }
            return null;
        }

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estadoBuscado)
        {
            List<Prestamo> prestamosEncontrados = new List<Prestamo>();

            foreach (Prestamo prestamoActual in listaPrestamos)
            {
                if (prestamoActual.Estado == estadoBuscado)
                {
                    prestamosEncontrados.Add(prestamoActual);
                }
            }

            return prestamosEncontrados;
        }

        // Ordenación (por fecha límite)
        public List<Prestamo> OrdenarPorFechaLimite()
        {
            List<Prestamo> prestamosOrdenados = new List<Prestamo>(listaPrestamos);

            for (int indicePasada = 0; indicePasada < prestamosOrdenados.Count - 1; indicePasada++)
            {
                for (int indiceComparacion = 0; indiceComparacion < prestamosOrdenados.Count - indicePasada - 1; indiceComparacion++)
                {
                    if (prestamosOrdenados[indiceComparacion].FechaLimite > prestamosOrdenados[indiceComparacion + 1].FechaLimite)
                    {
                        Prestamo prestamoTemporal = prestamosOrdenados[indiceComparacion];
                        prestamosOrdenados[indiceComparacion] = prestamosOrdenados[indiceComparacion + 1];
                        prestamosOrdenados[indiceComparacion + 1] = prestamoTemporal;
                    }
                }
            }

            return prestamosOrdenados;
        }

        // KPIs y estadísticas
        public int TotalPrestamos()
        {
            return listaPrestamos.Count;
        }

        public int TotalActivos()
        {
            int cantidadActivos = 0;

            foreach (Prestamo prestamoActual in listaPrestamos)
            {
                if (prestamoActual.Estado == EstadoPrestamo.Activo)
                {
                    cantidadActivos++;
                }
            }

            return cantidadActivos;
        }

        public int TotalVencidos()
        {
            int cantidadVencidos = 0;

            foreach (Prestamo prestamoActual in listaPrestamos)
            {
                if (prestamoActual.EstaVencido() || prestamoActual.Estado == EstadoPrestamo.Vencido)
                {
                    cantidadVencidos++;
                }
            }

            return cantidadVencidos;
        }

        public int TotalDevueltos()
        {
            int cantidadDevueltos = 0;

            foreach (Prestamo prestamoActual in listaPrestamos)
            {
                if (prestamoActual.Estado == EstadoPrestamo.Devuelto)
                {
                    cantidadDevueltos++;
                }
            }

            return cantidadDevueltos;
        }

        public double PromedioDiasPrestamo()
        {
            if (listaPrestamos.Count == 0)
            {
                return 0;
            }

            double sumaTotalDias = 0;

            foreach (Prestamo prestamoActual in listaPrestamos)
            {
                sumaTotalDias += prestamoActual.DiasTranscurridos();
            }

            return sumaTotalDias / listaPrestamos.Count;
        }
    }
}