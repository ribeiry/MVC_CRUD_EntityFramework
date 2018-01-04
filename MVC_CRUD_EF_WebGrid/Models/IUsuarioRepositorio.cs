using System.Collections.Generic;

namespace MVC_CRUD_EF_WebGrid.Models
{
    interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetUsuarioDetalhes();
        Usuario GetUsuarioPorID(int usuarioId);
        void AdicionaUsuario(Usuario usuario);
        void DeletaUsuario(int UsuarioID);
        void AtualizaUsuario(Usuario usuario);
        Usuario Detalhes(int usuarioId);

    }
}
