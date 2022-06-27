using Microsoft.EntityFrameworkCore;
using RegistroCompras.DAL;
using RegistroCompras.Models;
using System.Linq.Expressions;

namespace RegistroCompras.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(ComprasId Productos)
        {
            if (!Existe(Productos.ProductoId))
            {
                return Insertar(Productos);
            }
            else
            {
                return Modificar(Productos);
            }
        }

        private static bool Modificar(ComprasId productos)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
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

        private static bool Insertar(ComprasId productos)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {

                contexto.Productos.Add(productos);
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

        private static bool Existe(int productoId)
        {
            bool encontrado = false;
            Context contexto = new Context();

            try
            {
                encontrado = contexto.Productos.Any(e => e.ProductoId == productoId);
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

        public static ComprasId Buscar(int id)
        {
            Context contexto = new Context();
            ComprasId productos;

            try
            {
                productos = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                var Productos = contexto.Productos.Find(id);
                if (Productos != null)
                {
                    contexto.Productos.Remove(Productos);
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

        public static List<ComprasId> GetList(Expression<Func<ComprasId, bool>> criterio)
        {
            List<ComprasId> lista = new List<ComprasId>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Productos.Where(criterio).ToList();
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
