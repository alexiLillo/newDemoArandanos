namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pesaje")]
    public partial class Pesaje
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Producto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string QRenvase { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string RutTrabajador { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string RutPesador { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Fundo { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Potrero { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Sector { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Variedad { get; set; }

        [StringLength(50)]
        public string Cuartel { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "smalldatetime")]
        public DateTime FechaHora { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal PesoNeto { get; set; }

        [Key]
        [Column(Order = 10)]
        public decimal Tara { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string Formato { get; set; }

        [Key]
        [Column(Order = 12)]
        public decimal TotalCantidad { get; set; }

        [Key]
        [Column(Order = 13)]
        public decimal Factor { get; set; }

        [Key]
        [Column(Order = 14)]
        public decimal Cantidad { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(50)]
        public string Lectura_SVAL { get; set; }

        public int? ID_Map { get; set; }
    }
}
