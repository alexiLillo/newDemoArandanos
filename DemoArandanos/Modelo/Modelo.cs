namespace DemoArandanos.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo8")
        {
        }

        public virtual DbSet<Cuartel> Cuartel { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fundo> Fundo { get; set; }
        public virtual DbSet<Hilera> Hilera { get; set; }
        public virtual DbSet<Map> Map { get; set; }
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
        public virtual DbSet<Tara> Tara { get; set; }
        public virtual DbSet<Trabajador> Trabajador { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Variedad> Variedad { get; set; }
        public virtual DbSet<Pesaje> Pesaje { get; set; }
        public virtual DbSet<TablaVista> TablaVista { get; set; }
        public virtual DbSet<VistaApkPesaje> VistaApkPesaje { get; set; }
        public virtual DbSet<VistaConsulta> VistaConsulta { get; set; }
        public virtual DbSet<VistaConsultaDia> VistaConsultaDia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
                .HasMany(e => e.Cuartel)
                .WithRequired(e => e.Sector)
                .HasForeignKey(e => new { e.ID_Sector, e.ID_Potrero, e.ID_Fundo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.Pesaje)
                .WithRequired(e => e.Sector1)
                .HasForeignKey(e => new { e.Sector, e.Potrero, e.Fundo })
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.Pesaje)
                .WithRequired(e => e.Variedad1)
                .HasForeignKey(e => new { e.Variedad, e.Producto })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.Producto)
                .IsUnicode(false);

            modelBuilder.Entity<Pesaje>()
                .Property(e => e.QRenvase)
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
        }
    }
}
