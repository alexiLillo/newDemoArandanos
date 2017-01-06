namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VistaCosechaHoy")]
    public partial class VistaCosechaHoy
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Fundo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Potrero { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Sector { get; set; }

        [StringLength(50)]
        public string Cuartel { get; set; }

        public decimal? BandejasDia { get; set; }

        public decimal? KilosDia { get; set; }
    }
}
