namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VistaRanking")]
    public partial class VistaRanking
    {
        [Key]
        [StringLength(50)]
        public string Rut { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        public decimal? Bandejas { get; set; }

        public decimal? Kilos { get; set; }

        public int? DiasTrabajados { get; set; }
    }
}
