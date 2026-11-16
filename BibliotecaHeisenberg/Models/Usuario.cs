namespace SistemaBiblioteca.Models
{
    public class Usuario
    {
        public int Id
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Documento
        {
            get { return Documento; }
            set { Documento = value; }
        }
        public string Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public string Contacto
        {
            get { return Contacto; }
            set { Contacto = value; }
        }
        public bool Activo
        {
            get { return Activo; }
            set { Activo = value; }
        }

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