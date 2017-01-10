namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VistaDiasCosecha")]
    public partial class VistaDiasCosecha
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Fundo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Potrero { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Sector { get; set; }

        [StringLength(50)]
        public string Cuartel { get; set; }

        public int? Dias { get; set; }

        public decimal? BandejasTotal { get; set; }

        public decimal? KilosTotal { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "smalldatetime")]
        public DateTime FechaHora { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Producto { get; set; }
    }
}
