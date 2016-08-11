namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VistaAll")]
    public partial class VistaAll
    {
        [Key]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string ID_Potrero { get; set; }

        [StringLength(50)]
        public string nombrePotrero { get; set; }

        [StringLength(50)]
        public string ID_Sector { get; set; }

        [StringLength(50)]
        public string nombreSector { get; set; }

        [StringLength(50)]
        public string ID_Cuartel { get; set; }

        [StringLength(50)]
        public string nombreCuartel { get; set; }

        public double? Superficie { get; set; }

        [StringLength(50)]
        public string ID_Hilera { get; set; }

        [StringLength(50)]
        public string Variedad { get; set; }

        [StringLength(50)]
        public string nombreVariedad { get; set; }
    }
}
