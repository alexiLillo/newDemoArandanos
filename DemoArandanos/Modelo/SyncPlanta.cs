namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SyncPlanta")]
    public partial class SyncPlanta
    {
        [Required]
        [StringLength(50)]
        public string ID_Planta { get; set; }

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
        public string Estado { get; set; }

        [StringLength(50)]
        public string Fecha_Plantacion { get; set; }

        [StringLength(250)]
        public string Observaciones { get; set; }

        public int ID_Mapeo { get; set; }

        [Required]
        [StringLength(50)]
        public string OperacionSQL { get; set; }

        [Key]
        public int idSync { get; set; }
    }
}
