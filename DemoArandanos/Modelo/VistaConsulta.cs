namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VistaConsulta")]
    public partial class VistaConsulta
    {
        [Key]
        [StringLength(50)]
        public string RutTrabajador { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        public decimal? PesoNeto { get; set; }

        public decimal? Cantidad { get; set; }

        public int? ID_Map { get; set; }

        public int? Anio { get; set; }
    }
}
