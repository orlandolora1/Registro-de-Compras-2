using Microsoft.EntityFrameworkCore;
using RegistroCompras.DAL;
using RegistroCompras.Models;
using System.Linq.Expressions;

namespace RegistroCompras.BLL
{
    public class ComprasBLL
    {
        public static bool Guardar(Compras Compras)
        {
            if (!Existe(Compras.CompraId))
            {
                return Insertar(Compras);
            }
            else
            {
                return Modificar(Compras);
            }
        }

        private static bool Existe(int compraId)
        {
            bool encontrado = false;
            Context contexto = new Context();

            try
            {
                encontrado = contexto.Compras.Any(e => e.ProductoId == compraId);
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
        private static bool Insertar(Compras compras)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Compras.Add(compras);

                foreach (var detalle in compras.Detalle)
                {
                    compras.Total += detalle.Costo;
                    contexto.Entry(detalle.producto).State = EntityState.Modified;
                }
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

        private static bool Modificar(Compras compras)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                var compraAnterior = contexto.Compras
                     .Where(x => x.CompraId == compras.CompraId)
                     .Include(x => x.Detalle)
                     .AsNoTracking()
                     .SingleOrDefault();

                foreach (var detalle in compraAnterior.Detalle)
                {
                    compras.Total -= detalle.Costo;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalle Where CompraId ={compras.CompraId}");

                foreach (var detalle in compraAnterior.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.producto).State = EntityState.Modified;
                    compras.Total += detalle.Costo;
                }

                contexto.Entry(compras).State = EntityState.Modified;

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

        public static Compras Buscar(int id)
        {
            Context contexto = new Context();
            Compras compra;

            try
            {
                compra = contexto.Compras.Include(x => x.Detalle)
                    .Where(x => x.CompraId == id)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.producto)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return compra;
        }

        public static bool Eliminar(int id)
        {
            Context contexto = new Context();
            bool paso = false;

            try
            {
                var compra = Buscar(id);
                if (compra != null)
                {
                    foreach (var item in compra.Detalle)
                    {
                        contexto.Entry(item.producto).State = EntityState.Modified;
                        compra.Total -= item.Costo;
                    }

                    contexto.Compras.Remove(compra);
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
        public static List<Compras> GetList(Expression<Func<Compras, bool>> criterio)
        {
            List<Compras> lista = new List<Compras>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Compras.Where(criterio).ToList();
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
