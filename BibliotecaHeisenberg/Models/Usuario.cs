namespace BibliotecaHeisenberg.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public bool Activo { get; set; }

        public Usuario()
        {
            Activo = true;
        }

        public Usuario(int id, string documento, string nombre, string contacto)
        {
            Id = id;
            Documento = documento;
            Nombre = nombre;
            Contacto = contacto;
            Activo = true;
        }

        public string ResumenCorto()
        {
            string estado = Activo ? "Activo" : "Inactivo";
            return $"[{Id}] {Nombre} (Doc: {Documento}) - {estado}";
        }

        public string DetalleCompleto()
        {
            string estado = Activo ? "Sí" : "No";
            return $"ID: {Id}\nDocumento: {Documento}\nNombre: {Nombre}\nContacto: {Contacto}\nActivo: {estado}";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}