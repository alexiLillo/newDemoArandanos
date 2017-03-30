namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_2
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string QRenvase { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "smalldatetime")]
        public DateTime FechaHora { get; set; }

        [StringLength(50)]
        public string FechaHoraModificacion { get; set; }

        [StringLength(50)]
        public string Lectura_SVAL { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Cantidad { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal PesoNeto { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string RutTrabajador { get; set; }
    }
}
