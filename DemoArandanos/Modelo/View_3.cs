namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_3
    {
        [Key]
        [StringLength(50)]
        public string Producto { get; set; }

        [StringLength(10)]
        public string Fecha { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? Kilos { get; set; }
    }
}
