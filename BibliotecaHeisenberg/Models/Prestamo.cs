using System;

namespace BibliotecaHeisenberg.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Libro LibroPrestado { get; set; }
        public Usuario UsuarioPrestatario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }

        // Constructor vacío
        public Prestamo()
        {
            Estado = EstadoPrestamo.Activo;
            FechaDevolucion = null;
        }

        // Constructor completo
        public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo, DateTime fechaLimite)
        {
            Id = id;
            LibroPrestado = libro;
            UsuarioPrestatario = usuario;
            FechaPrestamo = fechaPrestamo;
            FechaLimite = fechaLimite;
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
        }

        public bool EstaVencido()
        {
            if (Estado == EstadoPrestamo.Devuelto)
            {
                return false;
            }
            return DateTime.Now > FechaLimite;
        }

        public int DiasTranscurridos()
        {
            DateTime fechaFin = FechaDevolucion ?? DateTime.Now;
            return (fechaFin - FechaPrestamo).Days;
        }

        public string ResumenCorto()
        {
            return $"Préstamo #{Id} | Libro: {LibroPrestado?.Titulo} | Usuario: {UsuarioPrestatario?.Nombre} | Estado: {Estado}";
        }

        public string DetalleCompleto()
        {
            string dev = FechaDevolucion.HasValue ? FechaDevolucion.Value.ToShortDateString() : "Pendiente";
            return $"ID Préstamo: {Id}\n" +
                   $"Libro: {LibroPrestado?.Titulo} (ISBN: {LibroPrestado?.ISBN})\n" +
                   $"Usuario: {UsuarioPrestatario?.Nombre} (Doc: {UsuarioPrestatario?.Documento})\n" +
                   $"Fecha Préstamo: {FechaPrestamo.ToShortDateString()}\n" +
                   $"Fecha Límite: {FechaLimite.ToShortDateString()}\n" +
                   $"Fecha Devolución: {dev}\n" +
                   $"Estado: {Estado}\n" +
                   $"Días transcurridos: {DiasTranscurridos()}\n" +
                   $"¿Está vencido?: {(EstaVencido() ? "Sí" : "No")}";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}
