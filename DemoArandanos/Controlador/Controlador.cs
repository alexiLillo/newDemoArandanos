using DemoArandanos.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace DemoArandanos.Controlador
{
    public class Controler
    {
        Modelo.Modelo contexto = new Modelo.Modelo();
        public int login(string usuario, string contraseña)
        {
            int login = 0;
            var contactQuery = from u in contexto.Usuarios select u;
            foreach (var resultado in contactQuery)
            {
                if (resultado.user == usuario && resultado.pass == contraseña)
                {
                    if (resultado.tipo.Equals("admin"))
                        login = 1;
                    if (resultado.tipo.Equals("normal"))
                        login = 2;
                    if (resultado.tipo.Equals("informes"))
                        login = 3;
                }
            }
            return login;
        }

        //ADMINISTRACION DE USUARIOS

        public void insertarUsuario(String usuario, String contraseña, String tipo_usuario)
        {
            contexto.Usuarios.Add(new Modelo.Usuarios { user = usuario, pass = contraseña, tipo = tipo_usuario });
            contexto.SaveChanges();
        }

        public void eliminarUsuario(String usuario, String contraseña)
        {
            Modelo.Usuarios user = (from u in contexto.Usuarios
                                    where u.user == usuario
                                    && u.pass == contraseña
                                    select u).FirstOrDefault();
            contexto.Usuarios.Remove(user);
            contexto.SaveChanges();
        }

        public String getTipoUser(String usuario, String contraseña)
        {
            return (from u in contexto.Usuarios
                    where u.user == usuario
                    && u.pass == contraseña
                    select u.tipo).FirstOrDefault();
        }

        public void insertarSyncUsuario(String usuario, String contraseña, String tipo_usuario, int id_usuario, String operacion_sql)
        {
            contexto.SyncUsuarios.Add(new Modelo.SyncUsuarios { user = usuario, pass = contraseña, tipo = tipo_usuario, id_usuario = id_usuario, OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRACION DE FUNDOS

        public void insertarFundo(String id_fundo, String nombre)
        {
            contexto.Fundo.Add(new Fundo { ID_Fundo = id_fundo.ToUpper().Replace(",", "."), Nombre = nombre.ToUpper().Replace(",", ".") });
            contexto.SaveChanges();
        }

        public void eliminarFundo(String id_fundo)
        {
            Fundo fundo = (from f in contexto.Fundo
                           where f.ID_Fundo == id_fundo.ToUpper()
                           select f).FirstOrDefault();
            contexto.Fundo.Remove(fundo);
            contexto.SaveChanges();
        }

        public void actualizarFundo(String id_fundo, String nombre)
        {
            Fundo fundo = (from f in contexto.Fundo
                           where f.ID_Fundo == id_fundo.ToUpper()
                           select f).FirstOrDefault();
            fundo.Nombre = nombre.ToUpper().Replace(",", ".");
            contexto.SaveChanges();
        }

        public void insertarSyncFundo(String id_fundo, String nombre, String operacion_sql)
        {
            contexto.SyncFundo.Add(new SyncFundo { ID_Fundo = id_fundo.ToUpper().Replace(",", "."), Nombre = nombre.ToUpper().Replace(",", "."), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRACION DE POTREROS

        public void insertarPotrero(String id_potrero, String id_fundo, String nombre)
        {
            contexto.Potrero.Add(new Potrero { ID_Potrero = id_potrero.ToUpper().Replace(",", "."), ID_Fundo = id_fundo.ToUpper(), Nombre = nombre.ToUpper().Replace(",", ".") });
            contexto.SaveChanges();
        }

        public void eliminarPotrero(String id_potrero, String id_fundo)
        {
            Potrero potrero = (from p in contexto.Potrero
                               where p.ID_Potrero == id_potrero.ToUpper()
                                     && p.ID_Fundo == id_fundo.ToUpper()
                               select p).FirstOrDefault();
            contexto.Potrero.Remove(potrero);
            contexto.SaveChanges();
        }

        public void actualizarPotrero(String id_potrero, String id_fundo, String nombre)
        {
            Potrero potrero = (from p in contexto.Potrero
                               where p.ID_Potrero == id_potrero.ToUpper()
                                        && p.ID_Fundo == id_fundo.ToUpper()
                               select p).FirstOrDefault();
            potrero.Nombre = nombre.ToUpper().Replace(",", ".");
            contexto.SaveChanges();
        }

        public void insertarSyncPotrero(String id_potrero, String id_fundo, String nombre, String operacion_sql)
        {
            contexto.SyncPotrero.Add(new SyncPotrero { ID_Potrero = id_potrero.ToUpper().Replace(",", "."), ID_Fundo = id_fundo.ToUpper(), Nombre = nombre.ToUpper().Replace(",", "."), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRACION DE SECTORES

        public void insertarSector(String id_sector, String id_potrero, String id_fundo, String nombre)
        {
            contexto.Sector.Add(new Sector { ID_Sector = id_sector.ToUpper().Replace(",", "."), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Nombre = nombre.ToUpper().Replace(",", ".") });
            contexto.SaveChanges();
        }

        public void actualizarSector(String id_sector, String id_potrero, String id_fundo, String nombre)
        {
            Sector sector = (from s in contexto.Sector
                             where s.ID_Sector == id_sector.ToUpper()
                                    && s.ID_Potrero == id_potrero.ToUpper()
                                    && s.ID_Fundo == id_fundo.ToUpper()
                             select s).FirstOrDefault();
            sector.Nombre = nombre.ToUpper().Replace(",", ".");
            contexto.SaveChanges();
        }

        public void eliminarSector(String id_sector, String id_potrero, String id_fundo)
        {
            Sector sector = (from s in contexto.Sector
                             where s.ID_Sector == id_sector.ToUpper()
                                    && s.ID_Potrero == id_potrero.ToUpper()
                                    && s.ID_Fundo == id_fundo.ToUpper()
                             select s).FirstOrDefault();
            contexto.Sector.Remove(sector);
            contexto.SaveChanges();
        }

        public void insertarSyncSector(String id_sector, String id_potrero, String id_fundo, String nombre, String operacion_sql)
        {
            contexto.SyncSector.Add(new SyncSector { ID_Sector = id_sector.ToUpper().Replace(",", "."), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Nombre = nombre.ToUpper().Replace(",", "."), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRACION DE CUARTELES

        public void insertarCuartel(String id_cuartel, String id_sector, String id_potrero, String id_fundo, String superficie, String nombre)
        {
            contexto.Cuartel.Add(new Cuartel { ID_Cuartel = id_cuartel.ToUpper().Replace(",", "."), ID_Sector = id_sector.ToUpper(), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Superficie = Double.Parse(superficie.ToUpper().Replace(",", ".")), Nombre = nombre.ToUpper().Replace(",", ".") });
            contexto.SaveChanges();
        }

        public void actualizarCuartel(String id_cuartel, String id_sector, String id_potrero, String id_fundo, String nombre, String superficie)
        {
            Cuartel cuartel = (from c in contexto.Cuartel
                               where c.ID_Cuartel == id_cuartel.ToUpper()
                                        && c.ID_Sector == id_sector.ToUpper()
                                        && c.ID_Potrero == id_potrero.ToUpper()
                                        && c.ID_Fundo == id_fundo.ToUpper()
                               select c).FirstOrDefault();
            cuartel.Superficie = Double.Parse(superficie.ToUpper().Replace(",", "."));
            cuartel.Nombre = nombre.ToUpper().Replace(",", ".");
            contexto.SaveChanges();
        }

        public void eliminarCuartel(String id_cuartel, String id_sector, String id_potrero, String id_fundo)
        {
            Cuartel cuartel = (from c in contexto.Cuartel
                               where c.ID_Cuartel == id_cuartel.ToUpper()
                                        && c.ID_Sector == id_sector.ToUpper()
                                        && c.ID_Potrero == id_potrero.ToUpper()
                                        && c.ID_Fundo == id_fundo.ToUpper()
                               select c).FirstOrDefault();
            contexto.Cuartel.Remove(cuartel);
            contexto.SaveChanges();
        }

        public void insertarSyncCuartel(String id_cuartel, String id_sector, String id_potrero, String id_fundo, String superficie, String nombre, String operacion_sql)
        {
            contexto.SyncCuartel.Add(new SyncCuartel { ID_Cuartel = id_cuartel.ToUpper().Replace(",", "."), ID_Sector = id_sector.ToUpper(), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Superficie = Double.Parse(superficie.ToUpper().Replace(",", ".")), Nombre = nombre.ToUpper().Replace(",", "."), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRACION DE HILERAS

        public List<String> variedades(String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, int id_mapeo)
        {
            List<string> variedades = new List<string>();
            if (id_fundo.Equals("0"))
            {
                variedades = (from h in contexto.Hilera
                              where h.ID_Mapeo == id_mapeo
                              select h.Variedad).Distinct().ToList();
            }
            if (id_potrero.Equals("0"))
            {
                variedades = (from h in contexto.Hilera
                              where h.ID_Mapeo == id_mapeo
                              && h.ID_Fundo == id_fundo
                              select h.Variedad).Distinct().ToList();
            }
            if (id_sector.Equals("0"))
            {
                variedades = (from h in contexto.Hilera
                              where h.ID_Mapeo == id_mapeo
                              && h.ID_Fundo == id_fundo
                              && h.ID_Potrero == id_potrero
                              select h.Variedad).Distinct().ToList();
            }
            if (id_cuartel.Equals("0"))
            {
                variedades = (from h in contexto.Hilera
                              where h.ID_Mapeo == id_mapeo
                              && h.ID_Fundo == id_fundo
                              && h.ID_Potrero == id_potrero
                              && h.ID_Sector == id_sector
                              select h.Variedad).Distinct().ToList();
            }
            if (id_hilera.Equals("0"))
            {
                variedades = (from h in contexto.Hilera
                              where h.ID_Mapeo == id_mapeo
                              && h.ID_Fundo == id_fundo
                              && h.ID_Potrero == id_potrero
                              && h.ID_Sector == id_sector
                              && h.ID_Cuartel == id_cuartel
                              select h.Variedad).Distinct().ToList();
            }
            if (!id_hilera.Equals("0"))
            {
                variedades = (from h in contexto.Hilera
                              where h.ID_Hilera == id_hilera
                                  && h.ID_Cuartel == id_cuartel
                                  && h.ID_Sector == id_sector
                                  && h.ID_Potrero == id_potrero
                                  && h.ID_Fundo == id_fundo
                                  && h.ID_Mapeo == id_mapeo
                              select h.Variedad).Distinct().ToList();
            }
            return variedades;
        }

        public List<string> listaHileras(String id_cuartel, String id_sector, String id_potrero, String id_fundo, int id_mapeo)
        {
            List<string> list = (from h in contexto.Hilera
                                 where h.ID_Cuartel == id_cuartel
                                     && h.ID_Sector == id_sector
                                     && h.ID_Potrero == id_potrero
                                     && h.ID_Fundo == id_fundo
                                     && h.ID_Mapeo == id_mapeo
                                 select h.ID_Hilera).ToList();
            return list;
        }

        public string getVariedadHilera(String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, int id_mapeo)
        {
            String variedad = (from h in contexto.Hilera
                               where h.ID_Hilera == id_hilera
                                   && h.ID_Cuartel == id_cuartel
                                   && h.ID_Sector == id_sector
                                   && h.ID_Potrero == id_potrero
                                   && h.ID_Fundo == id_fundo
                                   && h.ID_Mapeo == id_mapeo
                               select h.Variedad).FirstOrDefault().ToString();
            return variedad;
        }

        public void insertarHilera(String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, String id_variedad)
        {
            contexto.Hilera.Add(new Hilera { ID_Hilera = id_hilera.ToUpper().Replace(",", "."), ID_Cuartel = id_cuartel.ToUpper(), ID_Sector = id_sector.ToUpper(), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Variedad = id_variedad.ToUpper(), ID_Mapeo = lastMapeo() });
            contexto.SaveChanges();
        }

        public void actualizarHilera(String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, String id_variedad)
        {
            int i = lastMapeo();
            Hilera hilera = (from h in contexto.Hilera
                             where h.ID_Hilera == id_hilera.ToUpper()
                                    && h.ID_Cuartel == id_cuartel.ToUpper()
                                    && h.ID_Sector == id_sector.ToUpper()
                                    && h.ID_Potrero == id_potrero.ToUpper()
                                    && h.ID_Fundo == id_fundo.ToUpper()
                                    && h.ID_Mapeo == i
                             select h).FirstOrDefault();
            hilera.Variedad = id_variedad.ToUpper();
            contexto.SaveChanges();
        }

        public void eliminarHilera(String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo)
        {
            int i = lastMapeo();
            Hilera hilera = (from h in contexto.Hilera
                             where h.ID_Hilera == id_hilera.ToUpper()
                                    && h.ID_Cuartel == id_cuartel.ToUpper()
                                    && h.ID_Sector == id_sector.ToUpper()
                                    && h.ID_Potrero == id_potrero.ToUpper()
                                    && h.ID_Fundo == id_fundo.ToUpper()
                                    && h.ID_Mapeo == i
                             select h).FirstOrDefault();
            contexto.Hilera.Remove(hilera);
            contexto.SaveChanges();
        }

        public void insertarSyncHilera(String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, String variedad, String operacion_sql)
        {
            contexto.SyncHilera.Add(new SyncHilera { ID_Hilera = id_hilera.ToUpper().Replace(",", "."), ID_Cuartel = id_cuartel.ToUpper(), ID_Sector = id_sector.ToUpper(), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Variedad = variedad.ToUpper(), ID_Mapeo = lastMapeo(), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRACION DE PLANTAS

        public List<string> listaEstadosPlantas(String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, int id_mapeo)
        {
            List<string> list = (from pl in contexto.Planta
                                 where pl.ID_Hilera == id_hilera
                                     && pl.ID_Cuartel == id_cuartel
                                     && pl.ID_Sector == id_sector
                                     && pl.ID_Potrero == id_potrero
                                     && pl.ID_Fundo == id_fundo
                                     && pl.ID_Mapeo == id_mapeo
                                 select pl.ID_Planta + pl.Estado).ToList();
            return list;
        }

        public List<string> listaIDPlantas(String id_cuartel, String id_sector, String id_potrero, String id_fundo, int id_mapeo)
        {
            List<string> list = (from pl in contexto.Planta
                                 where pl.ID_Cuartel == id_cuartel
                                     && pl.ID_Sector == id_sector
                                     && pl.ID_Potrero == id_potrero
                                     && pl.ID_Fundo == id_fundo
                                     && pl.ID_Mapeo == id_mapeo
                                 select pl.ID_Planta).Distinct().ToList();
            return list;
        }

        public int lastMapeo()
        {
            int mapeo = (from m in contexto.Map select m.ID_Mapeo).Max();
            return mapeo;
        }

        public void insertarPlanta(String id_planta, String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, String estado, String fecha, String observaciones)
        {
            contexto.Planta.Add(new Planta { ID_Planta = id_planta.ToUpper().Replace(",", "."), ID_Hilera = id_hilera.ToUpper(), ID_Cuartel = id_cuartel.ToUpper(), ID_Sector = id_sector.ToUpper(), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Estado = estado.ToUpper(), Fecha_Plantacion = fecha.ToUpper().Replace(",", "."), Observaciones = observaciones.ToUpper().Replace(",", "."), ID_Mapeo = lastMapeo() });
            contexto.SaveChanges();
        }

        public void actualizarPlanta(String id_planta, String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, String estado, String fecha, String observaciones)
        {
            int i = lastMapeo();
            Planta planta = (from pl in contexto.Planta
                             where pl.ID_Planta == id_planta.ToUpper()
                                    && pl.ID_Hilera == id_hilera.ToUpper()
                                    && pl.ID_Cuartel == id_cuartel.ToUpper()
                                    && pl.ID_Sector == id_sector.ToUpper()
                                    && pl.ID_Potrero == id_potrero.ToUpper()
                                    && pl.ID_Fundo == id_fundo.ToUpper()
                                    && pl.ID_Mapeo == i
                             select pl).FirstOrDefault();
            planta.Estado = estado.ToUpper();
            planta.Fecha_Plantacion = fecha.ToUpper().Replace(",", ".");
            planta.Observaciones = observaciones.ToUpper().Replace(",", ".");
            contexto.SaveChanges();
        }

        public void eliminarPlanta(String id_planta, String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo)
        {
            int i = lastMapeo();
            Planta planta = (from pl in contexto.Planta
                             where pl.ID_Planta == id_planta.ToUpper()
                                    && pl.ID_Hilera == id_hilera.ToUpper()
                                    && pl.ID_Cuartel == id_cuartel.ToUpper()
                                    && pl.ID_Sector == id_sector.ToUpper()
                                    && pl.ID_Potrero == id_potrero.ToUpper()
                                    && pl.ID_Fundo == id_fundo.ToUpper()
                                    && pl.ID_Mapeo == i
                             select pl).FirstOrDefault();
            contexto.Planta.Remove(planta);
            contexto.SaveChanges();
        }

        public int countPlantas(String id_fundo, String id_potrero, String id_sector, String id_cuartel, String id_hilera, String estado, int mapeo, String variedad)
        {
            int cant = 0;
            if (variedad.Equals(""))
            {
                if (id_fundo.Equals("0"))
                {
                    cant = (from pl in contexto.Planta where pl.Estado == estado && pl.ID_Mapeo == mapeo select pl).Count();
                }
                else
                {
                    if (id_potrero.Equals("0"))
                    {
                        cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.Estado == estado && pl.ID_Mapeo == mapeo select pl).Count();
                    }
                    else
                    {
                        if (id_sector.Equals("0"))
                        {
                            cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.Estado == estado && pl.ID_Mapeo == mapeo select pl).Count();
                        }
                        else
                        {
                            if (id_cuartel.Equals("0"))
                            {
                                cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.ID_Sector == id_sector && pl.Estado == estado && pl.ID_Mapeo == mapeo select pl).Count();
                            }
                            else
                            {
                                if (id_hilera.Equals("0"))
                                {
                                    cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.ID_Sector == id_sector && pl.ID_Cuartel == id_cuartel && pl.Estado == estado && pl.ID_Mapeo == mapeo select pl).Count();
                                }
                                else
                                {
                                    if (!id_hilera.Equals("0"))
                                    {
                                        cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.ID_Sector == id_sector && pl.ID_Cuartel == id_cuartel && pl.ID_Hilera == id_hilera && pl.Estado == estado && pl.ID_Mapeo == mapeo select pl).Count();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (id_fundo.Equals("0"))
                {
                    cant = (from pl in contexto.Planta where pl.Estado == estado && pl.ID_Mapeo == mapeo && pl.Hilera.Variedad == variedad select pl).Count();
                }
                else
                {
                    if (id_potrero.Equals("0"))
                    {
                        cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.Estado == estado && pl.ID_Mapeo == mapeo && pl.Hilera.Variedad == variedad select pl).Count();
                    }
                    else
                    {
                        if (id_sector.Equals("0"))
                        {
                            cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.Estado == estado && pl.ID_Mapeo == mapeo && pl.Hilera.Variedad == variedad select pl).Count();
                        }
                        else
                        {
                            if (id_cuartel.Equals("0"))
                            {
                                cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.ID_Sector == id_sector && pl.Estado == estado && pl.ID_Mapeo == mapeo && pl.Hilera.Variedad == variedad select pl).Count();
                            }
                            else
                            {
                                if (id_hilera.Equals("0"))
                                {
                                    cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.ID_Sector == id_sector && pl.ID_Cuartel == id_cuartel && pl.Estado == estado && pl.ID_Mapeo == mapeo && pl.Hilera.Variedad == variedad select pl).Count();
                                }
                                else
                                {
                                    if (!id_hilera.Equals("0"))
                                    {
                                        cant = (from pl in contexto.Planta where pl.ID_Fundo == id_fundo && pl.ID_Potrero == id_potrero && pl.ID_Sector == id_sector && pl.ID_Cuartel == id_cuartel && pl.ID_Hilera == id_hilera && pl.Estado == estado && pl.ID_Mapeo == mapeo && pl.Hilera.Variedad == variedad select pl).Count();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return cant;
        }

        public void insertarSyncPlanta(String id_planta, String id_hilera, String id_cuartel, String id_sector, String id_potrero, String id_fundo, String estado, String fecha, String observaciones, String operacion_sql)
        {
            contexto.SyncPlanta.Add(new SyncPlanta { ID_Planta = id_planta.ToUpper().Replace(",", "."), ID_Hilera = id_hilera.ToUpper(), ID_Cuartel = id_cuartel.ToUpper(), ID_Sector = id_sector.ToUpper(), ID_Potrero = id_potrero.ToUpper(), ID_Fundo = id_fundo.ToUpper(), Estado = estado.ToUpper(), Fecha_Plantacion = fecha.ToUpper().Replace(",", "."), Observaciones = observaciones.ToUpper().Replace(",", "."), ID_Mapeo = lastMapeo(), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRACION DE ESTADOS

        public void insertarEstado(String idestado)
        {
            contexto.Estado.Add(new Estado { ID_Estado = idestado.ToUpper().Replace(",", ".").Replace(" ", "_") });
            contexto.SaveChanges();
        }

        public void eliminarEstado(String idestado)
        {
            Estado estado = (from e in contexto.Estado
                             where e.ID_Estado == idestado.ToUpper()
                             select e).FirstOrDefault();
            contexto.Estado.Remove(estado);
            contexto.SaveChanges();
        }

        public void actualizarEstado(String id_estadold, String id_estado)
        {
            Estado estado = (from e in contexto.Estado
                             where e.ID_Estado == id_estadold.ToUpper()
                             select e).FirstOrDefault();
            estado.ID_Estado = id_estado.ToUpper().Replace(",", ".");
            contexto.SaveChanges();
        }

        public void insertarSyncEstado(String idestado, String operacion_sql)
        {
            contexto.SyncEstado.Add(new SyncEstado { ID_Estado = idestado.ToUpper().Replace(",", ".").Replace(" ", "_"), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //ADMINISTRADOR DE VARIEDADES

        public void insertarVariedad(String id_variedad, String nombre, String id_producto)
        {
            contexto.Variedad.Add(new Variedad { ID_Variedad = id_variedad.ToUpper().Replace(",", "."), Nombre = nombre.ToUpper().Replace(",", "."), ID_Producto = id_producto.ToUpper().Replace(",", ".") });
            contexto.SaveChanges();
        }

        public void actualizarVariedad(String id_variedad, String nombre, String id_producto)
        {
            Variedad variedad = (from v in contexto.Variedad
                                 where v.ID_Variedad == id_variedad.ToUpper()
                                 && v.ID_Producto == id_producto.ToUpper()
                                 select v).FirstOrDefault();
            variedad.Nombre = nombre.ToUpper().Replace(",", ".");
            contexto.SaveChanges();
        }

        public void eliminarVariedad(String id_variedad, String id_producto)
        {
            Variedad variedad = (from v in contexto.Variedad
                                 where v.ID_Variedad == id_variedad.ToUpper()
                                 && v.ID_Producto == id_producto.ToUpper()
                                 select v).FirstOrDefault();
            contexto.Variedad.Remove(variedad);
            contexto.SaveChanges();
        }

        public void insertarSyncVariedad(String id_variedad, String nombre, String id_producto, String operacion_sql)
        {
            contexto.SyncVariedad.Add(new SyncVariedad { ID_Variedad = id_variedad.ToUpper().Replace(",", "."), Nombre = nombre.ToUpper().Replace(",", "."), ID_producto = id_producto.ToUpper().Replace(",", "."), OperacionSQL = operacion_sql });
            contexto.SaveChanges();
        }

        //SISTEMA PRODUCCION ARANDANOS
        //ADMINISTRADOR DE TRABAJADOR 

        public void insertarTrabajador(String rut, String nombre, String apellido, String qrrut, String fechaNac, String fechaIngreso, int ficha)
        {
            //ultimo campo adicional para sistema alamo (null)
            contexto.Trabajador.Add(new Trabajador { Rut = rut.ToUpper().Replace(".", ""), Nombre = nombre.ToUpper(), Apellido = apellido.ToUpper(), QRrut = qrrut.ToUpper().Replace(".", ""), FechaNacimiento = DateTime.Parse(fechaNac), FechaIngreso = DateTime.Parse(fechaIngreso), Ficha = ficha });
            contexto.SaveChanges();
        }

        public void actualizarTrabajador(String rut, String nombre, String apellido, String qrrut, String fechaNac, String fechaIngreso, int ficha)
        {
            Trabajador trabajador = (from t in contexto.Trabajador
                                     where t.Rut == rut.ToUpper().Replace(".", "")
                                     select t).FirstOrDefault();
            trabajador.Nombre = nombre.ToUpper();
            trabajador.Apellido = apellido.ToUpper();
            trabajador.QRrut = qrrut.ToUpper().Replace(".", "");
            trabajador.FechaNacimiento = DateTime.Parse(fechaNac);
            trabajador.FechaIngreso = DateTime.Parse(fechaIngreso);
            if (trabajador.Ficha != ficha)
            {
                trabajador.Importado = null;
                trabajador.Ficha = ficha;
            }            
            contexto.SaveChanges();
        }

        public void eliminarTrabajador(String rut)
        {
            Trabajador trabajador = (from t in contexto.Trabajador
                                     where t.Rut == rut.ToUpper().Replace(".", "")
                                     select t).FirstOrDefault();
            contexto.Trabajador.Remove(trabajador);
            contexto.SaveChanges();
        }

        //ADMINISTRADOR DE PESAJE

        public void insertarPesaje(String producto, String qrenvase, String ruttrabajador, String rutpesador, String fundo, String potrero, String sector, String variedad, String cuartel, DateTime fechahora, decimal pesoneto, decimal tara, String formato, decimal totalcant, decimal factor, decimal cantidad, String lecturasval, String tiporegistro, String fechahoramod, String usuariomod)
        {
            try
            {
                contexto.Pesaje.Add(new Pesaje { Producto = producto.ToUpper().Replace(".", ""), QRenvase = qrenvase.ToUpper().Replace(".", ""), RutTrabajador = ruttrabajador.ToUpper().Replace(".", ""), RutPesador = rutpesador.ToUpper().Replace(".", ""), Fundo = fundo.ToUpper().Replace(".", ""), Potrero = potrero.ToUpper().Replace(".", ""), Sector = sector.ToUpper().Replace(".", ""), Variedad = variedad.ToUpper().Replace(".", ""), Cuartel = cuartel.ToUpper().Replace(".", ""), FechaHora = fechahora, PesoNeto = pesoneto, Tara = tara, Formato = formato.ToUpper().Replace(".", ""), TotalCantidad = totalcant, Factor = factor, Cantidad = cantidad, Lectura_SVAL = lecturasval.ToUpper().Replace(".", ""), ID_Map = lastMapeo(), TipoRegistro = tiporegistro.ToUpper().Replace(".", ""), FechaHoraModificacion = fechahoramod.ToUpper().Replace(".", ""), UsuarioModificacion = usuariomod.ToUpper().Replace(".", "") });
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        public void actualizarPesaje(String qrold, DateTime fechaold, String producto, String qrenvase, String ruttrabajador, String rutpesador, String fundo, String potrero, String sector, String variedad, String cuartel, DateTime fechahora, decimal pesoneto, decimal tara, String formato, decimal totalcant, decimal factor, decimal cantidad, String lecturasval, String fechahoramod, String usuariomod)
        {
            try
            {
                Pesaje pesaje = (from p in contexto.Pesaje
                                 where p.Producto == producto
                                 && p.QRenvase == qrold.ToUpper().Replace(".", "")
                                 && p.FechaHora == fechaold
                                 select p).FirstOrDefault();
                pesaje.Producto = producto.ToUpper().Replace(".", "");
                pesaje.QRenvase = qrenvase.ToUpper().Replace(".", "");
                pesaje.RutTrabajador = ruttrabajador.ToUpper().Replace(".", "");
                pesaje.RutPesador = rutpesador.ToUpper().Replace(".", "");
                pesaje.Fundo = fundo.ToUpper().Replace(".", "");
                pesaje.Potrero = potrero.ToUpper().Replace(".", "");
                pesaje.Sector = sector.ToUpper().Replace(".", "");
                pesaje.Variedad = variedad.ToUpper().Replace(".", "");
                pesaje.Cuartel = cuartel.ToUpper().Replace(".", "");
                pesaje.FechaHora = fechahora;
                pesaje.PesoNeto = pesoneto;
                pesaje.Tara = tara;
                pesaje.Formato = formato.ToUpper().Replace(".", "");
                pesaje.TotalCantidad = totalcant;
                pesaje.Factor = factor;
                pesaje.Cantidad = cantidad;
                pesaje.Lectura_SVAL = lecturasval.ToUpper().Replace(".", "");
                pesaje.ID_Map = lastMapeo();
                pesaje.FechaHoraModificacion = fechahoramod.ToUpper().Replace(".", "");
                pesaje.UsuarioModificacion = usuariomod.ToUpper().Replace(".", "");
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

        }

        public void actualizarPesajeMasivo(String id, String fundo, String potrero, String sector, String variedad, String cuartel, String fechahoramod, String usuariomod)
        {
            int ide = int.Parse(id);
            try
            {
                Pesaje pesaje = (from p in contexto.Pesaje
                                 where p.id == ide
                                 select p).FirstOrDefault();
                pesaje.Fundo = fundo.ToUpper().Replace(".", "");
                pesaje.Potrero = potrero.ToUpper().Replace(".", "");
                pesaje.Sector = sector.ToUpper().Replace(".", "");
                pesaje.Variedad = variedad.ToUpper().Replace(".", "");
                pesaje.Cuartel = cuartel.ToUpper().Replace(".", "");                
                pesaje.FechaHoraModificacion = fechahoramod.ToUpper().Replace(".", "");
                pesaje.UsuarioModificacion = usuariomod.ToUpper().Replace(".", "");
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

        }

        public void eliminarPesaje(String producto, String qrenvase, DateTime fechahora)
        {
            try
            {
                Pesaje pesaje = (from p in contexto.Pesaje
                                 where p.Producto == producto
                                 && p.QRenvase == qrenvase.ToUpper().Replace(".", "")
                                 && p.FechaHora == fechahora
                                 select p).FirstOrDefault();
                contexto.Pesaje.Remove(pesaje);
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        //ADMINISTRACION DE COSECHA MAQUINA
        public void insertarCosechaMaquina(String producto, String fundo, String potrero, String sector, String variedad, String cuartel, DateTime fecha, decimal pesoneto, decimal bandejas, String guia, String recepcion)
        {
            try
            {
                contexto.CosechaMaquina.Add(new CosechaMaquina { Producto = producto.ToUpper().Replace(".", ""), Fundo = fundo.ToUpper().Replace(".", ""), Potrero = potrero.ToUpper().Replace(".", ""), Sector = sector.ToUpper().Replace(".", ""), Variedad = variedad.ToUpper().Replace(".", ""), Cuartel = cuartel.ToUpper().Replace(".", ""), Fecha = fecha, PesoNeto = pesoneto, Bandejas = bandejas, Guia = guia.ToUpper().Replace(".", ""), Recepcion = recepcion.ToUpper().Replace(".", ""), ID_Map = lastMapeo() });
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        public void actualizarCosechaMaquina(String fundo, String potrero, String sector, String variedad, String cuartel, DateTime fecha, decimal pesoneto, decimal bandejas, String guia, String recepcion, int id)
        {
            try
            {
                CosechaMaquina cosechaMaquina = (from c in contexto.CosechaMaquina
                                                 where c.id == id
                                                 select c).FirstOrDefault();
                cosechaMaquina.Fundo = fundo.ToUpper().Replace(".", "");
                cosechaMaquina.Potrero = potrero.ToUpper().Replace(".", "");
                cosechaMaquina.Sector = sector.ToUpper().Replace(".", "");
                cosechaMaquina.Variedad = variedad.ToUpper().Replace(".", "");
                cosechaMaquina.Cuartel = cuartel.ToUpper().Replace(".", "");
                cosechaMaquina.Fecha = fecha;
                cosechaMaquina.PesoNeto = pesoneto;
                cosechaMaquina.Bandejas = bandejas;
                cosechaMaquina.Guia = guia.ToUpper().Replace(".", "");
                cosechaMaquina.Recepcion = recepcion.ToUpper().Replace(".", "");
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

        }

        public void eliminarCosechaMaquina(int id)
        {
            try
            {
                CosechaMaquina cosechaMaquina = (from c in contexto.CosechaMaquina
                                                 where c.id == id
                                                 select c).FirstOrDefault();
                contexto.CosechaMaquina.Remove(cosechaMaquina);
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        //ADMINISTRACION DE TARA
        public void insertarTara(String id_tara, decimal peso, String descripcion, String producto, String formato)
        {
            contexto.Tara.Add(new Modelo.Tara { ID_Tara = id_tara.ToUpper(), Peso = peso, Descripcion = descripcion.ToUpper(), Producto = producto.ToUpper(), Formato = formato.ToUpper() });
            contexto.SaveChanges();
        }

        public void actualizarTara(String id_tara, decimal peso, String descripcion, String producto, String formato)
        {
            Modelo.Tara tara = (from t in contexto.Tara
                                where t.ID_Tara == id_tara
                                select t).FirstOrDefault();
            tara.Peso = peso;
            tara.Descripcion = descripcion.ToUpper();
            tara.Producto = producto.ToUpper();
            tara.Formato = formato.ToUpper();
            contexto.SaveChanges();
        }

        public void eliminarTara(String id_tara)
        {
            Modelo.Tara tara = (from t in contexto.Tara
                                where t.ID_Tara == id_tara
                                select t).FirstOrDefault();
            contexto.Tara.Remove(tara);
            contexto.SaveChanges();
        }

        //funciones para llenar gráficos
        public String[] getVariedades(String producto)
        {
            String[] variedades = (from v in contexto.Variedad where v.ID_Producto == producto orderby v.ID_Variedad select v.Nombre).ToArray();
            return variedades;
        }

        public String[] getIDvariedades(String producto)
        {
            String[] variedades = (from v in contexto.Variedad where v.ID_Producto == producto orderby v.ID_Variedad select v.ID_Variedad).ToArray();
            return variedades;
        }

        public double[] getCantidadPorVariedad(String producto, String fundo, String potrero, String sector, String cuartel, DateTime fechinicio, DateTime fechtermino)
        {
            String[] lista = getIDvariedades(producto);
            double[] cantidades = new double[lista.Length];
            for (int i = 0; i < lista.Length; i++)
            {
                var temp = lista[i];
                double cantidad = 0;
                try
                {
                    if (!potrero.Equals("0") && !sector.Equals("0") && !cuartel.Equals("0"))
                    {
                        cantidad = Double.Parse((from p in contexto.Pesaje
                                                 where p.Producto == producto 
                                                 && p.Variedad == temp
                                                 && p.Fundo == fundo
                                                 && p.Potrero == potrero
                                                 && p.Sector == sector
                                                 && p.Cuartel == cuartel
                                                 && p.FechaHora >= fechinicio
                                                 && p.FechaHora <= fechtermino
                                                 select p.PesoNeto).Sum().ToString());
                    }
                    else if (potrero.Equals("0"))
                    {
                        cantidad = Double.Parse((from p in contexto.Pesaje
                                                 where p.Producto == producto
                                                && p.Variedad == temp
                                                && p.Fundo == fundo
                                                 && p.FechaHora >= fechinicio
                                                 && p.FechaHora <= fechtermino
                                                 select p.PesoNeto).Sum().ToString());
                    }
                    else if (sector.Equals("0"))
                    {
                        cantidad = Double.Parse((from p in contexto.Pesaje
                                                 where p.Producto == producto
                                                && p.Variedad == temp
                                                && p.Fundo == fundo
                                                 && p.Potrero == potrero
                                                 && p.FechaHora >= fechinicio
                                                 && p.FechaHora <= fechtermino
                                                 select p.PesoNeto).Sum().ToString());
                    }
                    else if (cuartel.Equals("0"))
                    {
                        cantidad = Double.Parse((from p in contexto.Pesaje
                                                 where p.Producto == producto
                                                && p.Variedad == temp
                                                && p.Fundo == fundo
                                                 && p.Potrero == potrero
                                                 && p.Sector == sector
                                                 && p.FechaHora >= fechinicio
                                                 && p.FechaHora <= fechtermino
                                                 select p.PesoNeto).Sum().ToString());
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    cantidad = 0;
                }
                cantidades[i] = cantidad;
            }
            return cantidades;
        }

        public String[] getNombres(String producto, String fundo, String potrero, String sector)
        {
            String[] nombres = { };
            if (potrero.Equals("0") && sector.Equals("0"))
            {
                nombres = (from p in contexto.Potrero where p.ID_Producto == producto && p.ID_Fundo == fundo orderby p.ID_Potrero select p.Nombre).ToArray();
            }
            if (!potrero.Equals("0") && sector.Equals("0"))
            {
                nombres = (from s in contexto.Sector where s.ID_Producto == producto && s.ID_Fundo == fundo && s.ID_Potrero == potrero orderby s.ID_Sector select s.Nombre).ToArray();
            }
            if (!potrero.Equals("0") && !sector.Equals("0"))
            {
                nombres = (from c in contexto.Cuartel where c.ID_Fundo == fundo && c.ID_Potrero == potrero && c.ID_Sector == sector orderby c.ID_Cuartel select c.Nombre).ToArray();
            }
            return nombres;
        }

        public String[] getIDs(String producto, String fundo, String potrero, String sector)
        {
            String[] ids = { };
            if (potrero.Equals("0") && sector.Equals("0"))
            {
                ids = (from p in contexto.Potrero where p.ID_Producto == producto && p.ID_Fundo == fundo orderby p.ID_Potrero select p.ID_Potrero).ToArray();
            }
            if (!potrero.Equals("0") && sector.Equals("0"))
            {
                ids = (from s in contexto.Sector where s.ID_Producto == producto && s.ID_Fundo == fundo && s.ID_Potrero == potrero orderby s.ID_Sector select s.ID_Sector).ToArray();
            }
            if (!potrero.Equals("0") && !sector.Equals("0"))
            {
                ids = (from c in contexto.Cuartel where c.ID_Fundo == fundo && c.ID_Potrero == potrero && c.ID_Sector == sector orderby c.ID_Cuartel select c.ID_Cuartel).ToArray();
            }
            return ids;
        }

        public double[] getCantidadTotal(String producto, String fundo, String potrero, String sector, DateTime fechinicio, DateTime fechtermino)
        {
            String[] lista = getIDs(producto, fundo, potrero, sector);
            double[] cantidades = new double[lista.Length];
            for (int i = 0; i < lista.Length; i++)
            {
                var temp = lista[i];
                double cantidad = 0;
                try
                {
                    if (potrero.Equals("0") && sector.Equals("0"))
                    {
                        cantidad = Double.Parse((from p in contexto.Pesaje
                                                 where p.Producto == producto
                                                 && p.Potrero == temp
                                                 && p.FechaHora >= fechinicio
                                                 && p.FechaHora <= fechtermino
                                                 select p.PesoNeto).Sum().ToString());
                    }
                    if (!potrero.Equals("0") && sector.Equals("0"))
                    {
                        cantidad = Double.Parse((from p in contexto.Pesaje
                                                 where p.Producto == producto
                                                 && p.Sector == temp
                                                 && p.Fundo == fundo
                                                 && p.Potrero == potrero
                                                 && p.FechaHora >= fechinicio
                                                 && p.FechaHora <= fechtermino
                                                 select p.PesoNeto).Sum().ToString());
                    }
                    if (!potrero.Equals("0") && !sector.Equals("0"))
                    {
                        cantidad = Double.Parse((from p in contexto.Pesaje
                                                 where p.Producto == producto
                                                 && p.Cuartel == temp
                                                 && p.Fundo == fundo
                                                 && p.Potrero == potrero
                                                 && p.Sector == sector
                                                 && p.FechaHora >= fechinicio
                                                 && p.FechaHora <= fechtermino
                                                 select p.PesoNeto).Sum().ToString());
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    cantidad = 0;
                }
                cantidades[i] = cantidad;
            }
            return cantidades;
        }
    }
}