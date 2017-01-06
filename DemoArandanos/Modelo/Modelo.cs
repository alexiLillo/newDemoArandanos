namespace DemoArandanos.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo12")
        {
        }

        public virtual DbSet<Cuadrillas> Cuadrillas { get; set; }
        public virtual DbSet<Cuartel> Cuartel { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fundo> Fundo { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Hilera> Hilera { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<Pesaje> Pesaje { get; set; }
        public virtual DbSet<PesajeTest> PesajeTest { get; set; }
        public virtual DbSet<Planta> Planta { get; set; }
        public virtual DbSet<Potrero> Potrero { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<SyncCuartel> SyncCuartel { get; set; }
        public virtual DbSet<SyncEstado> SyncEstado { get; set; }
        public virtual DbSet<SyncFundo> SyncFundo { get; set; }
        public virtual DbSet<SyncHilera> SyncHilera { get; set; }
        public virtual DbSet<SyncMap> SyncMap { get; set; }
        public virtual DbSet<SyncPlanta> SyncPlanta { get; set; }
        public virtual DbSet<SyncPotrero> SyncPotrero { get; set; }
        public virtual DbSet<SyncProducto> SyncProducto { get; set; }
        public virtual DbSet<SyncSector> SyncSector { get; set; }
        public virtual DbSet<SyncUsuarios> SyncUsuarios { get; set; }
        public virtual DbSet<SyncVariedad> SyncVariedad { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tara> Tara { get; set; }
        public virtual DbSet<Trabajador> Trabajador { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Variedad> Variedad { get; set; }
        public virtual DbSet<TablaVista> TablaVista { get; set; }
        public virtual DbSet<rmorisb_acumDiaMes> rmorisb_acumDiaMes { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }
        public virtual DbSet<Vis_Duplicadas1> Vis_Duplicadas1 { get; set; }
        public virtual DbSet<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var> Vis_Fun_Pot_Sec_Cua_Hil_Est_Var { get; set; }
        public virtual DbSet<Vis_PesajeGeneral> Vis_PesajeGeneral { get; set; }
        public virtual DbSet<VistaAll> VistaAll { get; set; }
        public virtual DbSet<VistaApkPesaje> VistaApkPesaje { get; set; }
        public virtual DbSet<VistaConsulta> VistaConsulta { get; set; }
        public virtual DbSet<VistaConsultaDia> VistaConsultaDia { get; set; }
        public virtual DbSet<VistaCosecha> VistaCosecha { get; set; }
        public virtual DbSet<VistaCosechaHoy> VistaCosechaHoy { get; set; }
        public virtual DbSet<VistaDiasCosecha> VistaDiasCosecha { get; set; }
        public virtual DbSet<VistaRanking> VistaRanking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuadrillas>()
                .Property(e => e.Cuadrilla)
                .IsUnicode(false);

            modelBuilder.Entity<Cuadrillas>()
                .Property(e => e.Grupo)
                .IsUnicode(false);

            modelBuilder.Entity<Cuartel>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<Cuartel>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Cuartel>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Cuartel>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Cuartel>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cuartel>()
                .HasMany(e => e.Hilera)
                .WithRequired(e => e.Cuartel)
                .HasForeignKey(e => new { e.ID_Cuartel, e.ID_Sector, e.ID_Potrero, e.ID_Fundo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.ID_Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Planta)
                .WithOptional(e => e.Estado1)
                .HasForeignKey(e => e.Estado);

            modelBuilder.Entity<Fundo>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Fundo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Fundo>()
                .HasMany(e => e.Potrero)
                .WithRequired(e => e.Fundo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupos>()
                .Property(e => e.Grupo)
                .IsUnicode(false);

            modelBuilder.Entity<Hilera>()
                .Property(e => e.ID_Hilera)
                .IsUnicode(false);

            modelBuilder.Entity<Hilera>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<Hilera>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Hilera>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Hilera>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Hilera>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<Hilera>()
                .HasMany(e => e.Planta)
                .WithRequired(e => e.Hilera)
                .HasForeignKey(e => new { e.ID_Hilera, e.ID_Cuartel, e.ID_Sector, e.ID_Potrero, e.ID_Fundo, e.ID_Mapeo });

            modelBuilder.Entity<Map>()
                .HasMany(e => e.Hilera)
                .WithRequired(e => e.Map)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.QRenvase)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Cuadrilla)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.RutTrabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.RutPesador)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.PesoNeto)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Tara)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Formato)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.TotalCantidad)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Factor)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Lectura_SVAL)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.TipoRegistro)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.FechaHoraModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.UsuarioModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Producto)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.QRenvase)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.RutTrabajador)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.RutPesador)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.PesoNeto)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Tara)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Formato)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.TotalCantidad)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Factor)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.Lectura_SVAL)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.TipoRegistro)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.FechaHoraModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<PesajeTest>()
                .Property(e => e.UsuarioModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.ID_Planta)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.ID_Hilera)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.Fecha_Plantacion)
                .IsUnicode(false);

            modelBuilder.Entity<Planta>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Potrero>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Potrero>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Potrero>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Potrero>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Potrero>()
                .HasMany(e => e.Sector)
                .WithRequired(e => e.Potrero)
                .HasForeignKey(e => new { e.ID_Potrero, e.ID_Fundo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Variedad)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sector>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Sector>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Sector>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Sector>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sector>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<SyncCuartel>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<SyncCuartel>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<SyncCuartel>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<SyncCuartel>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<SyncCuartel>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SyncCuartel>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncEstado>()
                .Property(e => e.ID_Estado)
                .IsUnicode(false);

            modelBuilder.Entity<SyncEstado>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncFundo>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<SyncFundo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SyncFundo>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncHilera>()
                .Property(e => e.ID_Hilera)
                .IsUnicode(false);

            modelBuilder.Entity<SyncHilera>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<SyncHilera>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<SyncHilera>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<SyncHilera>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<SyncHilera>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<SyncHilera>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncMap>()
                .Property(e => e.OpercionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.ID_Planta)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.ID_Hilera)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.Fecha_Plantacion)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPlanta>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPotrero>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPotrero>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPotrero>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SyncPotrero>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncProducto>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<SyncProducto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SyncProducto>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncSector>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<SyncSector>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<SyncSector>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<SyncSector>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SyncSector>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncUsuarios>()
                .Property(e => e.user)
                .IsUnicode(false);

            modelBuilder.Entity<SyncUsuarios>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<SyncUsuarios>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<SyncUsuarios>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SyncVariedad>()
                .Property(e => e.ID_Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<SyncVariedad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<SyncVariedad>()
                .Property(e => e.ID_producto)
                .IsUnicode(false);

            modelBuilder.Entity<SyncVariedad>()
                .Property(e => e.OperacionSQL)
                .IsUnicode(false);

            modelBuilder.Entity<Tara>()
                .Property(e => e.ID_Tara)
                .IsUnicode(false);

            modelBuilder.Entity<Tara>()
                .Property(e => e.Peso)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tara>()
                .Property(e => e.Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Tara>()
                .Property(e => e.Formato)
                .IsUnicode(false);

            modelBuilder.Entity<Tara>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Trabajador>()
                .Property(e => e.Rut)
                .IsUnicode(false);

            modelBuilder.Entity<Trabajador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Trabajador>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Trabajador>()
                .Property(e => e.QRrut)
                .IsUnicode(false);

            modelBuilder.Entity<Trabajador>()
                .Property(e => e.Importado)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.user)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Variedad>()
                .Property(e => e.ID_Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<Variedad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Variedad>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Variedad>()
                .Property(e => e.TipoEnvase)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.nombreFundo)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.nombrePotrero)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.nombreSector)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.ID_Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.nombreVariedad)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<TablaVista>()
                .Property(e => e.nombreCuartel)
                .IsUnicode(false);

            modelBuilder.Entity<rmorisb_acumDiaMes>()
                .Property(e => e.Bandejas)
                .HasPrecision(38, 3);

            modelBuilder.Entity<rmorisb_acumDiaMes>()
                .Property(e => e.PesoNeto)
                .HasPrecision(38, 3);

            modelBuilder.Entity<rmorisb_acumDiaMes>()
                .Property(e => e.Producto)
                .IsUnicode(false);

            modelBuilder.Entity<View_1>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<View_1>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<View_1>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<View_1>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Duplicadas1>()
                .Property(e => e.QRenvase)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Duplicadas1>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.ID_Hilera)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_Fun_Pot_Sec_Cua_Hil_Est_Var>()
                .Property(e => e.ID_Planta)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Nombre_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.QRenvase)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.RutTrabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Nombre_Trabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Nombre_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Nombre_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Nombre_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Nombre_Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Nombre_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.PesoNeto)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Tara)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Formato)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.TotalCantidad)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Factor)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.Lectura_SVAL)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.TipoRegistro)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.FechaHoraModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Vis_PesajeGeneral>()
                .Property(e => e.UsuarioModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.nombrePotrero)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.nombreSector)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.nombreCuartel)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.ID_Hilera)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.nombreVariedad)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.ID_Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<VistaAll>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.ID_Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.nombreFundo)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.ID_Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.nombrePotrero)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.ID_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.nombreSector)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.ID_Variedad)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.nombreVariedad)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.ID_Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.nombreCuartel)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<VistaApkPesaje>()
                .Property(e => e.TipoEnvase)
                .IsUnicode(false);

            modelBuilder.Entity<VistaConsulta>()
                .Property(e => e.RutTrabajador)
                .IsUnicode(false);

            modelBuilder.Entity<VistaConsulta>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<VistaConsulta>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<VistaConsulta>()
                .Property(e => e.PesoNeto)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaConsulta>()
                .Property(e => e.Cantidad)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaConsultaDia>()
                .Property(e => e.RutTrabajador)
                .IsUnicode(false);

            modelBuilder.Entity<VistaConsultaDia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<VistaConsultaDia>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<VistaConsultaDia>()
                .Property(e => e.PesoNeto)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaConsultaDia>()
                .Property(e => e.Cantidad)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.BandejasTotal)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.KilosTotal)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.BandejasDia)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaCosecha>()
                .Property(e => e.KilosDia)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaCosechaHoy>()
                .Property(e => e.Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosechaHoy>()
                .Property(e => e.Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosechaHoy>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosechaHoy>()
                .Property(e => e.Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<VistaCosechaHoy>()
                .Property(e => e.BandejasDia)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaCosechaHoy>()
                .Property(e => e.KilosDia)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaDiasCosecha>()
                .Property(e => e.Fundo)
                .IsUnicode(false);

            modelBuilder.Entity<VistaDiasCosecha>()
                .Property(e => e.Potrero)
                .IsUnicode(false);

            modelBuilder.Entity<VistaDiasCosecha>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<VistaDiasCosecha>()
                .Property(e => e.Cuartel)
                .IsUnicode(false);

            modelBuilder.Entity<VistaDiasCosecha>()
                .Property(e => e.BandejasTotal)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaDiasCosecha>()
                .Property(e => e.KilosTotal)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaRanking>()
                .Property(e => e.Rut)
                .IsUnicode(false);

            modelBuilder.Entity<VistaRanking>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<VistaRanking>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<VistaRanking>()
                .Property(e => e.Bandejas)
                .HasPrecision(38, 3);

            modelBuilder.Entity<VistaRanking>()
                .Property(e => e.Kilos)
                .HasPrecision(38, 3);
        }
    }
}
