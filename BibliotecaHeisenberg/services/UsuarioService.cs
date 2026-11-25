using System;
using System.Collections.Generic;
using BibliotecaHeisenberg.Models;

namespace BibliotecaHeisenberg.Services
{
    public class UsuarioService
    {
        private List<Usuario> listaUsuarios = new List<Usuario>();

        // Operaciones básicas
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            listaUsuarios.Add(nuevoUsuario);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            Usuario usuarioAEliminar = null;

            foreach (Usuario usuarioActual in listaUsuarios)
            {
                if (usuarioActual.Id == idUsuario)
                {
                    usuarioAEliminar = usuarioActual;
                    break;
                }
            }

            if (usuarioAEliminar != null)
            {
                listaUsuarios.Remove(usuarioAEliminar);
                return true;
            }

            return false;
        }

        public List<Usuario> ObtenerTodos()
        {
            return listaUsuarios;
        }

        // Búsquedas (por documento o nombre)
        public Usuario BuscarPorDocumento(string documentoBuscado)
        {
            foreach (Usuario usuarioActual in listaUsuarios)
            {
                if (usuarioActual.Documento.ToLower() == documentoBuscado.ToLower())
                {
                    return usuarioActual;
                }
            }
            return null;
        }

        public List<Usuario> BuscarPorNombre(string nombreBuscado)
        {
            List<Usuario> usuariosEncontrados = new List<Usuario>();

            foreach (Usuario usuarioActual in listaUsuarios)
            {
                if (usuarioActual.Nombre.ToLower().Contains(nombreBuscado.ToLower()))
                {
                    usuariosEncontrados.Add(usuarioActual);
                }
            }

            return usuariosEncontrados;
        }

        // Ordenación (por nombre)
        public List<Usuario> OrdenarPorNombre()
        {
            List<Usuario> usuariosOrdenados = new List<Usuario>(listaUsuarios);

            for (int indicePasada = 0; indicePasada < usuariosOrdenados.Count - 1; indicePasada++)
            {
                for (int indiceComparacion = 0; indiceComparacion < usuariosOrdenados.Count - indicePasada - 1; indiceComparacion++)
                {
                    if (usuariosOrdenados[indiceComparacion].Nombre.CompareTo(usuariosOrdenados[indiceComparacion + 1].Nombre) > 0)
                    {
                        Usuario usuarioTemporal = usuariosOrdenados[indiceComparacion];
                        usuariosOrdenados[indiceComparacion] = usuariosOrdenados[indiceComparacion + 1];
                        usuariosOrdenados[indiceComparacion + 1] = usuarioTemporal;
                    }
                }
            }

            return usuariosOrdenados;
        }

        // KPIs y estadísticas
        public int TotalUsuarios()
        {
            return listaUsuarios.Count;
        }

        public int TotalActivos()
        {
            int cantidadActivos = 0;

            foreach (Usuario usuarioActual in listaUsuarios)
            {
                if (usuarioActual.Activo)
                {
                    cantidadActivos++;
                }
            }

            return cantidadActivos;
        }

        public int TotalInactivos()
        {
            int cantidadInactivos = 0;

            foreach (Usuario usuarioActual in listaUsuarios)
            {
                if (!usuarioActual.Activo)
                {
                    cantidadInactivos++;
                }
            }

            return cantidadInactivos;
        }
    }
}