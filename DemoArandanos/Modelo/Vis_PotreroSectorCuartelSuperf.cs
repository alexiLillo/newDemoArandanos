namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vis_PotreroSectorCuartelSuperf
    {
        [Key]
        [StringLength(50)]
        public string ID_Producto { get; set; }

        [StringLength(50)]
        public string N_Potrero { get; set; }

        [StringLength(50)]
        public string N_Sector { get; set; }

        [StringLength(50)]
        public string N_Cuartel { get; set; }

        public double? Superficie { get; set; }
    }
}
