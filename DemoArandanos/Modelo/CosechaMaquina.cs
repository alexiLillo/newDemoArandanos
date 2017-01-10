namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CosechaMaquina")]
    public partial class CosechaMaquina
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Producto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Fundo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Potrero { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Sector { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Variedad { get; set; }

        [StringLength(50)]
        public string Cuartel { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime Fecha { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal PesoNeto { get; set; }

        [Key]
        [Column(Order = 7)]
        public decimal Bandejas { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Guia { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string Recepcion { get; set; }

        public int? ID_Map { get; set; }

        [Key]
        [Column(Order = 10)]
        public int id { get; set; }
    }
}
