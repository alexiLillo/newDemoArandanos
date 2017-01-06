namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Variedad")]
    public partial class Variedad
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Variedad { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ID_Producto { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoEnvase { get; set; }

        public double KilosNetoEnvase { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
