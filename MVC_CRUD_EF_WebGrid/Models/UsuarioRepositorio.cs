using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_EF_WebGrid.Models
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        CadastroEntities2 db = new CadastroEntities2();

        public UsuarioRepositorio()
        {
            this.db = new CadastroEntities2();
        }

        public UsuarioRepositorio(CadastroEntities2 ctx)
        {
            this.db = ctx;
        }

        public void AdicionaUsuario(Usuario usuario)
        {
            try
            {
                db.Usuario.Add(usuario);                
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(db != null)
                {
                    db.Dispose();
                }
            }
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            try
            {
                var novoUsuario = db.Usuario.Where(x => x.usuarioID == usuario.usuarioID).FirstOrDefault();
                novoUsuario.usuarioNome = usuario.usuarioNome;
                novoUsuario.usuarioEmail = usuario.usuarioEmail;
                novoUsuario.usuarioSenha = usuario.usuarioSenha;
                db.SaveChanges();
                novoUsuario = null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(db != null)
                {
                    db.Dispose();
                }
            }
        }

        public void DeletaUsuario(int usuarioId)
        {
            try
            {
                Usuario _usuario = db.Usuario.SingleOrDefault(x => x.usuarioID == usuarioId);
                db.Usuario.Remove(_usuario);
                db.SaveChanges();
                _usuario = null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(db != null)
                {
                    db.Dispose();
                }
            }
        }

        public Usuario Detalhes(int usuarioId)
        {
            try
            {
                dynamic obj = new Usuario();
                obj = db.Usuario.SingleOrDefault(s => s.usuarioID == usuarioId);
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(db != null)
                {
                    db.Dispose();

                }
            }
        }

        public IEnumerable<Usuario> GetUsuarioDetalhes()
        {
            try
            {
                return db.Usuario.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(db != null)
                {
                    db.Dispose();
                }
            }
        }

        public Usuario GetUsuarioPorID(int usuarioId)
        {
            try
            {
                return db.Usuario.SingleOrDefault(x => x.usuarioID == usuarioId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(db != null)
                {
                    db.Dispose();
                }
            }
        }
    }
}