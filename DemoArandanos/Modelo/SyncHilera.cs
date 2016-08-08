namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SyncHilera")]
    public partial class SyncHilera
    {
        [Required]
        [StringLength(50)]
        public string ID_Hilera { get; set; }

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

        [StringLength(50)]
        public string Variedad { get; set; }

        public int ID_Mapeo { get; set; }

        [Required]
        [StringLength(50)]
        public string OperacionSQL { get; set; }

        [Key]
        public int idSync { get; set; }
    }
}
