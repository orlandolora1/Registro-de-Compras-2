using Microsoft.EntityFrameworkCore;
using RegistroCompras.DAL;
using RegistroCompras.Models;
using System.Linq.Expressions;

namespace RegistroCompras.BLL
{
    public class CategoriasBLL
    {
        public static bool Guardar(Categorias Categorias)
        {
            if (!Existe(Categorias.CategoriaId))
            {
                return Insertar(Categorias);
            }
            else
            {
                return Modificar(Categorias);
            }
        }

        private static bool Modificar(Categorias categorias)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Entry(categorias).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Insertar(Categorias categorias)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {

                contexto.Categorias.Add(categorias);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Existe(int categoriaId)
        {
            bool encontrado = false;
            Context contexto = new Context();

            try
            {
                encontrado = contexto.Categorias.Any(e => e.CategoriaId == categoriaId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static Categorias Buscar(int id)
        {
            Context contexto = new Context();
            Categorias Categorias;

            try
            {
                Categorias = contexto.Categorias.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Categorias;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                var Categorias = contexto.Categorias.Find(id);
                if (Categorias != null)
                {
                    contexto.Categorias.Remove(Categorias);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> criterio)
        {
            List<Categorias> lista = new List<Categorias>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Categorias.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
