namespace BibliotecaHeisenberg.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public string Categoria { get; set; }
        public bool Disponible { get; set; }

        public Libro()
        {
            Disponible = true;
        }

        public Libro(int id, string isbn, string titulo, string autor, int anio, string categoria)
        {
            Id = id;
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
            Categoria = categoria;
            Disponible = true;
        }

        public string ResumenCorto()
        {
            string estado = Disponible ? "Disponible" : "Prestado";
            return $"[{Id}] {Titulo} - {Autor} ({estado})";
        }

        public string DetalleCompleto()
        {
            string estado = Disponible ? "Sí" : "No";
            return $"ID: {Id}\nISBN: {ISBN}\nTítulo: {Titulo}\nAutor: {Autor}\nAño: {Anio}\nCategoría: {Categoria}\nDisponible: {estado}";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}