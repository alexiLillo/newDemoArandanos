namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vis_ClaseVariedadPeso
    {
        [StringLength(50)]
        public string PRODUCTO { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string VARIEDAD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Clase { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string TipoEnvase { get; set; }

        [Key]
        [Column(Order = 3)]
        public double KilosNetoEnvase { get; set; }
    }
}
