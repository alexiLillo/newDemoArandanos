namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vis_PesajeGeneral_2
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Producto { get; set; }

        [StringLength(50)]
        public string Nombre_Producto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string QRenvase { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string RutTrabajador { get; set; }

        [StringLength(50)]
        public string Nombre_Trabajador { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Fundo { get; set; }

        [StringLength(50)]
        public string Nombre_Fundo { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Potrero { get; set; }

        [StringLength(50)]
        public string Nombre_Potrero { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Sector { get; set; }

        [StringLength(50)]
        public string Nombre_Sector { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Variedad { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Nombre_Variedad { get; set; }

        [StringLength(50)]
        public string Cuartel { get; set; }

        [StringLength(50)]
        public string Nombre_Cuartel { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "smalldatetime")]
        public DateTime FechaHora { get; set; }

        public double? PesoNeto { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal Tara { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string Formato { get; set; }

        public double? TotalCantidad { get; set; }

        public double? Factor { get; set; }

        public double? Cantidad { get; set; }

        [StringLength(50)]
        public string Lectura_SVAL { get; set; }

        public int? ID_Map { get; set; }

        [StringLength(50)]
        public string TipoRegistro { get; set; }

        [StringLength(50)]
        public string FechaHoraModificacion { get; set; }

        [StringLength(50)]
        public string UsuarioModificacion { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(50)]
        public string Clase { get; set; }
    }
}
