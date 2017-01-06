namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rmorisb_acumDiaMes
    {
        public int? Dia { get; set; }

        public int? Mes { get; set; }

        public int? ano { get; set; }

        public decimal? Bandejas { get; set; }

        public decimal? PesoNeto { get; set; }

        [Key]
        [StringLength(50)]
        public string Producto { get; set; }
    }
}
