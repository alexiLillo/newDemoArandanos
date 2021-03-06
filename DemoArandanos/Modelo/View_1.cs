namespace DemoArandanos.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_1
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ID_Fundo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Variedad { get; set; }

        [StringLength(50)]
        public string ID_Producto { get; set; }
    }
}
