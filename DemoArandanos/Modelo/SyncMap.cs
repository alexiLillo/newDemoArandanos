namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SyncMap")]
    public partial class SyncMap
    {
        public int ID_Mapeo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Termino { get; set; }

        [Required]
        [StringLength(50)]
        public string OpercionSQL { get; set; }

        [Key]
        public int idSync { get; set; }
    }
}
