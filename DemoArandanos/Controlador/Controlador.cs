﻿using DemoArandanos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArandanos.Controlador
{
    public class Controler
    {
        DemoArandanos.Modelo.Modelo contexto = new DemoArandanos.Modelo.Modelo();

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
                    else
                        if (resultado.tipo.Equals("normal"))
                        login = 2;
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

        //ADMINISTRADOR DE TRABAJADOR (SISTEMA PRODUCCION)

        public void insertarTrabajador(String rut, String nombre, String apellido, String qrrut, String fechaNac)
        {
            contexto.Trabajador.Add(new Trabajador { Rut = rut.ToUpper().Replace(".",""), Nombre = nombre.ToUpper(), Apellido = apellido.ToUpper(), QRrut = qrrut.ToUpper().Replace(".", ""), FechaNacimiento = DateTime.Parse(fechaNac) });
            contexto.SaveChanges();
        }

        public void actualizarTrabajador(String rut, String nombre, String apellido, String qrrut, String fechaNac)
        {
            Trabajador trabajador = (from t in contexto.Trabajador
                                     where t.Rut == rut.ToUpper().Replace(".", "")
                                     select t).FirstOrDefault();
            trabajador.Nombre = nombre.ToUpper();
            trabajador.Apellido = apellido.ToUpper();
            trabajador.QRrut = qrrut.ToUpper().Replace(".", "");
            trabajador.FechaNacimiento = DateTime.Parse(fechaNac);
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

    }
}