using Microsoft.EntityFrameworkCore;
using PrimerParcial.DAL;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerParcial.BLL
{
    public class ArticulosBLL
    {
        public class PrestamoBLL
        {
            public static bool Guardar(Articulos articulos)
            {
                if (!Existe(articulos.ArticuloId))
                    return Insertar(articulos);
                else
                    return Modificar(articulos);
            }

            private static bool Insertar(Articulos articulos)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Articulos.Add(articulos);
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

            public static bool Modificar(Articulos articulos)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Entry(articulos).State = EntityState.Modified;
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

            public static bool Eliminar(int id)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    var aux = contexto.Articulos.Find(id);
                    if (aux != null)
                    {

                        contexto.Articulos.Remove(aux);
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

            public static Articulos Buscar(int id)
            {
                Contexto contexto = new Contexto();
                Articulos articulos;

                try
                {
                    articulos = contexto.Articulos.Find(id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
                return articulos;
            }

            public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulos)
            {
                List<Articulos> lista = new List<Articulos>();
                Contexto db = new Contexto();

                try
                {
                    lista = db.Articulos.Where(articulos).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    db.Dispose();
                }

                return lista;
            }

            public static bool Existe(int id)
            {
                Contexto contexto = new Contexto();
                bool encontrado = false;
                try
                {
                    encontrado = contexto.Articulos.Any(a => a.ArticuloId == id);
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
        }
    }
}
