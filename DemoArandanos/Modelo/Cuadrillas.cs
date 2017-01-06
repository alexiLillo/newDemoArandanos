namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cuadrillas
    {
        [Key]
        [StringLength(15)]
        public string Cuadrilla { get; set; }

        [Required]
        [StringLength(15)]
        public string Grupo { get; set; }
    }
}
