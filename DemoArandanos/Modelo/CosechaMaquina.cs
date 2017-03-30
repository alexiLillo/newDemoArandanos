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
        [Required]
        [StringLength(50)]
        public string Producto { get; set; }

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
        public DateTime Fecha { get; set; }

        public decimal PesoNeto { get; set; }

        public decimal Bandejas { get; set; }

        [Required]
        [StringLength(50)]
        public string Guia { get; set; }

        [Required]
        [StringLength(50)]
        public string Recepcion { get; set; }

        public int? ID_Map { get; set; }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
