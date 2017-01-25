namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clase")]
    public partial class Clase
    {
        [Key]
        [Column("Clase")]
        [StringLength(50)]
        public string Clase1 { get; set; }
    }
}
