namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SyncUsuarios
    {
        [Required]
        [StringLength(50)]
        public string user { get; set; }

        [Required]
        [StringLength(50)]
        public string pass { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo { get; set; }

        public int id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string OperacionSQL { get; set; }

        [Key]
        public int idSync { get; set; }
    }
}
