namespace SistemaBiblioteca.Models
{
    public class Libro
    {
        public int Id
        {
            get { return Id; }
            set { Id = value; }
        }
        public string ISBN
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        public string Titulo
        {
            get { return Titulo; }
            set { Titulo = value; }
        }
        public string Autor
        {
            get { return Autor; }
            set { Autor = value; }
        }
        public string Categoria
        {
            get { return Categoria; }
            set { Categoria = value; }
        }
        public int Anio
        {
            get { return Anio; }
            set { Anio = value; }
        }
        public bool Disponible
        {
            get { return Disponible; }
            set { Disponible = value; }
        }
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