namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trabajador")]
    public partial class Trabajador
    {
        [Key]
        [StringLength(50)]
        public string Rut { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string QRrut { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaNacimiento { get; set; }
    }
}
