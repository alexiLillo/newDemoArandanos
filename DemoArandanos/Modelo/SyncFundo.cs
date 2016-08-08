namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SyncFundo")]
    public partial class SyncFundo
    {
        [Required]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string OperacionSQL { get; set; }

        [Key]
        public int idSync { get; set; }
    }
}
