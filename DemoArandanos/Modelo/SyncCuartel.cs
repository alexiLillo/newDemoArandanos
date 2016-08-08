namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SyncCuartel")]
    public partial class SyncCuartel
    {
        [Required]
        [StringLength(50)]
        public string ID_Cuartel { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_Sector { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [Required]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        public double? Superficie { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string OperacionSQL { get; set; }

        [Key]
        public int idSync { get; set; }
    }
}
