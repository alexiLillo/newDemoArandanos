namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClaseVariedadPeso")]
    public partial class ClaseVariedadPeso
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Variedad { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Producto { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Clase { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string TipoEnvase { get; set; }

        [Key]
        [Column(Order = 4)]
        public double KilosNetoEnvase { get; set; }
    }
}
