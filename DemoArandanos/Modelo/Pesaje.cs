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
        [Required]
        [StringLength(50)]
        public string Producto { get; set; }

        [Required]
        [StringLength(50)]
        public string QRenvase { get; set; }

        [Required]
        [StringLength(50)]
        public string RutTrabajador { get; set; }

        [Required]
        [StringLength(50)]
        public string RutPesador { get; set; }

        [Required]
        [StringLength(50)]
        public string Fundo { get; set; }

        [Required]
        [StringLength(50)]
        public string Potrero { get; set; }

        [Required]
        [StringLength(50)]
        public string Sector { get; set; }

        [Required]
        [StringLength(50)]
        public string Variedad { get; set; }

        [StringLength(50)]
        public string Cuartel { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaHora { get; set; }

        public decimal PesoNeto { get; set; }

        public decimal Tara { get; set; }

        [Required]
        [StringLength(50)]
        public string Formato { get; set; }

        public decimal TotalCantidad { get; set; }

        public decimal Factor { get; set; }

        public decimal Cantidad { get; set; }

        [StringLength(50)]
        public string Lectura_SVAL { get; set; }

        public int? ID_Map { get; set; }

        [Key]
        public int id { get; set; }
    }
}
