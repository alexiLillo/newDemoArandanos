namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vis_Duplicadas1
    {
        [Key]
        [StringLength(50)]
        public string QRenvase { get; set; }

        public int? Cant { get; set; }

        [StringLength(10)]
        public string Fecha { get; set; }
    }
}
